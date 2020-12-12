using System;
using System.Collections.Generic;

namespace DSAProblems.Algorithms.DP
{
    class HowSum
    {
        //TC - O(n^m * m), n = numbers.Length, m = targetSum
        //SC - O(m)
        public static int[] howSum(int targetSum, int[] numbers)
        {
            if (targetSum == 0) return Array.Empty<int>();
            if (targetSum < 0) return null;
            List<int> result =  new List<int>();
            foreach (var num in numbers)
            {
                var remainder = targetSum - num;
                var remainderResult = howSum(remainder, numbers);
                if (remainderResult != null)
                {
                    result.AddRange(remainderResult);
                    result.Add(num);
                    return result.ToArray();
                }
            }
            return null;
        }

        //TC - O(n*m*m) => O(n*m^2)
        //SC - O(m)
        public static int[] howSumMemo(int targetSum, int[] numbers)
        {
            return howSumMemoHelper(targetSum, numbers, new Dictionary<int, List<int>>());
        }

        private static int[] howSumMemoHelper(int targetSum, int[] numbers, Dictionary<int, List<int>> memo)
        {
            if(memo.TryGetValue(targetSum, out List<int> outResult))
            {
                return outResult?.ToArray();
            }
            if (targetSum == 0) return Array.Empty<int>();
            if (targetSum < 0) return null;
            List<int> result =  new List<int>();
            foreach (var num in numbers)
            {
                var remainder = targetSum - num;
                var remainderResult = howSumMemoHelper(remainder, numbers, memo);
                if (remainderResult != null)
                {
                    result.AddRange(remainderResult);
                    result.Add(num);
                    memo[targetSum] = result;
                    return memo[targetSum].ToArray();
                }
            }
            memo[targetSum] = null;
            return null;
        }

    }
}
