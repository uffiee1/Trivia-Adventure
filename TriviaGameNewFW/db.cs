using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace TriviaGameNewFW
{
    class db
    {
        MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=triviadb;");

        public UserInformation TryLogin(string QueryString)
        {
            UserInformation user = new UserInformation();

            MySqlCommand cmd = new MySqlCommand(QueryString, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                user.Username = reader.GetString("username");
                user.Password = reader.GetString("password");
                user.UserID = Convert.ToInt32(reader.GetString("id"));
            }
            con.Close();
            return user;
        }

        public List<string>CategoryNames(string sqli) 
        {
            List<string> lstemail = new List<string>();

            MySqlCommand cmd = new MySqlCommand(sqli, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lstemail.Add(reader.GetString("id"));
            }
            con.Close();
            return lstemail;
        }


        public List<string> SelectedCategory(string sqli) 
        {
            List<string> lstemail = new List<string>();

            MySqlCommand cmd = new MySqlCommand(sqli, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lstemail.Add(reader.GetString("id"));
            }
            con.Close();
            return lstemail;
        }
        public List<string> SelectedChapter(string sqli)
        {
            List<string> lstemail = new List<string>();

            MySqlCommand cmd = new MySqlCommand(sqli, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lstemail.Add(reader.GetString("id"));
            }
            con.Close();
            return lstemail;
        }
        public List<string> SelectedQuestions(string sqli)
        {
            List<string> Questions = new List<string>();

            MySqlCommand cmd = new MySqlCommand(sqli, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Questions.Add(reader.GetString("id"));
            }
            con.Close();
            return Questions;
        }


        public void insertScore(int id, string score) 
        {
            string sqlQuery = $"UPDATE user SET score = "+score+" WHERE id ="+id+"";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            con.Close();
        }



        public List<string> QuizInfo(string sqli)
        {
            List<string> lstemail = new List<string>();

            QuizInformation quizInfo = new QuizInformation();

            MySqlCommand cmd = new MySqlCommand(sqli, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                quizInfo.QuizName = reader.GetString("name");
                lstemail.Add(reader.GetString("name"));
                quizInfo.QuizDesc = reader.GetString("description");
            }
            con.Close();
            return lstemail;
        }

        public List<PlayInformation> PlayInfo(string sqli)
        {
            List<PlayInformation> roomList = new List<PlayInformation>();

            MySqlCommand cmd = new MySqlCommand(sqli, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                roomList.Add(new PlayInformation()
                {
                    PlayQuestion = reader.GetString("description"),
                    PlayScore = reader.GetInt32("score"),

                    WrongAnswer1 = reader.GetString("a"),
                    WrongAnswer2 = reader.GetString("b"),
                    WrongAnswer3 = reader.GetString("c"),
                    WrongAnswer4 = reader.GetString("d"),

                    ChapterCategory = reader.GetString("category"),
                    ChapterID = reader.GetString("chapter"),

                    Answer = reader.GetString("answer")
                }
                );
            }
            con.Close();
            return roomList;
        }

        //public ChallengeQuizInformation ChallengeInfo(string sqli)
        //{
        //    List<ChallengeQuizInformation> QuizList = new List<ChallengeQuizInformation>();

        //}
    }
}
