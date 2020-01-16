using System;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TriviaGameNewFW
{
    public sealed partial class MainPage : Page
    {
        MediaPlayer player;
        private UserInformation LoginUser = new UserInformation();
        public MainPage()
        {
            this.InitializeComponent();
            //player = new MediaPlayer();
            PlaySound();
        }

        private async void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            //BackgroundMediaPlayer.Current.SetUriSource(new Uri("../Assets/trivia-music.wav"));
            //BackgroundMediaPlayer.Current.Play();

            //Windows.Storage.StorageFolder storageFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFoldersAsync(@"Assets");
            //Windows.Storage.StorageFile file = await folder.GetFilesAsync("trivia-music.wav");
            //player.AutoPlay = true;
            //player.Source = MediaSource.CreateFromStorageFile(file);
            //player.Play();



            string Username = textboxUsername.Text;
            string Password = textboxPassword.Password.ToString();

            bool CheckLogin = await LoginUser.TryLogin(Username, Password);

            if (CheckLogin)
            {
                this.Frame.Navigate(typeof(MainMenu), Username);
            }
        }

        private void PlaySound()
        {
            Uri newuri = new Uri("ms-appx:///Assets/trivia-music.wav");
            myPlayer.Source = newuri;
        }
        
    }
}
