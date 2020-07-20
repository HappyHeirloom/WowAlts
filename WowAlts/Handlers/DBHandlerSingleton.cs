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

        public ObservableCollection<Realm> Realms { get; }
        public ObservableCollection<Faction> Factions { get; }
        public ObservableCollection<Class> Classes { get; }
        public ObservableCollection<Specs> Specs { get; }


        private DBHandlerSingleton()
        {
            
            Characters = new ObservableCollection<JoinCharacter>();
            CharactersAlliance = new ObservableCollection<JoinCharacter>();
            CharactersHorde = new ObservableCollection<JoinCharacter>();

            Realms = new ObservableCollection<Realm>();
            Factions = new ObservableCollection<Faction>();
            Classes = new ObservableCollection<Class>();
            Specs = new ObservableCollection<Specs>();

            LoadCharactersAsync();
            LoadRealmsAsync();
            LoadFactionsAsync();
            LoadClassesAsync();
            LoadSpecsAsync();
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

        public async void LoadRealmsAsync()
        {
            ObservableCollection<Realm> realms = await PersistencyService.LoadRealms();

            foreach (var realm in realms)
            {
                Realms.Add(realm);
            }
        }

        public async void LoadFactionsAsync()
        {
            ObservableCollection<Faction> factions = await PersistencyService.LoadFactions();

            foreach (var faction in factions)
            {
                Factions.Add(faction);
            }
        }

        public async void LoadClassesAsync()
        {
            ObservableCollection<Class> classes = await PersistencyService.LoadClasses();

            foreach (var classItem in classes)
            {
                Classes.Add(classItem);
            }
        }

        public async void LoadSpecsAsync()
        {
            ObservableCollection<Specs> specs = await PersistencyService.LoadSpecs();

            foreach (var specItem in specs)
            {
                Specs.Add(specItem);
            }
        }

    }
}
