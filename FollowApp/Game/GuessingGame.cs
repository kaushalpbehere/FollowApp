using System;
using System.Collections.Generic;
using System.Linq;

namespace FollowApp.Game
{
    public class GuessingGame : IPsychic
    {
        public int CurrentGuess { get; set; }

        public int LowerBound { get; set; }

        public int UpperBound { get; set; }

        public bool Complete { get; set; }

        public IEnumerable<int> GuessHistory;

        public int GuessCount { get; set; }

        IEnumerable<int> IPsychic.GuessHistory { get; }

        public void Correct()
        {
            //Exit the application
            Complete = true;
        }

        public void Higher()
        {
            //Reduce the highest numbers and guess again.
            this.LowerBound = this.UpperBound;
            this.UpperBound += 15;
        }

        public void Lower()
        {
            //Increase the number and guess again. 
            this.UpperBound = this.LowerBound;
            this.LowerBound -= 15;
        }

        public GuessingGame(int lowerBound, int upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        // Instantiate random number generator.  
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber() { return _random.Next(this.LowerBound, this.UpperBound); }

        /// <summary>
        /// This code will guess the number, which you have in your mind. 
        /// </summary>
        public void CanYouGuessIt()
        {
            bool keepGuessing = true;
            bool keepGenerating = true;
            var startGuessing = new GuessingGame(5, 50) { GuessHistory = new List<int>() };

            while (keepGuessing)
            {
                while (keepGenerating)
                {
                    var randomGuess = startGuessing.RandomNumber();
                    if (!startGuessing.GuessHistory.Contains(randomGuess))
                    {
                        startGuessing.CurrentGuess = randomGuess;
                        keepGenerating = false;
                    }
                    else
                        startGuessing.GuessHistory.ToList().Add(randomGuess);
                }
                keepGenerating = true;
                startGuessing.GuessHistory.ToList().Add(startGuessing.CurrentGuess);
                Console.WriteLine("Upper Limit: " + startGuessing.UpperBound + ", LowerBound: " + startGuessing.LowerBound);
                Console.WriteLine("Guess: " + startGuessing.CurrentGuess);
                Console.WriteLine("Is this your number? (Y/N): ");
                var input = Console.ReadLine().Trim().ToUpper();
                if (input == "Y")
                {
                    keepGuessing = false;
                    startGuessing.Correct();
                }
                else if (input == "N")
                {
                    //
                    Console.WriteLine("Is your number, smaller than the lower bound? (Y/N): ");
                    input = Console.ReadLine().Trim().ToUpper();
                    if (input == "Y")
                    {
                        startGuessing.Lower();
                    }

                    Console.WriteLine("Is your number, greater than the Upper bound? (Y/N): ");
                    input = Console.ReadLine().Trim().ToUpper();
                    if (input == "Y")
                    {
                        startGuessing.Higher();
                    }
                }
            }
        }
    }
}
