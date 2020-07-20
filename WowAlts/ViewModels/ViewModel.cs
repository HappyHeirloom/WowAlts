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

            #endregion
        }
        
        #region ICommands

        public ICommand GoBackToHomeCommand { get; set; }
        public ICommand NavigateToAllianceCommand { get; set; }
        public ICommand NavigateToHordeCommand { get; set; }
        public ICommand NavigateToCreateAltCommand { get; set; }

        #endregion

        public ObservableCollection<JoinCharacter> CharacterList { get; set; }
        public ObservableCollection<JoinCharacter> CharacterListAlliance { get; set; }
        public ObservableCollection<JoinCharacter> CharacterListHorde { get; set; }
    }
}
