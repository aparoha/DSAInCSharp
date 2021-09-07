using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.OA.Amazon
{
    /*
    Given an array containing only positive integers, return if you can pick two integers from the array which cuts the array into three pieces such that the sum of elements in all pieces is equal.

    Examples
    Example 1:
    Input: [2, 4, 5, 3, 3, 9, 2, 2, 2]
    Output: true
    Explanation:
    Choosing the number 5 and 9 results in three pieces [2, 4], [3, 3] and [2, 2, 2]. Sum = 6.

    Example 2:
    Input: [1, 1, 1, 1]
    Output: false
    */
    class LoadBalancer
    {
        public bool lb(int[] nums)
        {
            if(nums.Length < 5)
                return false;
            int leftsum = nums[0], rightsum = nums[nums.Length - 1];
            int left = 1, right = nums.Length - 2;

            while(left < right) {
                if(leftsum == rightsum) {
                    int ptr = left + 1;
                    int sum = 0;
                    while(ptr < right) {
                        sum += nums[ptr++];
                    }
                    if(sum == leftsum)
                        return true;
                }
         
                if(leftsum < rightsum) {
                    leftsum += nums[left++];
                }
                else {
                    rightsum += nums[right--];
                }
            }
            return false;
        }

        //Prefix sum + two pointer
        //Calculate prefix sum
        //In this case, If we remove the first element or last element, then there is no way in which we can split the array into 3 equal parts. 
        //Hence, we can safely assume that
        //int leftPointer = 1;
        //int rightPointer = A.Length - 2;
        //Now, we move the pointer towards each other and at every movement we calculate leftPartSum, middlePartSum and rightPartSum. Whether we need to move left pointer or right pointer is decided by the fact that which one of the two sums 
        //(leftPartSum or rightPartSum is smaller)
        public bool canThreePartsEqualSum(int[] A) {
            if(A.Length < 5)
                return false;
            int leftPointer = 1;
            int rightPointer = A.Length - 2;
            int[] sumArray = new int[A.Length];

            // Initializing the sum array
            sumArray[0] = A[0];
            for(int i = 1; i < A.Length; i ++)
                sumArray[i] = sumArray[i-1] +  A[i];

            // Using two Pointer technique
            while(leftPointer < rightPointer) {

                var leftPartSum = sumArray[leftPointer] - A[leftPointer];
                var middlePartSum = sumArray[rightPointer] - sumArray[leftPointer] - A[rightPointer];
                var rightPartSum = sumArray[A.Length - 1] - sumArray[rightPointer];

                if(leftPartSum == middlePartSum && middlePartSum == rightPartSum)
                    return true;

                if (leftPartSum < rightPartSum)
                    leftPointer++;
                else if (leftPartSum > rightPartSum)
                    rightPointer--;
                else{                   // Else condition denotes: leftPartSum == rightPartSum
                    leftPointer++;
                    rightPointer--;
                }
            }
            return false; // If no solution is found then returning false
        }
    
    }
}
