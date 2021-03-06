﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.BinarySearch
{
    //852. Peak Index in a Mountain Array
    //Let's call an array arr a mountain if the following properties hold:
    //
    //arr.length >= 3
    //There exists some i with 0 < i < arr.length - 1 such that:
    //arr[0] < arr[1] < ... arr[i-1] < arr[i]
    //arr[i] > arr[i+1] > ... > arr[arr.length - 1]
    //Given an integer array arr that is guaranteed to be a mountain, return any i such that arr[0] < arr[1] < ... arr[i - 1] < arr[i] > arr[i + 1] > ... > arr[arr.length - 1].
    //
    // 
    //
    //Example 1:
    //
    //Input: arr = [0,1,0]
    //Output: 1
    //Example 2:
    //
    //Input: arr = [0,2,1,0]
    //Output: 1
    //Example 3:
    //
    //Input: arr = [0,10,5,2]
    //Output: 1
    //Example 4:
    //
    //Input: arr = [3,4,5,1]
    //Output: 2
    //Example 5:
    //
    //Input: arr = [24,69,100,99,79,78,67,36,26,19]
    //Output: 2
    // 
    //
    //Constraints:
    //
    //3 <= arr.length <= 104
    //0 <= arr[i] <= 106
    //arr is guaranteed to be a mountain array.
    class LeetCode852
    {
        public int PeakIndexInMountainArray(int[] arr) {
            if(arr == null || arr.Length == 0 || arr.Length < 3) {
                return -1;
            }
        
            int low = 0, high = arr.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] < arr[mid + 1])
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }

        public int PeakIndexInMountainArrayBruteForce(int[] arr) {
            if(arr == null || arr.Length == 0 || arr.Length < 3) {
                return -1;
            }
        
            int peakIndex = -1;
            int length = arr.Length;
        
            for(int i = 0; i < length - 1; i++) {
                if(arr[i+1] > arr[i]) {
                    peakIndex = i + 1;
                } else {
                    break;
                }
            }
            return peakIndex == 0 || peakIndex == length - 1 ? -1 : peakIndex;
        }
    }
}
