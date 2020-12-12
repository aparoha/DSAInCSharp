using System;
using System.Collections.Generic;

namespace DSAProblems.Algorithms.DP
{
    //Write a function bestSum(targetSum, numbers) that takes in a targetSum and an array of numbers
    //The function should return an array containing the shortest combination of numbers that add up to exactly the targetSum
    //If there is a tie for the shortest combination, return any one of the shortest

    //Example bestSum(7, [5, 3, 4, 7])
    //[3,4], [7] Answer => [7]
    //Example bestSum(8, [2, 3, 5]
    //[2, 2, 2, 2], [2, 3, 3], [3, 5] Answer => [3, 5]

    class BestSum
    {
        public static int[] bestSum(int targetSum, int[] numbers)
        {
            if (targetSum == 0) return Array.Empty<int>();
            if (targetSum < 0) return null;
            List<int> shortestCombination =  null;
            foreach (var num in numbers)
            {
                List<int> combination = new List<int>();
                var remainder = targetSum - num;
                var remainderResult = bestSum(remainder, numbers);
                if (remainderResult != null)
                {
                    combination.AddRange(remainderResult);
                    combination.Add(num);
                    if (shortestCombination == null || combination.Count < shortestCombination.Count)
                    {
                        shortestCombination = combination;
                    }
                }
            }
            return shortestCombination?.ToArray();
        }
    }
}
