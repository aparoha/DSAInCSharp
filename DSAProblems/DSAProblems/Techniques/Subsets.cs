using System;
using System.Collections.Generic;

namespace DSAProblems.Techniques
{
    /*
     Permutations and combinations of given set of elements
     Pattern - Breadth First Search

     To generate all subsets of the given set, we can use the Breadth First Search (BFS) approach. We can start with an empty set, iterate through all numbers one-by-one, and add them to existing sets to create new subsets.

     Let’s take the example-2 mentioned above to go through each step of our algorithm:

        Given set: [1, 5, 3]

        Start with an empty set: [[]]
        Add the first number (1) to all the existing subsets to create new subsets: [[], [1]];
        Add the second number (5) to all the existing subsets: [[], [1], [5], [1,5]];
        Add the third number (3) to all the existing subsets: [[], [1], [5], [1,5], [3], [1,3], [5,3], [1,5,3]].
     
        Time complexity #
        Since, in each step, the number of subsets doubles as we add each element to all the existing subsets, 
        therefore, we will have a total of O(2^N) subsets, where ‘N’ is the total number of elements in the input set. 
        And since we construct a new subset from an existing set, therefore, the time complexity of the above algorithm 
        will be O(N*2^N)

        Space complexity #
        All the additional space used by our algorithm is for the output list. Since we will have a total of O(2^N)
        subsets, and each subset can take up to O(N)O(N) space, therefore, the space complexity of our algorithm will be 
        O(N*2^N)
    */
    class Subsets
    {
        public List<List<int>> findSubsets(int[] nums) {
            List<List<int>> subsets = new List<List<int>>();
            // start by adding the empty subset
            subsets.Add(new List<int>());
            foreach (int currentNumber in nums) {
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

        public List<List<int>> findSubsetsWithDuplicates(int[] nums) {
            // sort the numbers to handle duplicates
            Array.Sort(nums);
            List<List<int>> subsets = new List<List<int>>();
            subsets.Add(new List<int>());
            int startIndex = 0, endIndex = 0;
            for (int i = 0; i < nums.Length; i++) {
                if (i > 0 && nums[i] == nums[i - 1])
                    startIndex = endIndex + 1;
                endIndex = subsets.Count - 1;
                for (int j = startIndex; j <= endIndex; j++) {
                    // create a new subset from the existing subset and add the current element to it
                    List<int> set = new List<int>(subsets[j]);
                    set.Add(nums[i]);
                    subsets.Add(set);
                }
            }
            return subsets;
        }

        public List<List<int>> findPermutations(int[] nums) {
            var result = new List<List<int>>();
            Queue<List<int>> permutations = new Queue<List<int>>();
            permutations.Enqueue(new List<int>());
            foreach(int currentNumber in nums) {
                // we will take all existing permutations and add the current number to create new permutations
                int n = permutations.Count;
                for (int i = 0; i < n; i++) {
                    List<int> oldPermutation = permutations.Dequeue();
                    // create a new permutation by adding the current number at every position
                    for (int j = 0; j <= oldPermutation.Count; j++) {
                        List<int> newPermutation = new List<int>(oldPermutation);
                        newPermutation.Insert(j, currentNumber);
                        if (newPermutation.Count == nums.Length)
                            result.Add(newPermutation);
                        else
                            permutations.Enqueue(newPermutation);
                    }
                }
            }
            return result;
        }

        public static List<string> findPermutationsStr(string s)
        {
            List<string> result = new List<string>();
            Queue<string> permutations = new Queue<string>();
            permutations.Enqueue(string.Empty);
            foreach (char currentChar in s)
            {
                int n = permutations.Count;
                for (int j = 0; j < n; j++)
                {
                    string str = permutations.Dequeue();
                    for (int k = 0; k <= str.Length; k++)
                    {
                        var newPermutation = str.Substring(0, k) + currentChar + str.Substring(k);
                        if (newPermutation.Length == s.Length)
                            result.Add(newPermutation);
                        else
                            permutations.Enqueue(newPermutation);
                    }
                }
            }
            return result;
        }

    }
}
