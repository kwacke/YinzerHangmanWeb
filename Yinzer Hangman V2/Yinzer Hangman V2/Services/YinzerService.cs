using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinzer_Hangman_V2.Models;

namespace Yinzer_Hangman_V2.Services
{
    public class YinzerService
    {
       private HangmanWord currentWord;
       private User user;
       private ConsoleService ConsoleService;

        public YinzerService(ConsoleService consoleService)
        {
            this.ConsoleService = consoleService;
            // other intialization logic 
        }
        public void StartGame()
        {
            //Logic to start a new game
            int incorrect = 0;
            int correct = 0;
            bool hasLetter = false;
            string playAgain;
            string answer = "";

            //initialize currentWord and user

        }
        public HangmanGameResult MakeGuess(string guess)
        {
            // Logic to handle user's guess
            // Return HangmanGameResult indicating whether the game is won or lost
        }
        

    }
}
