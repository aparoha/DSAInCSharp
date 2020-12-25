namespace DSAProblems.LeetCode.BinarySearch
{
        /*
    153. Find Minimum in Rotated Sorted Array

    Suppose an array of length n sorted in ascending order is rotated between 1 and n times. For example, the array nums = [0,1,2,4,5,6,7] might become:

    [4,5,6,7,0,1,2] if it was rotated 4 times.
    [0,1,2,4,5,6,7] if it was rotated 7 times.
    Notice that rotating an array [a[0], a[1], a[2], ..., a[n-1]] 1 time results in the array [a[n-1], a[0], a[1], a[2], ..., a[n-2]].

    Given the sorted rotated array nums, return the minimum element of this array.

    Example 1:

    Input: nums = [3,4,5,1,2]
    Output: 1
    Explanation: The original array was [1,2,3,4,5] rotated 3 times.
    Example 2:

    Input: nums = [4,5,6,7,0,1,2]
    Output: 0
    Explanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.
    Example 3:

    Input: nums = [11,13,15,17]
    Output: 11
    Explanation: The original array was [11,13,15,17] and it was rotated 4 times. 
 

    Constraints:

    n == nums.length
    1 <= n <= 5000
    -5000 <= nums[i] <= 5000
    All the integers of nums are unique.
    nums is sorted and rotated between 1 and n times.
         */
    class LeetCode153And154
    {
        //We face 2 cases :
        //1> if arr[mid] > arr[right], it means we're in right sorted array, so go towards left to find the pivot element.
        //2> else it means the array is rotated, so go towards left to find that right sorted array.
        public int FindMin(int[] nums) {
            if (nums == null || nums.Length == 0)
                return -1;

            int low = 0, high = nums.Length - 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] > nums[high])
                    low = mid + 1;
                else
                    high = mid;
            }
            return nums[low];
        }

        public int FindPeakElement(int[] nums) {
        
            if(nums == null || nums.Length == 0) {
                return -1;
            }
        
            int left = 0, right = nums.Length - 1;
        
            while(left < right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] <= nums[mid + 1])
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }

        public int FindMinWithDuplicates(int[] nums) {
            
            if (nums == null || nums.Length == 0)
                return -1;

            int low = 0, high = nums.Length - 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] > nums[high])
                    low = mid + 1;
                else if (nums[mid] == nums[high])
                    high = high - 1;
                else
                    high = mid;
            }
            return nums[low];
        }
    }
}
