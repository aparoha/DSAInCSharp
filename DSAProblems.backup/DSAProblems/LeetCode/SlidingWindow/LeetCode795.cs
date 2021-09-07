using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.SlidingWindow
{
    /*
     795. Number of Subarrays with Bounded Maximum
     We are given an array A of positive integers, and two positive integers L and R (L <= R).

    Return the number of (contiguous, non-empty) subarrays such that the value of the maximum array element in that subarray is at least L and at most R.

    Example :
    Input: 
    A = [2, 1, 4, 3]
    L = 2
    R = 3
    Output: 3
    Explanation: There are three subarrays that meet the requirements: [2], [2, 1], [3].
    Note:

    L, R  and A[i] will be an integer in the range [0, 10^9].
    The length of A will be in the range of [1, 50000].
    */
    class LeetCode795
    {
        //Keep increasing end until condition satisfies and move start ahead end when element > R
        public int NumSubarrayBoundedMax(int[] A, int L, int R) {
            int windowStart = 0, count = 0, current = 0;
            for(int windowEnd = 0; windowEnd < A.Length; windowEnd++){
                if(A[windowEnd] >= L && A[windowEnd] <= R){
                    current = windowEnd - windowStart + 1;
                } else if(A[windowEnd] > R){
                    current = 0;
                    windowStart = windowEnd + 1;
                }
                count += current;
            }
            return count;
        }
    }
}
