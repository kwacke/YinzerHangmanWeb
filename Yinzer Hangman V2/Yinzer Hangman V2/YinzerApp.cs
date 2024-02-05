using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yinzer_Hangman_V2.Models;
using Yinzer_Hangman_V2.Services;

namespace Yinzer_Hangman_V2
{
    public class YinzerApp
    {
        static void Run(string[] args)
        {

            Console.WriteLine("Hey yinz, gather 'round! We got ourselves a real n'at hangman game goin' on.");
            Console.WriteLine("It's a proper Pittsburgh puzzler, so grab yer pop, kick back, and let's see if yinz can guess the words.");
            Console.WriteLine("Ready to tackle this Pittsburgh hangman, ya jagoffs?");
            Console.WriteLine();
            Console.WriteLine("Yinz only got five chances to crack the code.Grab yer Terrible Towel, sit back, and let's see if yinz can unravel the mystery.");
            Console.WriteLine();

            Dictionary<string, string> yinzWords = IntializeWords();

            int incorrect = 0;
            int correct = 0;
            bool hasLetter = false;
            string playAgain;
            string answer = "";

            do
            {
                answer = GetRandomWord(yinzWords);
                //I asked the internet how to do this, a ternary that checks if its a letter and the asterisk to replace the letters or leaves the space/character
                string hidden = HideWord(answer);

                DisplayWordHint(answer, hidden);
                // makes sure that you haven't guessed the word or run out of guesses
                while (hidden.Contains('*') && incorrect < 5)
                {
                    string guess = GetUserGuess(answer, hidden);

                  if (IsFullWordGuess(guess, answer))
                    {
                        HandleFullWordGuess(answer, hidden);
                        break;
                    }
                    // User chose not to play again, exit the screen.ea
                    else if (IsSingleLetterGuess(guess))
                    {
                        HandleSingleLetterGuess(answer, ref hidden, ref hasLetter, ref incorrect);
                    }

                }
                DisplayGameOutcome(hidden, incorrect);
                playAgain = AskToPlayAgain();

                // this loop condition is needed to start the game over again after selecting yes to play again
                if (playAgain.ToLower() == "y" || playAgain.ToLower() == "yes")
                {
                    ResetGameVariables(ref correct, ref incorrect, ref hasLetter, ref answer);
                }
                else if (playAgain.ToLower() == "n" || playAgain.ToLower() == "no")
                {
                    Console.WriteLine("Thanks for playng, see yinz next time!");
                    break;
                }
                else
                {
                    HandleInvalidPlayAgainInput();
                }

            } while (playAgain.ToLower()== "y" || playAgain.ToLower()=="yes");
        // Method to call for drawing a hangman as you make incorrect guesses in the game

            // Originally had an array, I decided on the dictionary so that the key could hold the hints for the word
        static Dictionary<string, string> IntializeWords()
            {

                Dictionary<string, string> yinzWords = new Dictionary<string, string>
            {
            {"Yinz", "Pittsburghese pronoun"},
            {"Clahdy", "Weather-related term"},
            {"Jagoff", "Pittsburgh insult"},
            {"Dahntahn", "Downtown"},
            {"Grahnd bees", "Yellow jacket bees in the ground"},
            {"Rahn-da-baht", "Song by the group yes or slang for a long way of getting to your destination"},
            {"Slippy", "Icy"},
            {"Gumband", "Rubber band"},
            {"Seent", "Seen it"},
            {"Cousint", "Cousin"},
            {"Friggin", "Vulgar slang"},
            {"Crick", "Small stream or creek"},
            {"Irn", "Short for Iron City Beer"},
            {"Worsh", "Wash"},
            {"Sweeper", "Vacuum cleaner"},
            {"Spickett", "Outdoor water faucet"},
            {"Prolly", "Probably"},
            {"Zak same", "Exactly the same"},
            {"Lahsy", "Lousy"},
            {"Jagger bush", "Thorny bush or plant"},
            {"Up air", "Up there"},
            {"Da-Boat-a-ya", "The both of you"},
            {"Nebby", "Nosy"},
            {"N'at", "And that"},
            {"Gutchies", "Underwear"},
            {"Buggy", "Shopping cart"},
            {"Jumbo", "Bologna"},
            {"Chipped-Chopped ham", "Isaly's was famous for this!"},
            {"Red Up", "Clean up"},
            {"Jeet Jet?", "Did you eat yet?"},
            {"Dippy Eggs", "Sunny-side-up eggs"},
            {"Pop", "Soda"},
            {"Canipshun", "Conniption"},
            {"Sammitches", "Sandwiches"},
            {"Ahnno-dat", "I don't know that"},
            {"A whole nother", "A whole other"},
            { "Airyago", "There you go"},
            {"Apost tu", "Supposed too"},
            {"Back'air", "Back there"},
            {"Bo fuss", "Both of us"},
            {"Bowchyins", "Both of you"},
            {"Buy Sam a drink and get his dog one too!", "Mike Lang Slang"},
            {"Can a corn", "Easy catch in baseball"},
            {"Choobinuptoo", "What have you been up to?"},
            {"Cole-daht-dare", "It's cold outside"},
            {"Come mere", "Come here"},
            {"Dahn nair", "Down there"},
            {"Daht'et", "That it"},
            {"Don't go err wit me", "Don't argue with me"},
            {"Dooder Jobs", "Do their jobs"},
            {"Elvis has left the building", "The show is over"},
            {"Hafta", "Have to"},
            {"Hauscome", "How has it come"},
            {"Hay Bir Here", "Hey beer here"},
            {"How's come?", "Why is that?"},
            {"Ize", "I am"},
            {"Ja Wanna", "Do you want to"},
            {"Jano?", "Do you know?"},
            {"Jeez-o-man", "Expression of surprise"},
            {"Kennywood's Open", "The zipper on your pants is open"},
            {"Lassnite", "Last night"},
            {"Like iss", "Like this"},
            {"Like 'at", "Like that"},
            {"Nuh-uh!!", "No"},
            {"Oh call Arnold Slick from Turtle Crick!", "Expression of surprise"},
            {"Oh mah gersh!", "Oh my gosh!"},
            {"Ovaderr", "Over there"},
            {"Same difference", "No difference"},
            {"Scratch my back with a hacksaw!", "Mike Lang Slang"},
            {"Sick'n tard", "Sick and tired"},
            {"Sposda", "Supposed to"},
            {"bungals", "Slang for Cincinatti's football team"},
            {"brahns", "Brown shoes"},
            {"Ya Gatta Regatta!", "You have to attend the regatta"}
            };
                return yinzWords;
            }

            static string GetRandomWord(Dictionary<string, string> wordDictionary)
            {
                //Selects random KVP from our Dictionary and take the key and turn it into string answer
                var random = new Random();
                var selectedWord = wordDictionary.ElementAt(random.Next(wordDictionary.Count));
                return selectedWord.Key;
            }
            static string HideWord(string word)
            {
                return new string(word.Select(c => Char.IsLetter(c) ? '*' : c == ' ' || c == '\'' || c == '-' || c == ',' || c == '?' || c == '.' ? c : ' ').ToArray());
            }
            static void DisplayWordHint(string word, string hidden)
            {
                //Console.WriteLine($"Your word is {hidden}!");
                Console.WriteLine($"Hint: {wordDictionary[word]}: {hidden}");
                Console.WriteLine();
                Console.WriteLine($"The word is {word.Length} letters");
                Console.WriteLine();
            }
            static string GetUserGuess(string answer, string hidden)
            {
                Console.WriteLine();
                Console.WriteLine("Take a shot at guessin' a letter, 'er if yinz know it, spell out the whole word, 'er whatever");
                return Console.ReadLine();
            }
            static bool IsSingleLetterGuess(string guess)
            {
                return guess.Length == 1;
            }
            static bool IsFullWordGuess(string guess, string answer)
            {
                return guess.Length > 1 && guess.Length == answer.Length;
            }
            static void HandleFullWordGuess(string answer, string hidden)
            {
                string guess = GetUserGuess(answer, hidden);
                string filteredGuess = filteredGuess(guess);
                string filteredAnswer = filteredAnswer(answer);

                if (filteredGuess == filteredAnswer)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Da answer is {answer}");
                    Console.WriteLine();
                    Console.WriteLine("You's won the game!");
                    Console.WriteLine();
                    Environment.Exit(0); // Exit since they have won and the game is over. used to be break but this is needed now since outside of loop within method
                }
                else
                {
                    Console.WriteLine("I'm sorry, that was an incorrect guess!");
                    Console.WriteLine($"{hidden}");
                    DrawHangman(incorrect);
                }
            }
            static string FilterGuess(string guess)
            {
                return new string(guess.ToLower().Where(c => Char.IsLetter(c) || c == ' ' || c == '\\' || c == '-' || c == ',' || c == '?' || c == '.' || c == '!').ToArray());
            }
            static string FilterAnswer(string answer)
            {
                return new string(answer.ToLower().Where(c => Char.IsLetter(c) || c == ' ' || c == '\\' || c == '-' || c == ',' || c == '?' || c == '.' || c == '!').ToArray());
            }
            static void HandleSingleLetterGuess(string answer, ref string hidden, ref bool hasLetter, ref int incorrect)
            {
                string guess = GetUserGuess(answer, hidden);

                //if they guess incorrectly respond and increment the incorrect variable
                if (!answer.ToLower().Contains(char.ToLower(guess[0])))
                {
                    Console.WriteLine();
                    Console.WriteLine("The word ain't gat that letter!");
                    incorrect++;
                    DrawHangman(incorrect);
                    Console.WriteLine();
                    Console.WriteLine($"Yinz made {incorrect} tries, 'n'at. Still got {5 - incorrect} tries left, y'know.");
                    Console.WriteLine();
                    Console.WriteLine($"{hidden}");
                    if (incorrect == 5)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Game over.");
                        Console.WriteLine();
                    }
                }
                else
                {
                    //number of times a letter appears in a word, in case more than once
                    int numberOfTimes = 0;

                    /* create a CharArray to hold letters asterisk and reveal them 
                     as we loop through the length of answer checking if the guesses are in each index
                    position of answer*/

                    char[] reveal = hidden.ToCharArray();

                    for (int i = 0; i < answer.Length; i++)
                    {
                        // this checks if your guess is in the word
                        // then reveals that letter as many times as it appears in the word
                        if ((char.ToLower(guess[0]) == char.ToLower(answer[i])))
                        {
                            hasLetter = true;
                            numberOfTimes++;

                            if (!hidden.Contains(char.ToLower(guess[0])))
                            {
                                reveal[i] = answer[i];
                            }
                        }
                    }
                    Console.WriteLine();
                    // if you guess correctly and haven't guessed all of the letters

                    /* I added the number of times so that if the letter appears multiple
                    in the word, it will only Console.WriteLine one time */
                    if (hasLetter)
                    {
                        Console.WriteLine("Spot on, n'at!");
                        Console.WriteLine();
                        hidden = new string(reveal);
                        Console.WriteLine($"{hidden}!");
                    }
                    //correct = hidden.Count(c => c != '*' && char.IsLetter(c));

                    //if (correct == answer.Where(char.IsLetter).Distinct().Count())
                    if (!hidden.Contains("*"))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Yinz win!");
                        Console.WriteLine();
                        Console.WriteLine($"Yer word is {answer}");
                        Environment.Exit(0);
                    }
                }
            }
        }
        static void DrawHangman(int step)
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
        static void DisplayGameOutcome(string hidden, int incorrect)
        {
            if (hidden.Contains('*') && incorrect == 5)
            {
                Console.WriteLine();
                Console.WriteLine("Game over, ya Jag.");
                Console.WriteLine();
            }
        }
        static string AskToPlayAgain()
        {
            // This runs after you have guessed the word or have ran out of guesses

            Console.WriteLine("Yinz wanna play again?");
            Console.WriteLine();
            Console.WriteLine("Jus' type in Y or Yes if yinz wanna play again, 'n if yinz had enough, type N or No to exit, y'know");
            Console.WriteLine();
            return Console.ReadLine();
        }
        static void HandleInvalidPlayAgainInput()
        {
            Console.WriteLine("I'm sorry 'n'at, but could yinz please enter a Y to play again or an N to exit, jagoff");
            Console.WriteLine();
            AskToPlayAgain();
        }
        static void ResetGameVariables(ref int correct, ref int incorrect, ref bool hasLetter, ref string answer)
        {
            correct = 0;
            incorrect = 0;
            hasLetter = false;
            answer = "";
        }
    }


}
    

