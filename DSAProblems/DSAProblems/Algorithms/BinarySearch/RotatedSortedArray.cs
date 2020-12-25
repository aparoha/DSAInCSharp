using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.BinarySearch
{
    class RotatedSortedArray
    {
        //What is rotated sorted array? (Circularly sorted array)
        //No duplicates
        //Here is sorted array - 2    3   5   8   11  12
        //Rotate 1 times -       12   2   3   5   8   11
        //Rotate 2 times -       11   12  2   3   5   8
        //No of rotations = index of minimum element

        //We face 2 cases :
        //1> if arr[mid] > arr[right], it means we're in right sorted array, so go towards left to find the pivot element.
        //2> else it means the array is rotated, so go towards left to find that right sorted array.
        public int FindPivotInRotatedSortedArray(int[] nums)
        {
            int low = 0, high = nums.Length - 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] > nums[high])
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }
    }
}
