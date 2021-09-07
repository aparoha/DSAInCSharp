using System;
using System.Collections.Generic;

namespace DSAProblems.Techniques
{
    class SubArraySubStringSubSequences
    {
        //O(n^3)
        static void subArray(int[] arr, int n)
        {
            // Pick starting point
            for (int i = 0; i < n; i++)
            {
                // Pick ending point
                for (int j = i; j < n; j++)
                {
                    // Print subarray between current 
                    // starting and ending points
                    for (int k = i; k <= j; k++)
                        Console.Write(arr[k]+" ");
                    Console.WriteLine("");
                }
            }
        }

        //Time Complexity O(n * 2^n) 
        //A subsequence is a sequence that can be derived from another sequence by zero or more elements, without changing the order of the remaining elements. 
        //[1,2,3,4]
        //They are (1), (2), (3), (4), (1,2), (1,3),(1,4), (2,3), (2,4), (3,4), (1,2,3), (1,2,4), (1,3,4), (2,3,4), (1,2,3,4). More generally, 
        //we can say that for a sequence of size n, we can have ((2^n)-1) non-empty sub-sequences in total. 
        //A string example to differentiate: 
        //Consider strings “geeksforgeeks” and “gks”. “gks” is a subsequence of “geeksforgeeks” but not a substring. “geeks” is both a subsequence and subarray. 
        //Every subarray is a subsequence. More specifically, Subsequence is a generalization of substring.
        //Use same power set code , just dont add empty set condition
        public static List<List<int>> printSubsequences(int[] arr, int n) 
        { 
            List<List<int>> subsets = new List<List<int>>();
            foreach (int currentNumber in arr) {
                // we will take all existing subsets and insert the current number in them to create new subsets
                int size = subsets.Count;
                for (int i = 0; i < size; i++) {
                    // create a new subset from the existing subset and insert the current element to it
                    List<int> set = new List<int>(subsets[i]);
                    set.Add(currentNumber);
                    subsets.Add(set);
                }
            }
            return subsets;
        } 
     
    }
}
