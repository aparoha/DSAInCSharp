using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.DynamicProgramming
{
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
            for(int x = 1; x < N; x++){
                if(N % x == 0 && !DivisorGameMemoHelper(N - x, memo))
                {
                    memo[N] = true;
                    return memo[N];
                }   
            }
            memo[N] = false;
            return false;
        }
    }
}
