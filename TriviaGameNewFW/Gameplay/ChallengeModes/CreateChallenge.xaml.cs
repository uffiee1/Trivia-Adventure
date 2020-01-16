using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TriviaGameNewFW.Gameplay.ChallengeMode
{
    public sealed partial class CreateChallenge : Page
    {
        int PortNumber;
        readonly MySqlConnection conn = new MySqlConnection("Server = localhost; User Id = root; Password = ''; Database = triviadb");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        public DataSet ds = new DataSet();

        //db connection = new db();

        //List<ChallengeQuizInformation> QuizList = new List<ChallengeQuizInformation>();

        public CreateChallenge()
        {
            this.InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            adapter = new MySqlDataAdapter("UPDATE `challenge` SET `description` = '" + txtbxVraag.Text + "', `score`= '" + txtbxPoints.Text + "',`answer`= '" + txtbxD.Text + "', `wronganswer1`= '" + txtbxA.Text + "', `wronganswer2`='" + txtbxB.Text + "' `wronganswer3`= '" + txtbxC.Text + '"', conn);
            adapter.Fill(ds, "challenge(description, score, answer, wronganswer1, wronganswer2, wronganswer3)");
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            String vragenlijst = txtbxTitle.Text;
            String vragenlijst1 = txtbxVraag.Text;

            if (lbChallengeList.Items.Count < -1)
            {

            }
            else
            {
                lbChallengeList.Items.Add(vragenlijst);
                lbChallengeList.Items.Add(vragenlijst1);
            }

            ds = new DataSet();
            adapter = new MySqlDataAdapter("INSERT INTO challenge(QuizTitle, description, score, answer, wronganswer1, wronganswer2, wronganswer3) VALUES ('" + txtbxTitle.Text + "','" + txtbxVraag.Text + "','" + txtbxPoints.Text + "','" + txtbxD.Text + "','" + txtbxA.Text + "','" + txtbxB.Text + "','" + txtbxC.Text + "')", conn);
            adapter.Fill(ds);
            txtbxVraag.Text = "";
            txtbxA.Text = "";
            txtbxB.Text = "";
            txtbxC.Text = "";
            txtbxD.Text = "";

            if (cbPoints.IsChecked == true)
            {
                
            }
            else
            {
                txtbxPoints.Text = "";
            }
        }

        private void cbPoints_Checked(object sender, RoutedEventArgs e)
        {
            txtbxPoints.IsEnabled = false; 
        }

        private void cbPoints_Unchecked(object sender, RoutedEventArgs e)
        {
            txtbxPoints.IsEnabled = true;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Weet u zeker dat u deze vraag wilt vervijderen?");
            dialog.Commands.Add(new UICommand("Ja", delegate (IUICommand command)
            {
                ds = new DataSet();
                adapter = new MySqlDataAdapter("DELETE FROM challenge WHERE (`QuizTitle` `description` `score` `answer` `wronganswer1` `wronganswer2` `wronganswer3`) IS ('" + txtbxTitle.Text + "' '" + txtbxVraag.Text + "','" + txtbxPoints.Text + "','" + txtbxD.Text + "','" + txtbxA.Text + "','" + txtbxB.Text + "','" + txtbxC.Text + "')", conn);
                adapter.Fill(ds);
                
                txtbxVraag.Text = "";
                txtbxA.Text = "";
                txtbxB.Text = "";
                txtbxC.Text = "";
                txtbxD.Text = "";
                txtbxPoints.Text = "";
            }));
            dialog.Commands.Add(new UICommand("Nee", delegate (IUICommand command)
            {

            }));
            await dialog.ShowAsync();
        }

        private void QuizGetData()
        {
            //this.cbxQuizGames.Items.Add(conn);
            ds = new DataSet();
            string query = $"SELECT * FROM `challenge` WHERE `UserID`";
            adapter.Fill(ds);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PlayChallenge));   
        }

        //ServerPortKamer als Random aanmaken.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            PortNumber = Convert.ToInt32(e.Parameter);
            RoomPIN(PortNumber);
        }

        private void cbxQuiz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QuizGetData();
        }

        private void lbChallengeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtbxVraag.Text = lbChallengeList.SelectedItem.ToString();
            //txtbxTitle.Text = lbChallengeList.SelectedItem.ToString();
        }

        private void RoomPIN(int PortNumberGet)
        {
            txtbxServerPIN.Text = Convert.ToString(PortNumberGet);
        }

        //private void LoadQuestion()
        //{
        //    if (lbChallengeList.SelectedIndex != -1)
        //    {
        //        if (vragenlijst != null)
        //        {
        //            ChallengeQuizInformation challengeQuiz = QuizList.Find(StudentDieWeZoeken)
        //        }
        //        //ChallengeQuizInformation sellectedQuestion = 
        //    }
        //}     
    }


}
