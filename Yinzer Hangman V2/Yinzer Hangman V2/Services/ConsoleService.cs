using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinzer_Hangman_V2.Models;

namespace Yinzer_Hangman_V2.Services
{
    public class ConsoleService
    {   
        public void MainMenu()
        {
            Console.WriteLine("Hey yinz, gather 'round! We got ourselves a real n'at hangman game goin' on.");
            Console.WriteLine("It's a proper Pittsburgh puzzler, so grab yer pop, kick back, and let's see if yinz can guess the words.");
            Console.WriteLine("Ready to tackle this Pittsburgh hangman, ya jagoffs?");
            Console.WriteLine();
            Console.WriteLine("Yinz only got five chances to crack the code.Grab yer Terrible Towel, sit back, and let's see if yinz can unravel the mystery.");
            Console.WriteLine();
        }
        public string UserInput()
        {

        }
        public void DisplayGameResult(HangmanGameResult result)
        {

        }
        public void DrawHangman(int step)
        {
            Console.WriteLine();

            switch (step)
            {   //Case number = incorrect guess amount
                case 1:
                    Console.WriteLine("  ____ ");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |    O");
                    Console.WriteLine(" |    | ");
                    break;
                case 2:
                    Console.WriteLine("  ____ ");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |    O");
                    Console.WriteLine(" |   /|  ");
                    break;
                case 3:
                    Console.WriteLine("  ____ ");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |    O");
                    Console.WriteLine(" |   /|\\ ");
                    break;
                case 4:
                    Console.WriteLine("  ____ ");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |    O");
                    Console.WriteLine(" |   /|\\");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |   / ");
                    Console.WriteLine(" |");
                    break;
                case 5:
                    Console.WriteLine("  ____ ");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |    O");
                    Console.WriteLine(" |   /|\\");
                    Console.WriteLine(" |    |");
                    Console.WriteLine(" |   / \\");
                    Console.WriteLine(" |");

                    break;
                default:
                    Console.WriteLine("Invalid step number.");
                    break;
            }
        }
    }
}
