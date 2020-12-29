using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.DP.ZeroOneKnapsack
{
    /*
     Partition problem is to determine whether a given set can be partitioned into two subsets such that the sum of elements in both subsets is the same. 

    Examples: 

    arr[] = {1, 5, 11, 5}
    Output: true 
    The array can be partitioned as {1, 5, 5} and {11}

    arr[] = {1, 5, 3}
    Output: false 
    The array cannot be partitioned into equal sum sets.
    */
    class EqualSumPartition
    {
        public bool solveR(int[] arr, int n)
        {
            if (n == 0)
                return false;

            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += arr[i];

            // If sum is odd, there cannot be two subsets with equal sum
            if (sum % 2 != 0)
                return false;

            //Find if there is subset with sum equal to half of total sum
            SubsetSum subsetSum = new SubsetSum();
            return subsetSum.solveR(arr, n, sum / 2);
        }
    }
}
