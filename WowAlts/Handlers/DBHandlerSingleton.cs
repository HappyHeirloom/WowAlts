using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowAlts.Models;
using WowAlts.Service;

namespace WowAlts.Handlers
{
    class DBHandlerSingleton
    {
        const string serverUrl = "http://localhost:51887/";
        private static DBHandlerSingleton _instance = null;
        public static DBHandlerSingleton Instance { get { return _instance ?? (_instance = new DBHandlerSingleton()); } }

        public ObservableCollection<JoinCharacter> Characters { get; }
        public ObservableCollection<JoinCharacter> CharactersAlliance { get; }
        public ObservableCollection<JoinCharacter> CharactersHorde { get; }


        private DBHandlerSingleton()
        {
            
            Characters = new ObservableCollection<JoinCharacter>();
            CharactersAlliance = new ObservableCollection<JoinCharacter>();
            CharactersHorde = new ObservableCollection<JoinCharacter>();


            LoadCharactersAsync();
        }


        public async void LoadCharactersAsync()
        {
            ObservableCollection<JoinCharacter> characters = await PersistencyService.LoadCharacters();

            foreach (var character in characters)
            {
                switch (character.Faction.ToLower())
                {
                    case "alliance":
                        CharactersAlliance.Add(character);
                        break;
                    case "horde":
                        CharactersHorde.Add(character);
                        break;
                }
                Characters.Add(character);
            }

        }
    }
}
