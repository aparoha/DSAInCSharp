using System.Collections.Generic;

namespace DSAProblems.LeetCode.DynamicProgramming
{
    //1025 - Divisor Game

    //Alice and Bob take turns playing a game, with Alice starting first.
    //
    //Initially, there is a number N on the chalkboard.  On each player's turn, that player makes a move consisting of:
    //
    //Choosing any x with 0 < x < N and N % x == 0.
    //Replacing the number N on the chalkboard with N - x.
    //Also, if a player cannot make a move, they lose the game.
    //
    //Return True if and only if Alice wins the game, assuming both players play optimally.
    class LeetCode1025
    {
        //Recursion Brute Force
        public static bool DivisorGame(int N) {
            if(N == 1) return false;
            for(int x = 1; x < N; x++){
                if(N % x == 0 && !DivisorGame(N - x))
                {
                    return true;
                }   
            }
            return false;
        }

        //Recursion with Memoization
        public static bool DivisorGameMemo(int N)
        {
            return DivisorGameMemoHelper(N, new Dictionary<int, bool>());
        }

        public static bool DivisorGameMemoHelper(int N, Dictionary<int, bool> memo) {
            if (memo.TryGetValue(N, out bool result))
            {
                return result;
            }
            if(N == 1) return false;
            bool retVal = false;
            for(int x = 1; x < N; x++)
            {
                if (N % x == 0 && !DivisorGameMemoHelper(N - x, memo))
                {
                    retVal = true;
                    break;
                }
            }
            memo[N] = retVal;
            return memo[N];
        }
    }
}
