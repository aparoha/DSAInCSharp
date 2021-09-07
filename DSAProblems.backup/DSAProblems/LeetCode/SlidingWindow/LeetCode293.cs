using System;
using System.Collections.Generic;

namespace DSAProblems.LeetCode.SlidingWindow
{
    class LeetCode293
    {
        public int[] MaxSlidingWindow(int[] nums, int k) {
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length - k + 1; i++) {
                int max = int.MinValue;
                for (int j = i; j < i + k; j++) {
                    max = Math.Max(nums[j], max);
                }
                result.Add(max);
            }
            return result.ToArray();
        }

        public int[] MaxSlidingWindow2(int[] nums, int k) {
            int noOfWindows = nums.Length - k + 1;
            int[] result = new int[noOfWindows];
            for (int i = 0; i < noOfWindows; i++) {
                int max = int.MinValue;
                for (int j = i; j < i + k; j++) {
                    max = Math.Max(nums[j], max);
                }
                result[i] = max;
            }
            return result;
        }
    }
}
