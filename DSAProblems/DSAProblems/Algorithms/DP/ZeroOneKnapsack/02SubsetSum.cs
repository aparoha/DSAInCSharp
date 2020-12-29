using System;

namespace DSAProblems.Algorithms.DP.ZeroOneKnapsack
{
    /*
    Problem Statement #
    Given a set of positive numbers, determine if there exists a subset whose sum is equal to a given number ‘S’.

    Example 1: #
    Input: {1, 2, 3, 7}, S=6
    Output: True
    The given set has a subset whose sum is '6': {1, 2, 3}

    Example 2: #
    Input: {1, 2, 7, 1, 5}, S=10
    Output: True
    The given set has a subset whose sum is '10': {1, 2, 7}

    Example 3: #
    Input: {1, 3, 4, 8}, S=6
    Output: False
    The given set does not have any subset whose sum is equal to '6'.
     */
    class SubsetSum
    {
        public bool solveR(int[] set, int n, int sum)
        {
            if (sum == 0)
                return true;
            if (n == 0)
                return false;
            //If last element is greater than sum,then ignore it
            if (set[n - 1] > sum) 
                return solveR(set, n - 1, sum);
            //else, check if sum can be obtained by any of the following
            //(a) including the last element
            //(b) excluding the last element 
            return solveR(set, n - 1, sum) || solveR(set, n - 1, sum - set[n - 1]);
        }

        public bool solveBottomUp(int[] set, int n, int sum)
        {
            bool[,] dp = new bool[n + 1, sum + 1];

            for (int i = 0; i <= sum; i++)
                dp[0, i] = false;

            for (int j = 0; j <= n; j++)
                dp[j, 0] = true;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (set[i - 1] > j)
                        dp[i, j] = dp[i - 1, j];
                    else
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - set[i - 1]];
                }
            }

            return dp[n, sum];
        }
    }
}
