using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TriviaGameNewFW.Menu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Adventure : Page
    {
        public int buttonCounter;
        db connection = new db();
        List<string> Category = new List<string>();
        public Adventure()
        {
            this.InitializeComponent();
            ShowCategory();
        }

        void ShowCategory()
        {
            Category = connection.CategoryNames($"SELECT id FROM `category`");

            for (var i = 0; i < Category.Count; i++)
            {
                GameInformation catInfo= connection.CategoryInfo($"SELECT * FROM `category` WHERE `id` ="+ Category[i]);

                //Create the button
                Button b = new Button();
                b.Height = 30;
                b.Width = 200;
                b.VerticalAlignment = VerticalAlignment.Top;
                b.HorizontalAlignment = HorizontalAlignment.Left;
                b.Margin = new Thickness(20, 20, 0, 0);
                b.Background = new SolidColorBrush();
                b.Name = Convert.ToString(catInfo.CategoryID);
                b.Content = Convert.ToString(catInfo.CategoryName);
                b.Click += new RoutedEventHandler(Category_Click);

                int column = (int)(buttonCounter / 4);
                int row = buttonCounter % 4;

                if (row == 0)
                {
                    ColumnDefinition col = new ColumnDefinition();
                    col.Width = new GridLength(column, GridUnitType.Auto);
                    myGrid.ColumnDefinitions.Add(col);
                }

                myGrid.Children.Add(b);
                Grid.SetColumn(b, column);
                Grid.SetRow(b, row);
                buttonCounter++;
            }
        }

        public void Category_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button ;
            
            Quiz theNewForm = new Quiz();

            GameInformation catInfo = connection.CategoryInfo($"SELECT * FROM `category` WHERE `id` =" + btn.Name);

            this.Frame.Navigate(typeof(Quiz), catInfo);

        }
        
       
    }
}
