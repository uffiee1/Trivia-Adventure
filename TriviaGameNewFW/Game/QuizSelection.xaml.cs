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
        private UserInformation userInformation { get; set; }

        UserInformation ChosenChapters = new UserInformation();

        List<string> Chapters = new List<string>();

        db con = new db();

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
                userInformation = e.Parameter as UserInformation;
                userInformation.ChapterCat = Convert.ToString(userInformation.CategoryId);
                ShowChapters(Convert.ToString(userInformation.CategoryId));
            }
            catch (Exception)
            {   
            }
        }

        void ShowChapters(string CategoryName)
        {
            //All chapters that are connected to a category
            Chapters = con.QuizInfo($"SELECT * FROM `chapter` WHERE `category` = "+ CategoryName);


            foreach (string item in Chapters)
            {
                if (item != "Button")
                {

                    //Create the button
                    Button b = new Button();
                    b.Height = 50;
                    b.Width = 300;
                    b.Style = Application.Current.Resources["AdventureButtonName"] as Style;

                    b.VerticalAlignment = VerticalAlignment.Top;
                    b.HorizontalAlignment = HorizontalAlignment.Left;
                    b.Margin = new Thickness(20, buttonCounter*100, 0, 0);
                    b.Name = item + "/n" + userInformation.CategoryDesc;
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
            Button btn = sender as Button; 
            string v = Convert.ToString(btn.Content);

            UserInformation playableChapters = ChosenChapters.ChapterInformation($"SELECT * FROM `chapter` WHERE `category` = " + userInformation.CategoryId + " AND `name` = '" + v+"'");

            userInformation.ChapterCat = Convert.ToString(userInformation.CategoryId);
            userInformation.ChapterName = playableChapters.ChapterName;
            userInformation.ChapterID = playableChapters.ChapterID;
            userInformation.ChapterDesc = playableChapters.ChapterDesc;

            this.Frame.Navigate(typeof(Game.PlayGame),userInformation);
            

        }

    }
}
