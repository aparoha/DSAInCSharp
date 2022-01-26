using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures
{
    public class GridProblems
    {
        /*LC 1091
         * Given an n x n binary matrix grid, return the length of the shortest clear path in the matrix. If there is no clear path, return -1.
         * A clear path in a binary matrix is a path from the top-left cell (i.e., (0, 0)) to the bottom-right cell (i.e., (n - 1, n - 1)) such that:
         * All the visited cells of the path are 0.
         * All the adjacent cells of the path are 8-directionally connected (i.e., they are different and they share an edge or a corner).
         * The length of a clear path is the number of visited cells of this path.
         * 
         */
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int rows = grid.Length, columns = grid[0].Length;
            if (grid[rows - 1][columns - 1] == 1 || grid[0][0] == 1)
                return -1;
            (int, int)[] directions = new (int, int)[] { (0, 1), (0, -1), (1, 0), (-1, 0), (1, -1), (-1, 1), (-1, -1), (1, 1) };
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            var coordinates = new Queue<(int, int)>();
            coordinates.Enqueue((0, 0));
            visited.Add((0, 0));
            int result = 0;
            while (coordinates.Count > 0)
            {
                int size = coordinates.Count;
                for (int i = 0; i < size; i++)
                {
                    (int currentRow, int currentColumn) = coordinates.Dequeue();
                    if (currentRow == rows - 1 && currentColumn == columns - 1)
                        return result + 1;
                    foreach ((int, int) direction in directions)
                    {
                        int nextRow = currentRow + direction.Item1;
                        int nextColumn = currentColumn + direction.Item2;
                        if (IsValidMove(grid, rows, columns, visited, nextRow, nextColumn))
                        {
                            coordinates.Enqueue((nextRow, nextColumn));
                            visited.Add((nextRow, nextColumn));
                        }
                    }
                }
                result++;
            }
            return -1;
        }

        private bool IsValidMove(int[][] grid, int rows, int columns, HashSet<(int, int)> visited, int nextRow, int nextColumn)
        {
            return nextRow >= 0 && nextRow < rows && 
                nextColumn >= 0 && nextColumn < columns && 
                !visited.Contains((nextRow, nextColumn)) &&
                grid[nextRow][nextColumn] == 0;
        }

        /*
         *Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
         *An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

        Input: grid = [
          ["1","1","1","1","0"],
          ["1","1","0","1","0"],
          ["1","1","0","0","0"],
          ["0","0","0","0","0"]
        ]
        Output: 1
        Example 2:

        Input: grid = [
          ["1","1","0","0","0"],
          ["1","1","0","0","0"],
          ["0","0","1","0","0"],
          ["0","0","0","1","1"]
        ]
        Output: 3 
         * 
         * 
         * 
        */
        public int NumIslands(char[][] grid)
        {
            if(grid == null || grid.Length == 0)
                return 0;
            int rows = grid.Length;
            int columns = grid[0].Length;
            int result = 0;
            for(int row = 0; row < rows; row++)
            {
                for(int column = 0; column < columns; column++)
                {
                    if(grid[row][column] == '1')
                    {
                        result++;
                        dfs(grid, row, column);
                    }
                }
            }
            return result;
        }

        private void dfs(char[][] grid, int row, int column)
        {
            (int, int)[] directions = new (int, int)[] { (-1, 0), (1, 0), (0, 1), (0, -1)};
            foreach((int, int) direction in directions)
            {
                int nextRow = direction.Item1 + row;
                int nextColumn = direction.Item2 + column;
                if (IsValidMove(grid, grid.Length, grid[0].Length, nextRow, nextColumn))
                {
                    grid[nextRow][nextColumn] = '0';
                    dfs(grid, nextRow, nextColumn);
                }
            }
        }

        private bool IsValidMove(char[][] grid, int rows, int columns, int nextRow, int nextColumn)
        {
            return nextRow >= 0 && nextRow < rows &&
                nextColumn >= 0 && nextColumn < columns &&
                grid[nextRow][nextColumn] != '0';
        }

        public int OrangesRotting(int[][] grid)
        {
            int rows = grid.Length;
            int columns = grid[0].Length;
            int fresh = 0;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (grid[row][column] == 2)
                        queue.Enqueue((row, column));
                    if (grid[row][column] == 1)
                        fresh++;
                }
            }
            if (fresh == 0)
                return 0;
            (int, int)[] directions = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            int minutes = -1;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                minutes++;
                while (size-- > 0)
                {
                    (int currentRow, int currentColumn) = queue.Dequeue();
                    foreach ((int row, int column) direction in directions)
                    {
                        int nextRow = currentRow + direction.row;
                        int nextColumn = currentColumn + direction.column;
                        if (nextRow >= 0 && nextColumn >= 0 && nextRow < rows && nextColumn < columns && grid[nextRow][nextColumn] == 1)
                        {
                            queue.Enqueue((nextRow, nextColumn));
                            grid[nextRow][nextColumn] = 2;
                            fresh--;
                        }
                    }
                }
            }
            return fresh == 0 ? minutes : -1;
        }
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int rows = image.Length;
            int cols = image[0].Length;
            var queue = new Queue<(int Row, int Col)>();
            var directions = new List<(int, int)>() { (-1, 0), (0, -1), (0, 1), (1, 0) };
            int oldColor = image[sr][sc];
            if (oldColor == newColor)
                return image;
            queue.Enqueue((sr, sc));
            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();
                image[cell.Row][cell.Col] = newColor;
                foreach (var direction in directions)
                {
                    int r = cell.Row + direction.Item1;
                    int c = cell.Col + direction.Item2;
                    if (r >= 0 && r < rows && c >= 0 && c < cols && image[r][c] == oldColor)
                        queue.Enqueue((r, c));
                }
            }
            return image;
        }
    }
}
