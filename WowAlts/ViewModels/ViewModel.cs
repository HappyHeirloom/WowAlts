using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using WowAlts.Handlers;
using WowAlts.Models;

namespace WowAlts.ViewModels
{
    class ViewModel
    {
        private NavigationHandler _nav = new NavigationHandler();
        private CreateCharacterHandler _char = new CreateCharacterHandler();

        //private string _name;
        //private string _realm;
        //private string _faction;
        //private string _classid;
        //private string _spec;
        //private int _level;
        //private int _hoa;
        //private int _cloak;


        public ViewModel()
        {
            CharacterList = DBHandlerSingleton.Instance.Characters;
            CharacterListAlliance = DBHandlerSingleton.Instance.CharactersAlliance;
            CharacterListHorde = DBHandlerSingleton.Instance.CharactersHorde;

            #region RelayCommands

            GoBackToHomeCommand = new RelayCommand(_nav.NavigateToHome, null);
            NavigateToAllianceCommand = new RelayCommand(_nav.NavigateToAlliance, null);
            NavigateToHordeCommand = new RelayCommand(_nav.NavigateToHorde, null);
            NavigateToCreateAltCommand = new RelayCommand(_nav.NavigateToCreateAlt, null);

            CreateAltCommand = new RelayCommand(CreateCharacter, null);

            #endregion
        }

        #region Properties

        public JoinCharacter SelectedCharacter { get; set; }
        public string AltName { get; set; }
        public string Realm { get; set; }
        public string Faction { get; set; }
        public string ClassName { get; set; }
        public string Spec { get; set; }
        public int Level { get; set; }
        public int HoA { get; set; }
        public int Cloak { get; set; }

        #endregion

        #region Methods

        public void CreateCharacter()
        {
            _char.CreateCharacter(AltName, Realm, Faction, ClassName, Spec, Level, HoA, Cloak);
        }

        #endregion

        #region ICommands

        public ICommand GoBackToHomeCommand { get; set; }
        public ICommand NavigateToAllianceCommand { get; set; }
        public ICommand NavigateToHordeCommand { get; set; }
        public ICommand NavigateToCreateAltCommand { get; set; }
        public ICommand CreateAltCommand { get; set; }

        #endregion

        #region ObservableCollections

        public ObservableCollection<JoinCharacter> CharacterList { get; set; }
        public ObservableCollection<JoinCharacter> CharacterListAlliance { get; set; }
        public ObservableCollection<JoinCharacter> CharacterListHorde { get; set; }

        #endregion

    }
}
