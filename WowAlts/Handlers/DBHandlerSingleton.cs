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

        public ObservableCollection<Character> Characters { get; }
        public ObservableCollection<Character> CharactersAlliance { get; }
        public ObservableCollection<Character> CharactersHorde { get; }


        private DBHandlerSingleton()
        {
            
            Characters = new ObservableCollection<Character>();
            CharactersAlliance = new ObservableCollection<Character>();
            CharactersHorde = new ObservableCollection<Character>();


            LoadCharactersAsync();
        }


        public async void LoadCharactersAsync()
        {
            ObservableCollection<Character> characters = await PersistencyService.LoadCharacters();

            foreach (var character in characters)
            {
                switch (character.Faction_FK)
                {
                    case 1:
                        CharactersAlliance.Add(character);
                        break;
                    case 2:
                        CharactersHorde.Add(character);
                        break;
                }
                Characters.Add(character);
            }

        }
    }
}
