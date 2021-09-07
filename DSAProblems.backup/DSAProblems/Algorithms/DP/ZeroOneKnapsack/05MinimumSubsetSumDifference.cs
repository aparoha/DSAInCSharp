using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.DP.ZeroOneKnapsack
{
    /*
     Divide array into 2 subsets such that difference of their sum is minimum
     A = [1,6,11,5]
     1st way - [1,6] [11,5] => abs(7 - 16) = 9
     2nd way - [1,6,5] [11] => abs(12 - 11) = 1
     3rd way - [1] [6,11,5] => abs(1 - 22) = 21
     Minimum of all ways = 1

        Range of sum - 1 to 23
        Minimize - Sum - 2*S1
    */
    class MinimumSubsetSumDifference
    {
        public int solveBottomUp(int[] set, int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += set[i];

            bool[,] dp = new bool[n + 1, sum + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    if (j == 0)
                        dp[i, j] = true;
                    else if (i == 0)
                        dp[i, j] = false;
                    else if (set[i - 1] > j)
                        dp[i, j] = dp[i - 1, j];
                    else
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - set[i - 1]];
                }
            }

            int diff = int.MaxValue;
            for (int i = 0; i <= sum / 2; i++)
            {
                if (dp[n, i])
                    diff = Math.Min(diff, Math.Abs(i - (sum - i)));
            }
            return diff;
        }
    }
}
