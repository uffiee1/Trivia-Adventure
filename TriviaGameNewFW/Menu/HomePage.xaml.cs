using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using Windows.UI.Xaml.Controls;

namespace TriviaGameNewFW.Menu
{
    public sealed partial class HomePage : Page
    {
        readonly MySqlConnection conn = new MySqlConnection("Server = localhost; User Id = root; Password = ''; Database = triviadb");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        public DataSet ds = new DataSet();

        db connection = new db();

        public HomePage()
        {
            this.InitializeComponent();
            Leaderboard();
        }

        private void Leaderboard()
        {
            string QueryString = $"SELECT `username`,`score` FROM `user` ORDER BY score DESC LIMIT 6";

            MySqlCommand cmd = new MySqlCommand(QueryString, conn);

            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            var name = new List<string>();
            var score = new List<string>();


            while (reader.Read())
            {

                name.Add(reader.GetString("username"));
                score.Add(reader.GetString("score"));


            }
            
            txbxLeaderName1.Text = name[0];
            txbxLeaderName2.Text = name[1];

            txbxLeaderName3.Text = name[2];
            txbxLeaderName4.Text = name[3];

            txbxLeaderName5.Text = name[4];
            txbxLeaderName6.Text = name[5];

            txbxLeaderPoints1.Text = score[0];
            txbxLeaderPoints2.Text = score[1];

            txbxLeaderPoints3.Text = score[2];
            txbxLeaderPoints4.Text = score[3];

            txbxLeaderPoints5.Text = score[4];
            txbxLeaderPoints6.Text = score[5];




            conn.Close();
        }
    }
}