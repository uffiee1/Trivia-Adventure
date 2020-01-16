using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MySql.Data.MySqlClient;
using System.Data;
using Windows.UI.Popups;

namespace TriviaGameNewFW
{
    public sealed partial class MainMenu : Page
    {
        UserInformation CurrentUser = new UserInformation();
        public MainMenu()
        {
            this.InitializeComponent();
            
            
        }

        #region NavigationView event 

        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("Homepage", typeof(Menu.HomePage)),
            ("Adventure", typeof(Menu.Adventure)),
            ("Multi Player", typeof(Menu.Multiplayer)),
            ("Settings", typeof(Menu.Settings)),
            ("Profile", typeof(Menu.Profile)),
            ("Logout", typeof(Menu.Logout)),
            ("Help", typeof(Menu.Help)),
        };

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CurrentUser = e.Parameter as UserInformation;
            LoggedUserText.Text = CurrentUser.Username;

        }
        public void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            string ItemContent = args.InvokedItem.ToString();

            if (ItemContent != null)
            {
                switch (ItemContent)
                {
                    case "Adventure":
                        contentFrame.Navigate(typeof(Menu.Adventure),CurrentUser);
                        break;

                    case "Multiplayer":
                        contentFrame.Navigate(typeof(Menu.Multiplayer), CurrentUser);
                        break;

                    case "Settings":
                        contentFrame.Navigate(typeof(Menu.Settings), CurrentUser);
                        break;

                    case "Help":
                        contentFrame.Navigate(typeof(Menu.Help), CurrentUser);
                        break;

                    case "Homepage":
                        contentFrame.Navigate(typeof(Menu.HomePage), CurrentUser);
                        break;

                    case "Profile":
                        contentFrame.Navigate(typeof(Menu.Profile), CurrentUser);
                        break;

                    case "Logout":
                        contentFrame.Navigate(typeof(Menu.Logout), CurrentUser);
                        break;
                }
            }

        }
        #endregion
    }
}
