using System.Linq;

namespace DSAProblems.LeetCode.BinarySearch
{
    //Count Negative Numbers in a Sorted Matrix
    //Given a m * n matrix grid which is sorted in non-increasing order both row-wise and column-wise. 
    //Return the number of negative numbers in grid.

    //Example 1:
    //Input: grid = [[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]
    //Output: 8
    //Explanation: There are 8 negatives number in the matrix.

    //Example 2:
    //Input: grid = [[3,2],[1,0]]
    //Output: 0

    //Example 3:
    //Input: grid = [[1,-1],[-1,-1]]
    //Output: 3

    //Example 4:
    //Input: grid = [[-1]]
    //Output: 1
    class LeetCode1351
    {
        //TC - O(rows * columns)
        public int CountNegativesBruteForce(int[][] grid)
        {
            if(grid == null){
                return 0;
            }
        
            int count = 0;
        
            for(int row = 0; row < grid.Length; row++) {
                for(int col = 0; col < grid[row].Length; col++) {
                    if(grid[row][col] < 0) {
                        count++;
                    }
                }
            }
        
            return count;
        }

        //Binary search each row
        //TC - O(rows * log(columns))
        //        var jagged = new[]
        //        {
        //            new[] {4, 3, 2, -1},
        //            new[] {3, 2, 1, -1},
        //            new[] {1, 1, -1, -2},
        //            new[] {-1, -1, -2, -3}
        //        };
        //row [4,3,2,-1]
        //left    right   mid   row[mid]
        //0         4       2       2
        //3         4       3       -1
        //3         3       3       -1 (loop closed) sum = 4 - 3 = 1
        //row [3,2,1,-1]
        //left    right   mid   row[mid]
        //0         4       2       1
        //3         4       3       -1
        //3         3       3       -1  (loop closed) sum = sum + (4 - 3) = 1 + 1 = 2
        //row [1,1,-1,-2]
        //left    right   mid   row[mid]
        //0         4       2       -1
        //0         2       1       1
        //2         2       2       -1 (loop closed) sum = sum + (4 - 2) = 2 + 2 = 4
        //row [-1,-1,-2,-3]
        //left    right   mid   row[mid]
        //0         4       2       -2
        //0         2       1       -1
        //0         1       0       -1
        //0         0       0       -1 (loop closed) sum = sum + (4 - 0) = 4 + 4 = 8
        public int CountNegativesBs(int[][] grid) {
            if(grid == null){
                return 0;
            }
        
            int sum = 0;
            foreach(int[] row in grid){
                int left = 0;
                int right = row.Length - 1;
                while(left <= right){
                    int mid = left + (right - left) / 2;
                
                    if(row[mid] < 0)
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                sum += row.Length - left;
            }
            return sum;
        }

        //TC - O(rows * columns)
        public int CountNegativesLinq(int[][] grid) {
            if(grid == null){
                return 0;
            }

            return grid.Sum(t => t.Count(t1 => t1 < 0));
        }
    }
}
