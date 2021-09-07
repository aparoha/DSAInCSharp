using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.BinarySearch
{
    /*
     You are given a sorted array consisting of only integers where every element appears exactly twice, except for one element which appears exactly once. Find this single element that appears only once.
     Example 1:

        Input: nums = [1,1,2,3,3,4,4,8,8]
        Output: 2
        Example 2:

        Input: nums = [3,3,7,7,10,11,11]
        Output: 10
 

        Constraints:

        1 <= nums.length <= 10^5
        0 <= nums[i] <= 10^5
Follow up: Your solution should run in O(log n) time and O(1) space.
*/
    class LeetCode540
    {
        public int SingleNonDuplicate(int[] nums) {
        
            if(nums == null || nums.Length == 0) {
                return -1;
            }
        
            int low = 0, high = nums.Length - 1;
            while (low < high) {
                int mid = low + (high - low) / 2;
                int n = mid % 2 == 0 ? mid + 1 : mid - 1;
                if(nums[mid] == nums[n])
                    low = mid + 1;
                else
                    high = mid;
            }
        
            return nums[low];
        }

        public int SingleNonDuplicate2(int[] nums) {
        
            if(nums == null || nums.Length == 0) {
                return -1;
            }
        
            int low = 0, high = nums.Length - 1;
            while (low < high) {
                int mid = 2 *((high + low) / 4);
                if(nums[mid] == nums[mid + 1])
                    low = mid + 2;
                else
                    high = mid;
            }
        
            return nums[low];
        }
    }
}
