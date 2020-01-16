using MySql.Data.MySqlClient;
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
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=triviadb;");

        public string Username { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }

        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        public int CategoryId { get; set; }

        public string ChapterID { get; set; }
        public string ChapterName { get; set; }
        public string ChapterDesc { get; set; }
        public string ChapterCat { get; set; }


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

        public async Task<UserInformation> TryLogin(string username, string password)
        {
            UserInformation CurrentUser = new UserInformation();
            string QueryString = $"SELECT* FROM `user` WHERE `username`= '{username}' AND `password`= '{password}'";

            MySqlCommand cmd = new MySqlCommand(QueryString, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CurrentUser.Username = reader.GetString("username");
                CurrentUser.Password = reader.GetString("password");
                CurrentUser.UserID = Convert.ToInt32(reader.GetString("id"));
            }
            con.Close();

            if (CurrentUser != null)
            {
                if (CheckEmpty(username))
                {
                    var dialog = new MessageDialog("Vul een gebruikersnaam in");
                    var res = await dialog.ShowAsync();

                    return null;
                    //textboxUsername.Focus(FocusState.Programmatic);
                }

                if (CheckEmpty(password))
                {
                    var dialog = new MessageDialog("Vul een wachtwoord in");
                    var res = await dialog.ShowAsync();

                    return null;
                    //textboxPassword.Focus(FocusState.Programmatic);
                }

                else if (username == CurrentUser.Username && password == CurrentUser.Password)
                {
                    return CurrentUser;
                }
            }
            else
            {
                var dialog = new MessageDialog("Onjuiste gegevens!");
                return null;
            }

            return null;

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

        public UserInformation CategoryInfo(string sqli)
        {
            UserInformation gameInfo = new UserInformation();

            MySqlCommand cmd = new MySqlCommand(sqli, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                gameInfo.CategoryName = reader.GetString("cat_name");
                gameInfo.CategoryId = reader.GetInt32("id");
                gameInfo.CategoryDesc = reader.GetString("cat_desc");
            }
            con.Close();
            return gameInfo;
        }

        public UserInformation ChapterInformation(string sqli)
        {

            UserInformation gameInfo = new UserInformation();

            MySqlCommand cmd = new MySqlCommand(sqli, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                gameInfo.ChapterName = reader.GetString("name");
                gameInfo.ChapterID = reader.GetString("id");
                gameInfo.ChapterDesc = reader.GetString("description");
                gameInfo.ChapterCat = reader.GetString("category");

            }
            con.Close();
            return gameInfo;
        }
    }
}
