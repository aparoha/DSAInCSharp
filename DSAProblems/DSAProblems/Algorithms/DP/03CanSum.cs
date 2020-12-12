using System.Collections.Generic;

namespace DSAProblems.Algorithms.DP
{
    class CanSum
    {
        //Write a function canSum(targetSum, numbers), a targetSum and array of numbers
        //The function should return boolean indicating whether or not its possible to generate targetSum using numbers
        //Assumptions
        //1.All numbers are positive
        //2.You may use an element of array as many times as needed
        //CanSum(7, [5,3,4,7)) => true => 3 + 4 or 7
        //CanSum(7, [2,4]) => false

        //TC - m - targetSum, n = numbers , O(n^m)
        //SC - O(m)
        public bool canSum(int targetSum, int[] numbers)
        {
            if (targetSum == 0) return true;
            if (targetSum < 0) return false;
            foreach (var num in numbers)
            {
                int remainder = targetSum - num;
                if (canSum(remainder, numbers)) return true;
            }
            return false;
        }

        //TC - m - targetSum, n = numbers , O(m * n)
        //SC - O(m)
        public bool canSumMemo(int targetSum, int[] numbers)
        {
            return canSumMemoHelper(targetSum, numbers, new Dictionary<int, bool>());
        }

        private bool canSumMemoHelper(int targetSum, int[] numbers, Dictionary<int, bool> memo)
        {
            if (memo.TryGetValue(targetSum, out bool result))
            {
                return result;
            }
            if (targetSum == 0) return true;
            if (targetSum < 0) return false;
            foreach (var num in numbers)
            {
                int remainder = targetSum - num;
                if (canSum(remainder, numbers))
                {
                    memo[targetSum] = true;
                    return memo[targetSum];
                }
            }
            memo[targetSum] = false;
            return memo[targetSum];
        }
    }
}
