using System;

namespace DSAProblems.LeetCode.BinarySearch
{
    //Given an array of n positive integers and a positive integer s, find the minimal length of a contiguous subarray of which the sum ≥ s. If there isn't one, return 0 instead.

    //Example: 
    //Input: s = 7, nums = [2,3,1,2,4,3]
    //Output: 2
    //Explanation: the subarray [4,3] has the minimal length under the problem constraint.
    //Follow up:
    //If you have figured out the O(n) solution, try coding another solution of which the time complexity is O(n log n). 
    class LeetCode209
    {
        //TC - O(n2)
        public int MinSubArrayLenBruteForce(int s, int[] nums) {
        
            if(nums == null || nums.Length == 0) {
                return 0;
            }
        
            int minSize = int.MaxValue;
        
            for(int i = 0; i < nums.Length; i++) {
                int currSum = 0;
                for(int j = i; j < nums.Length; j++) {
                    currSum += nums[j];
                    if(currSum >= s) {
                        minSize = Math.Min(minSize, j - i + 1);
                    }
                }
            }
        
            return (minSize == int.MaxValue) ? 0 : minSize;
        }
    }
}
