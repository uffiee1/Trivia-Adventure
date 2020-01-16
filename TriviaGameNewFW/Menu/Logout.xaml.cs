using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TriviaGameNewFW.Menu
{
    public sealed partial class Logout : Page
    {
        public Logout()
        {
            this.InitializeComponent();
            Uitloggen();
        }

        private async void Uitloggen()
        {
            var dialog = new MessageDialog("Weet u zeker dat u wilt uitloggen?");
            dialog.Commands.Add(new UICommand("Ja", delegate (IUICommand command)
            {
                Application.Current.Exit();
            }));
            dialog.Commands.Add(new UICommand("Nee", delegate (IUICommand command)
            {
            }));
            await dialog.ShowAsync();
        }
    }
}
