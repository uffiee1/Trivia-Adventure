using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Net;
using System.Net.Sockets;
using TriviaGameNewFW.Gameplay;

namespace TriviaGameNewFW.Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Multiplayer : Page
    {
        public Multiplayer()
        {
            this.InitializeComponent();
        }

        ///////////Dit is voor Extra Feature (Leaderboard)////////////
        //public async void btnTest(object sender, RoutedEventArgs e)
        //{
        //    FreeTcpPort();
        //    var dialog = new MessageDialog("Mutiplayer!");
        //    var res = await dialog.ShowAsync();
        //}

        private void btnChallenge(object sender, RoutedEventArgs e)
        {
            int i = FreeTcpPort();
            this.Frame.Navigate(typeof(Challange),(i));
        }

        public static int FreeTcpPort()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
    }
}
