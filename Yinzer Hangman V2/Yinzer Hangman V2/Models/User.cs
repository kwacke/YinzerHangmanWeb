using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yinzer_Hangman_V2.Models
{
    public class User
    {
        private int Incorrect { get; set; } = 0;
        private int Correct { get; set; } = 0;
        private bool HasLetter { get; set; } = false;
        private string Answer { get; set; } = string.Empty;
        public User(int incorrect, int correct, bool hasLetter, string answer)
        {
            Incorrect = incorrect;
            Correct = correct;
            HasLetter = hasLetter;
            Answer = answer;
        }

    }
}
