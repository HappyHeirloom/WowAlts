using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WowAlts.Views;
using WowAlts.Views.Alliance;
using WowAlts.Views.Horde;

namespace WowAlts.Handlers
{
    class NavigationHandler
    {
        private Frame frame => (Frame) ((Window.Current.Content));

        public void NavigateToHome()
        {
            frame.Navigate(typeof(MainPage), null);
        }

        public void NavigateToAlliance()
        {
            frame.Navigate(typeof(AllianceMainPage), null);
        }

        public void NavigateToHorde()
        {
            frame.Navigate(typeof(HordeMainPage), null);
        }

        public void NavigateToCreateAlt()
        {
            frame.Navigate(typeof(CreateAltPage), null);
        }
    }
}
