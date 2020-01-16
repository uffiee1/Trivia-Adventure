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
        {//string v_role
            this.InitializeComponent();
            //txtbxUserRole.Text = v_role;
            //SetRoles();
            
        }

        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=triviadb;");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        public DataSet ds = new DataSet();
        MySqlDataReader reader;
        




        private async void SetRoles()
        {
            try
            {

            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                var res = await dialog.ShowAsync();
                con.Close();
            }
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
            LoggedUserText.Text = CurrentUser.WelcomeMessage(Convert.ToString(e.Parameter));
        }
        public void NavigationViewControl_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            string ItemContent = args.InvokedItem.ToString();

            if (ItemContent != null)
            {
                switch (ItemContent)
                {
                    case "Adventure":
                        contentFrame.Navigate(typeof(Menu.Adventure));
                        break;

                    case "Multiplayer":
                        contentFrame.Navigate(typeof(Menu.Multiplayer));
                        break;

                    case "Settings":
                        contentFrame.Navigate(typeof(Menu.Settings));
                        break;

                    case "Help":
                        contentFrame.Navigate(typeof(Menu.Help));
                        break;

                    case "Homepage":
                        contentFrame.Navigate(typeof(Menu.HomePage));
                        break;

                    case "Profile":
                        contentFrame.Navigate(typeof(Menu.Profile));
                        break;

                    case "Logout":
                        contentFrame.Navigate(typeof(Menu.Logout));
                        break;
                }
            }

        }
        #endregion
    }
}
