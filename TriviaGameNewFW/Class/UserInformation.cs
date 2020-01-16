using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace TriviaGameNewFW
{
    class UserInformation
    {
        db connection = new db();

        public string Username { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }

        public UserInformation()
        {

        }
        public UserInformation(string GetUsername, string GetPassword)
        {
            Username = GetUsername;
            Password = GetPassword;

        }


        public string WelcomeMessage(string Username)
        {
                string message = "Welkom, " + Username + "!";
                return message;

        }

            public async Task<Boolean> TryLogin(string username, string password)
        {
            UserInformation LoginUser = connection.TryLogin($"SELECT * FROM `user` WHERE `username`='{username}' AND `password`='{password}'");

            if (LoginUser != null)
            {
                if (CheckEmpty(username))
                {
                    var dialog = new MessageDialog("Vul een gebruikersnaam in");
                    var res = await dialog.ShowAsync();

                    return false;
                    //textboxUsername.Focus(FocusState.Programmatic);
                }

                if (CheckEmpty(password))
                {
                    var dialog = new MessageDialog("Vul een wachtwoord in");
                    var res = await dialog.ShowAsync();

                    return false;
                    //textboxPassword.Focus(FocusState.Programmatic);
                }

                else if (username == LoginUser.Username && password == LoginUser.Password)
                {
                    return true;
                }
            }
            else
            {
                var dialog = new MessageDialog("Onjuiste gegevens!");
                return false;
            }

            return false;

        }

        private Boolean CheckEmpty(string ReadString)
        {
            if (ReadString.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
