using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Sorting
{
    /* 1. Sorts based on keys that are small positive integers
     * 2. Its an integer sorting algorithm
     * 3. Runs in O(n) time, making it asymptotically faster than comparison-based sorting algorithms like quicksort or merge sort.
     * 4. Only works when the range of potential items in the input is known ahead of time.
     * 5. If the range of potential values is big, then counting sort requires a lot of space (perhaps more than O(n)).
     * 6. Counting sort works by iterating through the input, 
     *    counting the number of times each item occurs, and 
     *    using those counts to compute an item's index in the final, sorted array.
    */
    public class CountingSort
    {
        //https://stackoverflow.com/questions/49184457/counting-sort-negative-integers
        public int[] SortArray(int[] nums)
        {
            int low = nums.Min();
            int high = nums.Max();
            int[] freq = new int[high - low + 1];

            foreach (var num in nums)
                freq[num - low] += 1;

            for (int i = 1; i < freq.Length; i++)
                freq[i] = freq[i] + freq[i - 1];

            int[] sorted = new int[nums.Length];
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int current = nums[i];
                sorted[freq[current - low] - 1] = current;
                freq[current - low]--;
            }

            return sorted;
        }
        public int[] Sort(int[] nums, int size)
        {
            // count the number of times each value appears.
            // counts[0] stores the number of 0's in the input
            // counts[4] stores the number of 4's in the input
            int[] freq = new int[size + 1];
            foreach(var num in nums)
                freq[num] += 1;

            //Modify the count array by adding previous count - cumulative sum
            for (int i = 1; i < freq.Length; i++)
                freq[i] = freq[i] + freq[i - 1];

            //Use fre array and place object in correct position in sorted array
            //and decrease the count by one
            int[] sorted = new int[nums.Length];
            for(int i = nums.Length - 1; i >= 0; i--)
            {
                int current = nums[i];
                sorted[freq[current] - 1] = current;
                freq[current]--;
            }

            return sorted;
        }
    }
}
