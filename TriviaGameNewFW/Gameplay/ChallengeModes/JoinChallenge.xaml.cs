﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TriviaGameNewFW.Gameplay.ChallengeMode
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class JoinChallenge : Page
    {
        public JoinChallenge()
        {
            this.InitializeComponent();
        }

        private void btnJoinChallenge(object sender, RoutedEventArgs e)
        {
            //if (txbxPIN.Text == txtbxServerPIN.Text = Convert.ToString(PortNumberGet);)
            //{
            this.Frame.Navigate(typeof(JoinChallengePlay));
            //}
        }
    }
}