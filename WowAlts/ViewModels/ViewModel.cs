using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

            NavigateToAllianceCommand = new RelayCommand(_nav.NavigateToAlliance, null);
            NavigateToHordeCommand = new RelayCommand(_nav.NavigateToHorde, null);

            #endregion
        }



        #region ICommands

        public ICommand NavigateToAllianceCommand { get; set; }
        public ICommand NavigateToHordeCommand { get; set; }

        #endregion

        public ObservableCollection<Character> CharacterList { get; set; }
        public ObservableCollection<Character> CharacterListAlliance { get; set; }
        public ObservableCollection<Character> CharacterListHorde { get; set; }
    }
}
