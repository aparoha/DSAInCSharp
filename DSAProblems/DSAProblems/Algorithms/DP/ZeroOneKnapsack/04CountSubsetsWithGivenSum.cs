namespace DSAProblems.Algorithms.DP.ZeroOneKnapsack
{
    /*
     This problem is variation of subset sum, just change || operator with +
    */
    class CountSubsetsWithGivenSum
    {
        public int solveR(int[] set, int n, int sum)
        {
            if (sum == 0)
                return 1;
            if (n == 0)
                return 0;
            //If last element is greater than sum,then ignore it
            if (set[n - 1] > sum) 
                return solveR(set, n - 1, sum);
            //else, check if sum can be obtained by any of the following
            //(a) including the last element
            //(b) excluding the last element 
            return solveR(set, n - 1, sum) + solveR(set, n - 1, sum - set[n - 1]);
        }

        //TC - O(n*sum)
        public int solveBottomUp(int[] set, int n, int sum)
        {
            int[,] dp = new int[n + 1, sum + 1];

            for (int i = 0; i <= sum; i++)
                dp[0, i] = 0;

            for (int j = 0; j <= n; j++)
                dp[j, 0] = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (set[i - 1] > j)
                        dp[i, j] = dp[i - 1, j];
                    else
                        dp[i, j] = dp[i - 1, j] + dp[i - 1, j - set[i - 1]];
                }
            }

            return dp[n, sum];
        }
    }
}
