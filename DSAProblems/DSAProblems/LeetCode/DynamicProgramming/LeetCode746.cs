using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.DynamicProgramming
{
    /*
     746. Min Cost Climbing Stairs
     On a staircase, the i-th step has some non-negative cost cost[i] assigned (0 indexed).

    Once you pay the cost, you can either climb one or two steps. You need to find minimum cost to reach the top of the floor, and you can either start from the step with index 0, or the step with index 1.

    Example 1:
    Input: cost = [10, 15, 20]
    Output: 15
    Explanation: Cheapest is start on cost[1], pay that cost and go to the top.
    Example 2:
    Input: cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1]
    Output: 6
    Explanation: Cheapest is start on cost[0], and only step on 1s, skipping cost[3].
    Note:
    cost will have a length in the range [2, 1000].
    Every cost[i] will be an integer in the range [0, 999].
    */
    class LeetCode746
    {
        //Recursion
        public int MinCostClimbingStairsR(int[] cost) {
            int n = cost.Length;
            return Math.Min(helper(cost, n-1), helper(cost, n-2));
        }
    
        public int helper(int[] cost, int n) {
            if (n < 0) return 0;
            if (n == 0 || n == 1) return cost[n];
            return cost[n] + Math.Min(helper(cost, n-1), helper(cost, n-2));
        }

        //Recursion with Memoization
        public int MinCostClimbingStairsRMemo(int[] cost) {
            int n = cost.Length;
            Dictionary<int, int> memo = new Dictionary<int, int>();
            return Math.Min(helperMemo(cost, n-1, memo), helperMemo(cost, n-2, memo));
        }
    
        public int helperMemo(int[] cost, int n, Dictionary<int, int> memo) {
            if (n < 0) return 0;
            if (n==0 || n==1) return cost[n];
            if (!memo.ContainsKey(n))
            {
                memo[n] = cost[n] + Math.Min(helperMemo(cost, n - 1, memo), helperMemo(cost, n - 2, memo));
            }
            return memo[n];
        }

        public int MinCostClimbingStairsBottomUp(int[] cost) {
            int n = cost.Length;
            int[] dp = new int[n];
            for (int i=0; i<n; i++) {
                if (i<2) 
                    dp[i] = cost[i];
                else 
                    dp[i] = cost[i] + Math.Min(dp[i-1], dp[i-2]);
            }
            return Math.Min(dp[n-1], dp[n-2]);
        }

        int minCostClimbingStairs(int[] cost) {
            for(int i=2; i<cost.Length; i++)
                cost[i] += Math.Min(cost[i-1], cost[i-2]);
            return Math.Min(cost[cost.Length - 1], cost[cost.Length - 2]);
        }
    }
}
