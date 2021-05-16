using FollowApp;
using FollowApp.Game;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1st Program : Sort It Out
            SortTheGivenString();

            //2nd Program : Psychic Software
            CanYouGuessIt();
        }

        /// <summary>
        /// This code will guess the number, which you have in your mind. 
        /// </summary>
        private static void CanYouGuessIt()
        {
            var startGuessing = new GuessingGame(5, 50) { GuessHistory = new List<int>() };
            startGuessing.CanYouGuessIt();
        }

        /// <summary>
        /// This code will sort the given string in ta particular order, mainly using the bubble sort. 
        /// </summary>
        private static void SortTheGivenString()
        {
            var sortItOut = new SortItOut();

            //Sample 1
            Console.WriteLine(sortItOut.StartSorting("dog, fox, snake"));

            //Sample 2 - It output is not correct.
            Console.WriteLine(sortItOut.StartSorting("dog, snake, dolphin"));
        }
    }
}