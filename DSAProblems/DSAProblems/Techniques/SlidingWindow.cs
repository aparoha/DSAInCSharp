using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Techniques
{
    public class SlidingWindow
    {
        //TC - O(N*K)
        public static double[] findAveragesOfKsizeSubArrays(int[] arr, int K)
        {
            int noOfSubArrays = arr.Length - K + 1;
            double[] result = new double[noOfSubArrays];
            for (int i = 0; i < noOfSubArrays; i++) {
                // find sum of next 'K' elements
                double sum = 0;
                for (int j = i; j < i + K; j++)
                    sum += arr[j];
                result[i] = sum / K; // calculate average
            }

            return result;
        }

        //TC - O(N), SC - O(1)
        public static double[] findAveragesOfKsizeSubArraysSliding(int K, int[] arr) {
            double[] result = new double[arr.Length - K + 1];
            double windowSum = 0;
            int windowStart = 0;
            for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++) {
                windowSum += arr[windowEnd]; // add the next element
                // slide the window, we don't need to slide if we've not hit the required window size of 'k'
                if (windowEnd >= K - 1) {
                    result[windowStart] = windowSum / K; // calculate the average
                    windowSum -= arr[windowStart]; // subtract the element going out
                    windowStart++; // slide the window ahead
                }
            }

            return result;
        }

        /*
         Given an array of positive numbers and a positive number ‘S,’ find the length of the smallest contiguous subarray whose sum is greater than or equal to ‘S’. Return 0 if no such subarray exists.

            Example 1:

            Input: [2, 1, 5, 2, 3, 2], S=7 
            Output: 2
            Explanation: The smallest subarray with a sum great than or equal to '7' is [5, 2].
            Example 2:

            Input: [2, 1, 5, 2, 8], S=7 
            Output: 1
            Explanation: The smallest subarray with a sum greater than or equal to '7' is [8].
            Example 3:

            Input: [3, 4, 1, 1, 6], S=8 
            Output: 3
            Explanation: Smallest subarrays with a sum greater than or equal to '8' are [3, 4, 1] or [1, 1, 6].
        */
        public static int findMinLengthSubArraySliding(int S, int[] arr) {
            int windowSum = 0, minLength = int.MaxValue;
            int windowStart = 0;
            for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++) {
                windowSum += arr[windowEnd]; // add the next element
                // shrink the window as small as possible until the 'windowSum' is smaller than 'S'
                while (windowSum >= S) {
                    minLength = Math.Min(minLength, windowEnd - windowStart + 1);
                    windowSum -= arr[windowStart]; // subtract the element going out
                    windowStart++; // slide the window ahead
                }
            }

            return minLength == int.MaxValue ? 0 : minLength;
        }

        /*
        Given a string, find the length of the longest substring in it with no more than K distinct characters.

        Example 1:

        Input: String="araaci", K=2
        Output: 4
        Explanation: The longest substring with no more than '2' distinct characters is "araa".
        Example 2:

        Input: String="araaci", K=1
        Output: 2
        Explanation: The longest substring with no more than '1' distinct characters is "aa".
        Example 3:

        Input: String="cbbebi", K=3
        Output: 5
        Explanation: The longest substrings with no more than '3' distinct characters are "cbbeb" & "bbebi".
         */

        public static int findLengthOfLongestSubstringWithNoMoreThanKDistinctCharacters(string str, int k) {
            if (string.IsNullOrEmpty(str) || str.Length < k)
                throw new ArgumentException();

            int windowStart = 0, maxLength = 0;
            Dictionary<char, int> charFrequencyMap = new Dictionary<char, int>();
            // in the following loop we'll try to extend the range [windowStart, windowEnd]
            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++) {
                char rightChar = str[windowEnd];
                if (!charFrequencyMap.ContainsKey(rightChar))
                    charFrequencyMap.Add(rightChar, 1);
                else
                    charFrequencyMap[rightChar] += 1;
                // shrink the sliding window, until we are left with 'k' distinct characters in the frequency map
                while (charFrequencyMap.Count > k) {
                    char leftChar = str[windowStart];
                    charFrequencyMap[leftChar] -= 1;
                    if (charFrequencyMap[leftChar] == 0) {
                        charFrequencyMap.Remove(leftChar);
                    }
                    windowStart++; // shrink the window
                }
                maxLength = Math.Max(maxLength, windowEnd - windowStart + 1); // remember the maximum length so far
            }

            return maxLength;
        }
    }
}
