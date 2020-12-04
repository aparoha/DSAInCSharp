using System;
using System.Linq;

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
        //Approach 3 - Stair Search
            //Rows and columns are placed in sorted order
            //Element present on left cell of the current element will be smaller than current value & element present below the current element will be greater than current value
            
            //Matrix 1
            //Consider element 29, left side element 27 < 29, below element 33 > 29
            //Start from top right corner [0,3] -> 40, compare target with 40 and move
            //if the current element is lesser than the target element then move in the cell below it (as below element will greater than the current element)
            //else move in left cell of the current element
            //In this case 40 > 29, move left (column--)
            //             30 > 29, move left (column--)
            //             20 < 29, move below (row++)
            //             43 == 43, found element
            // O(rows + columns)

            //Matrix 2
            //Start from top right corner [0,3] -> 11, compare target with 11 and move
            //if the current element is lesser than the target element then move in the cell below it (as below element will greater than the current element)
            //else move in left cell of the current element
            //In this case 11 < 43, move below (row++)
            //             26 < 43, move below (row++)
            //             50 > 43, move left (column--)
            //             25 < 29, move below (row++)
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

            int row = 0, column = columns - 1;
            while (row < rows && column >= 0)
            {
                if (grid[row, column] == target)
                {
                    return Tuple.Create(row, column);
                }
                if (grid[row, column] > target)
                {
                    column--;
                }
                else
                {
                    row++;
                }
            }
            return Tuple.Create(-1, -1);
        }

        //Binary Search
        //  {
        //      {15, 20, 70, 85},
        //      {20, 35, 80, 95},
        //      {30, 55, 95, 105},
        //      {40, 80, 100, 120}
        //  }

        //Every row and column is sorted
        //element arr[i,j] will be greater than the elements in row i between columns 0 and j - 1 and 
        //the elements in column j between rows 0 and i - 1
        //e.g. arr[2,2] => 95, it is greater than 
        //elements in row 2 (between columns 0 - 1) and
        //elements in column 2 (between rows 0 - 1)
    }
}
