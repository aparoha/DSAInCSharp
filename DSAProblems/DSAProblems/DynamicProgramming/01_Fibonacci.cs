using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DynamicProgramming
{
    public class _01_Fibonacci
    {
        public int Fib(int n)
        {
            if(n <= 1)
                return n;
            return Fib(n-1) + Fib(n-2);
        }

        //Cache overlapping subproblems
        public int FibMemo(int n)
        {
            int[] dp = new int[n + 1];
            Array.Fill(dp, -1);
            return FibMemoInternal(n, dp);
        }

        private int FibMemoInternal(int n, int[] dp)
        {
            if (n <= 1)
                return n;
            if(dp[n] != -1)
                return dp[n];
            dp[n] = FibMemoInternal(n - 1, dp) + FibMemoInternal(n - 2, dp);
            return dp[n];
        }

        public int FibTabulation(int n)
        {
            int[] dp = new int[n + 1];

            //Fill base case
            dp[0] = 0;
            dp[1] = 1;

            for(int i = 2; i <= n; i++)
                dp[i] = dp[i - 1] + dp[i -2];

            return dp[n];
        }

        //Space optimization - one observation in tabulation - we only need last 2 values to calculate current value
        //No need to use array
        public int FibTabulationOptimize(int n)
        {
            int previous2 = 0, previous1 = 1;
            for(int i = 2; i <= n; i++)
            {
                int current = previous1 + previous2;
                previous2 = previous1;
                previous1 = current;
            }
            return previous1;
        }
    }
}
