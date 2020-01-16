using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TriviaGameNewFW
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Quiz : Page
    {


        int buttonCounter = 0;
        private GameInformation catInfo { get; set; }
        db connection = new db();
        List<string> Chapters = new List<string>();
        public ChapterInformation playableChapters = new ChapterInformation();


        public Quiz()
        {
            this.InitializeComponent();
        }

      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        { 
            //Question
            base.OnNavigatedTo(e);
            try
            {
                catInfo = e.Parameter as GameInformation;
                TextBlockQuiz.Text = catInfo.CategoryDesc;
                playableChapters.ChapterCat = Convert.ToString(catInfo.CategoryID);
                ShowChapters(catInfo.CategoryID);
            }
            catch (Exception)
            {

                
            }
            

        }

        void ShowChapters(string CategoryName)
        {
            //All chapters that are connected to a category
            Chapters = connection.QuizInfo($"SELECT * FROM `chapter` WHERE `category` = "+ CategoryName);


            foreach (string item in Chapters)
            {
                if (item != "Button")
                {

                    //Create the button
                    Button b = new Button();
                    b.Height = 50;
                    b.Width = 300;
                    b.Background = new SolidColorBrush(Colors.Azure);
                    b.VerticalAlignment = VerticalAlignment.Top;
                    b.HorizontalAlignment = HorizontalAlignment.Left;
                    b.Margin = new Thickness(20, buttonCounter*100, 0, 0);
                    b.Name = item;
                    b.Content = item;
                    b.Click += new RoutedEventHandler(Quiz_Click);



                    //Calculate the place of the button
                    int column = (int)(buttonCounter / 4);
                    int row = buttonCounter % 4;

                    //Check if you need to add a columns
                    if (row == 0)
                    {
                        ColumnDefinition col = new ColumnDefinition();
                        col.Width = new GridLength(column, GridUnitType.Auto);
                        Hoofdstukken.ColumnDefinitions.Add(col);
                    }

                    //Add the button
                    Hoofdstukken.Children.Add(b);
                    Grid.SetColumn(b, column);
                    Grid.SetRow(b, row);
                    buttonCounter++;
                }


            }
            
        }
        public void Quiz_Click(object sender, RoutedEventArgs e)
        {
            //Als er op een Chapter word geklikt

            Button btn = sender as Button; 
            string v = Convert.ToString(btn.Content);

            ChapterInformation playableChapters = connection.GameInfo($"SELECT * FROM `chapter` WHERE `category` = " + catInfo.CategoryID + " AND `name` = '" + v+"'");
            playableChapters.ChapterCat = catInfo.CategoryID;

            this.Frame.Navigate(typeof(Game.PlayGame),playableChapters);
            

        }

    }
}
