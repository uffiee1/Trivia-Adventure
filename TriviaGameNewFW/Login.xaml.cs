using System;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TriviaGameNewFW
{
    public sealed partial class MainPage : Page
    {
        private UserInformation LoginUser = new UserInformation();
        public MainPage()
        {
            this.InitializeComponent();
            PlaySound();
        }

        private async void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            string Username = textboxUsername.Text;
            string Password = textboxPassword.Password.ToString();

            UserInformation CheckLogin = await LoginUser.TryLogin(Username, Password);

            if (CheckLogin != null)
            {
                LoginUser.UserID = CheckLogin.UserID;
                LoginUser.Username = CheckLogin.Username;
  

                this.Frame.Navigate(typeof(MainMenu), LoginUser);
            }
        }

        private void PlaySound()
        {
            Uri newuri = new Uri("ms-appx:///Assets/trivia-music.wav");
            myPlayer.Source = newuri;
        }
        
    }
}
