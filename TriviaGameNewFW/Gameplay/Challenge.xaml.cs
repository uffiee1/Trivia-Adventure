using System;
using TriviaGameNewFW.Gameplay.ChallengeMode;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TriviaGameNewFW
{
    public sealed partial class Challange : Page
    {
        int b;

        public Challange()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //KamerPortNummer
            base.OnNavigatedTo(e);
                 b = Convert.ToInt32(e.Parameter);
        }

        private void btnCreateChallenge(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateChallenge), b);
        }

        private void btnJoinChallenge(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(JoinChallenge), b);
        }
    }
}
