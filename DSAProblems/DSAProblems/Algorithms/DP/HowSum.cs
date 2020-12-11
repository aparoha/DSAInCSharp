using System;
using System.Collections.Generic;

namespace DSAProblems.Algorithms.DP
{
    class HowSum
    {
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
    }
}
