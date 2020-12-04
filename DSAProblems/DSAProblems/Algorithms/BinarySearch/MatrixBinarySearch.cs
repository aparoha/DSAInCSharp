using System;

namespace DSAProblems.Algorithms.BinarySearch
{
    class MatrixBinarySearch
    {
        //https://www.callicoder.com/sorted-2d-matrix-search/
        //https://www.programcreek.com/2013/01/leetcode-search-a-2d-matrix-java/
        //https://www.callicoder.com/sorted-2d-matrix-search/
        //https://backtobackswe.com/platform/content/search-a-2d-sorted-matrix/solutions

        //Search in a row wise and column wise sorted matrix
        //    Input: mat[4][4] = { {10, 20, 30, 40},
        //                         {15, 25, 35, 45},
        //                         {27, 29, 37, 48},
        //                         {32, 33, 39, 50}};
        //    target = 29
        //    Output: Found at (2, 1)

        //Search in strictly sorted matrix,  first element of a row is greater than the last element of the previous row
        //Input: mat[3][4] = {
        //            {1,  5,  9,  11},
        //            {14, 20, 21, 26},
        //            {30, 34, 43, 50}
        //        }
        //    target = 43
        //    Output: Found at (2, 2)

        //Approach 1
        //Brute Force
            //iterate over all elements
            //O(rows * columns)
        //Approach 2
            //Binary search on each row & if any of the rows have an element then return index else return (-1,-1)
            //O(rows * log columns)
        //Approach 3
            //Rows and columns are placed in sorted order
            //Element present on left cell of the current element will be smaller than current value & element present below the current element will be greater than current value
            
            //Matrix 1
            //Consider element 29, left side element 27 < 29, below element 33 > 29
            //Start from top right corner [0,3] -> 40, compare target with 40 and move
            //if the current element is lesser than the target element then move in the cell below it (as below element will greater than the current element)
            //else move in left cell of the current element
            //In this case 40 > 29, move left (high--)
            //             30 > 29, move left (high--)
            //             20 < 29, move below (low++)
            //             43 == 43, found element
            // O(rows + columns)

            //Matrix 2
            //Start from top right corner [0,3] -> 11, compare target with 11 and move
            //if the current element is lesser than the target element then move in the cell below it (as below element will greater than the current element)
            //else move in left cell of the current element
            //In this case 11 < 43, move below (low++)
            //             26 < 43, move below (low++)
            //             50 > 43, move left (high--)
            //             25 < 29, move below (low++)
            //             29 == 29, found element
            // O(rows + columns)
        
        //Approach 3 - Stair Search  
        public Tuple<int, int> EfficientLinearTimeSearchOnGrid(int[,] grid, int target)
        {
            int rows = grid.GetLength(0);
            int columns = grid.GetLength(1);

            if (target < grid[0, 0] || target > grid[rows - 1, columns - 1])
            {
                return Tuple.Create(-1, -1);
            }

            int low = 0, high = columns - 1;
            while (low < rows && high >= 0)
            {
                if (grid[low, high] == target)
                {
                    return Tuple.Create(low, high);
                }
                if (grid[low, high] > target)
                {
                    high--;
                }
                else
                {
                    low++;
                }
            }
            return Tuple.Create(-1, -1);
        }
    }
}
