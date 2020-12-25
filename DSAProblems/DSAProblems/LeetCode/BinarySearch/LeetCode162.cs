namespace DSAProblems.LeetCode.BinarySearch
{
    //A peak element is an element that is strictly greater than its neighbors.
    //Given an integer array nums, find a peak element, and return its index. If the array contains multiple peaks, return the index to any of the peaks.
    //You may imagine that nums[-1] = nums[n] = -∞.

    //Example 1:
    //Input: nums = [1,2,3,1]
    //Output: 2
    //Explanation: 3 is a peak element and your function should return the index number 2.
    
    //Example 2:
    //Input: nums = [1,2,1,3,5,6,4]
    //Output: 5
    //Explanation: Your function can return either index number 1 where the peak element is 2, or index number 5 where the peak element is 6.
    // 
    //Constraints:
    //
    //1 <= nums.length <= 1000
    //-231 <= nums[i] <= 231 - 1
    //nums[i] != nums[i + 1] for all valid i.
    class LeetCode162
    {
        //Think in terms of discrete binary search
        //We need to find a predicate and check where it splits the boundary
        //Precicate - nums[i+1] >= nums[i]
        //For example - [1,2,3,1] => 2>1,3>2,1<3 => [T,T,F] => index of F is 2 => answer is 3
        //[1,2,1,3,5,6,4] => 2>1, 1<2, 3>1, 5>3, 6>5, 4 < 6 => [T,F,T,T,T,F] => index of F 0 and 5
        public static int FindPeakElementExclusive(int[] nums) {
        
            if(nums == null || nums.Length == 0) {
                return -1;
            }
        
            int left = 0, right = nums.Length - 1, mid;
        
            while(left < right)
            {
                mid = left + (right - left) / 2;

                if (nums[mid] <= nums[mid + 1])
                    left = mid + 1;
                else
                    right = mid;
            }
        
            return left;     
        }
    }
}
