using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGameNewFW
{
    class ChallengeQuizInformation
    {
        public int id { get; set; }
        public string description { get; set; }
        public string Answer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
        public string PlayQuestion { get; set; }
        public int PlayScore { get; set; }
    }
}
