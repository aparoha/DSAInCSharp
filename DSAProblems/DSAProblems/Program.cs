using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DSAProblems
{
    class Program
    {
        //static List<int> result =  new List<int>();
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", bestSum(100, new []{1, 2, 5, 25})));//2333606220
            Console.WriteLine(string.Join(",", bestSum(8, new []{2, 3, 5})));//2333606220
            Console.WriteLine(string.Join(",", bestSum(8, new []{1, 4, 5})));//2333606220
            
           Console.ReadLine();
        }

//        const howSum = (targetSum, numbers) => {
//            if(targetSum === 0) return [];
//            if(targetSum < 0) return null;
//
//            for(let num of numbers){
//                const remainder = targetSum - num;
//                const remainderResult = howSum(remainder, numbers);
//                if(remainderResult != null){
//                    return [ ...remainderResult, num ];
//                }
//            }
//
//            return null;
//        }

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
        public static bool canSum(int targetSum, int[] numbers)
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

        public static int FindKthSmallestElement(int[][] matrix, int k)
        {
            int n = matrix.Length;
            int start = matrix[0][0], end = matrix[n - 1][n - 1];
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                int[] smallLargerPair = { matrix[0][0], matrix[n - 1][n - 1] };
                int count = CountLessEqual(matrix, mid, smallLargerPair);
                if (count == k)
                    return smallLargerPair[0];
                if (count < k)
                    start = smallLargerPair[1];
                else
                    end = smallLargerPair[0];
            }
            return start;
        }

        private static int CountLessEqual(int[][] matrix, int mid, int[] smallLargePair)
        {
            int count = 0;
            int n = matrix.Length, row = n - 1, col = 0;
            while (row >= 0 && col < n)
            {
                if (matrix[row][col] > mid)
                {
                    smallLargePair[1] = Math.Min(smallLargePair[1], matrix[row][col]);
                    row--;
                }
                else
                {
                    smallLargePair[0] = Math.Max(smallLargePair[0], matrix[row][col]);
                    count += row + 1;
                    col++;
                }
            }
            return count;
        }

        public static long GetTotalPathsInGridMemo(int m, int n)
        {
            return GetTotalPathsInGridMemoHelper(m, n, new Dictionary<string, long>());
        }

        private static long GetTotalPathsInGridMemoHelper(int m, int n, Dictionary<string, long> memo)
        {
            string key = $"{m},{n}";
            if (memo.TryGetValue(key, out long result))
            {
                return result;
            }
            if (m == 1 && n == 1) return 1;
            if (m == 0 || n == 0) return 0;
            memo.Add(key, GetTotalPathsInGridMemoHelper(m - 1, n, memo) + GetTotalPathsInGridMemoHelper(m, n -1, memo));
            return memo[key];
        }

        //1.A base-case and one or more recursive cases. 
        //2.Use helper method with recursion and store state variables outside of the helper function and 
        //3.Modiy state variables throughout the recursion to be returned at the end.

        //Identify unit of recursion

        public static IList<String> GetStringSubsets(string s)
        {
            var result = new List<string>();
            powerSet(s, 0, "", result);
            return result;
        }

        static void powerSet(String str, int index, String curr, List<string> result)  
        {  
            int n = str.Length;  
  
            // base case  
            if (index == n) 
            { 
                result.Add(curr);
                return;
            }  
  
            // Two cases for every character  
            // (i) We consider the character  
            // as part of current subset  
            // (ii) We do not consider current  
            // character as part of current  
            // subset  
            powerSet(str, index + 1, curr + str[index], result);  
            powerSet(str, index + 1, curr, result); 
        }  

    }

                            


}
