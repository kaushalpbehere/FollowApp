using System.Collections.Generic;

namespace FollowApp.Game
{
    interface IPsychic
    {
        int CurrentGuess { get; }
        int LowerBound { get; }
        int UpperBound { get; }
        bool Complete { get; }
        IEnumerable<int> GuessHistory { get; }
        int GuessCount { get; }
        void Higher();
        void Lower();
        void Correct();
    }
}