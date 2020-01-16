using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TriviaGameNewFW.Class
{
    class NavClass
    {
        

        

        public string ShowUsername(string Username)
        {
            string message = "Welkom, " + Username + "!";
            return message;

        }
    }
}
