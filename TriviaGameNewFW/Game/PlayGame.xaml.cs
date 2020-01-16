using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TriviaGameNewFW.Game
{
    public sealed partial class PlayGame : Page
    {
        db connection = new db();
        private ChapterInformation playableChapters { get; set; }
        public PlayInformation Questions { get; set; }
        public List<string> ListQuestions = new List<string>();
        List<PlayInformation> ObjectQuestions = new List<PlayInformation>();
        int questionNumber = 0;
        int answered = 0;
        PlayInformation ReadyQuestions;
        int score = 0;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            playableChapters = e.Parameter as ChapterInformation;
            QuestionHolderText.Text = playableChapters.ChapterName;
            ListQuestions = connection.SelectedQuestions($"SELECT id FROM `question` WHERE `category` =" + playableChapters.ChapterCat + " AND `chapter`=" + playableChapters.ChapterID + " ORDER BY RAND()");
            GetQuestions();
        }

        public PlayGame()
        {
            this.InitializeComponent();
        }

        async void GetQuestions()
        {
            if (questionNumber < 10)
            {
                try
                {
                    ObjectQuestions = connection.PlayInfo($"SELECT * FROM `question` WHERE `category` = " + playableChapters.ChapterCat + " AND `chapter`= " + playableChapters.ChapterID);
                    ShowQuestions(answered);
                }
                catch (Exception)
                {
                }
            }
            else
            {
                var dialog = new MessageDialog("Je bent klaar met de eerste quiz", "Dank u voor het spelen!");
                var res = await dialog.ShowAsync();
                this.Frame.Navigate(typeof(Quiz), playableChapters);
            }
        }
        public void ShowQuestions(int CurrentQuestion)
        {
            try
            {
                ReadyQuestions = ObjectQuestions[questionNumber];
                QuestionHolderText.Text = ReadyQuestions.PlayQuestion;
                A.Content = ReadyQuestions.WrongAnswer1;
                B.Content = ReadyQuestions.WrongAnswer2;
                C.Content = ReadyQuestions.WrongAnswer3;
                D.Content = ReadyQuestions.WrongAnswer4;
            }
            catch (Exception)
            {
            }
        }

        private async void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            string ValueButton = Convert.ToString(btn.Content);
            string ButtonPressed = Convert.ToString(btn.Name);

            if (ReadyQuestions.Answer == ValueButton)
            { 
                AnswerCheck(ValueButton, ButtonPressed,true);
                await Task.Delay(TimeSpan.FromSeconds(1));

                score = score + ReadyQuestions.PlayScore;

                QuizScore.Text = Convert.ToString(score);
                questionNumber++;

                GetQuestions();
                clearButtons();
            }
            else
            {
                AnswerCheck(ValueButton, ButtonPressed, false);
                await Task.Delay(TimeSpan.FromSeconds(1));
                score = score - ReadyQuestions.PlayScore;
                QuizScore.Text = Convert.ToString(score);
                questionNumber++;

                GetQuestions();
                clearButtons();

            }

        }
        void clearButtons()
        {
            A.Background = new SolidColorBrush(Colors.Azure);
            B.Background = new SolidColorBrush(Colors.Azure);
            C.Background = new SolidColorBrush(Colors.Azure);
            D.Background = new SolidColorBrush(Colors.Azure);

        }
        void AnswerCheck(string ButtonValue, string PressedButton, bool Good)
        {
            switch (PressedButton)
            {
                case "A":
                    if (Good)
                    {
                        A.Background = new SolidColorBrush(Colors.Green);

                    }
                    else
                    {
                        A.Background = new SolidColorBrush(Colors.DarkRed);

                    }
                    break;
                case "B":
                    if (Good)
                    {
                        B.Background = new SolidColorBrush(Colors.Green);

                    }
                    else
                    {
                        B.Background = new SolidColorBrush(Colors.DarkRed);

                    }
                    break;
                case "C":
                    if (Good)
                    {
                        C.Background = new SolidColorBrush(Colors.Green);

                    }
                    else
                    {
                        C.Background = new SolidColorBrush(Colors.DarkRed);

                    }
                    break;
                case "D":
                    if (Good)
                    {
                        D.Background = new SolidColorBrush(Colors.Green);

                    }
                    else
                    {
                        D.Background = new SolidColorBrush(Colors.DarkRed);

                    }
                    break;
                default:
                    break;
            }
        }
     }
}
