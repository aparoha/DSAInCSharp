using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.BinarySearch
{
    //https://medium.com/better-programming/three-smart-ways-to-use-binary-search-in-coding-interviews-250ba296cb82
    class Problems
    {
        //Given an N * N matrix where each row and column is sorted in ascending order, 
        //find the K-th smallest element in the matrix.
        //Input
        //[
        //  [2,6,8],
        //  [3,7,10],
        //  5,8,11]
        //]
        //K = 5
        //Output = 7

        //In binary search, we calculate the middle index of the search space (1 to N) and see if our required number is pointed out by the middle index. 
        //If not, we either search in the lower half or the upper half.
        //In a sorted matrix, we can’t really find a middle. Even if we do consider some index as middle, it is not straightforward to find the search 
        //space containing numbers bigger or smaller than the number pointed out by the middle index.
        //An alternative could be to apply the binary search on the “number range” instead of the “index range”.


        //The smallest number of our matrix is at the top left corner and the biggest number is at the bottom lower corner. 
        //These two numbers can represent the range, i.e., the start and the end for the binary search.
        //

        //
        //1.Start the binary search with start = matrix[0][0] and end = matrix[n-1][n-1].
        //2.Find the middle of the start and the end. This middle number is not necessarily an element in the matrix.
        //3.Count all the numbers smaller than or equal to middle in the matrix. As the matrix is sorted, we can do this in O(N).
        //4.While counting, we can keep track of the “smallest number greater than the middle” (let’s call it n1) and, at the same time, 
        //the “biggest number less than or equal to the middle” (let’s call it n2). These two numbers will be used to adjust the number range 
        //for the binary search in the next iteration.
        //5.If the count is equal to K, n1 will be our required number as it is the “biggest number less than or equal to the middle”, and is definitely present in the matrix.
        //6.If the count is less than K, we can update start = n2 to search in the higher part of the matrix and if the count is greater than K, we can update end = n1 to search in the lower part of the matrix in the next iteration.

        public int FindKthSmallestElement(int[][] matrix, int k)
        {
            int n = matrix.Length;
            int start = matrix[0][0], end = matrix[n - 1][n - 1];
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                int[] smallLargerPair = { matrix[0][0], matrix[n - 1][n - 1] };
                int count = CountLessEqual(matrix, mid, smallLargerPair);
                if (count == k)
                    return smallLargerPair[0];
                if (count < k)
                    start = smallLargerPair[1];
                else
                    end = smallLargerPair[0];
            }
            return start;
        }

        private int CountLessEqual(int[][] matrix, int mid, int[] smallLargePair)
        {
            int count = 0;
            int n = matrix.Length, row = n - 1, col = 0;
            while (row >= 0 && col < n)
            {
                if (matrix[row][col] > mid)
                {
                    smallLargePair[1] = Math.Min(smallLargePair[1], matrix[row][col]);
                    row--;
                }
                else
                {
                    smallLargePair[0] = Math.Max(smallLargePair[0], matrix[row][col]);
                    count += row + 1;
                    col++;
                }
            }
            return count;
        }
    }
}
