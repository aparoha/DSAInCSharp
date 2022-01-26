using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures
{
    public class MultidimensionalArrayProblems
    {
        public void PrintRowWise()
        {
            //Row, Column
            //Always fill row wise
            int[,] array2D = new int[,] 
            { 
                { 1, 2, 3 }, 
                { 4, 5, 6 }, 
                { 7, 8, 9 }, 
                { 10, 11, 12 } 
            };

            for(int row = 0; row < array2D.GetLength(0); row++)
                for(int column = 0; column < array2D.GetLength(1); column++)
                    Console.WriteLine(array2D[row, column]);

        }

        public void PrintColumnWise()
        {
            //Row, Column
            int[,] array2D = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { 10, 11, 12 }
            };

            for (int column = 0; column < array2D.GetLength(1); column++)
                for (int row = 0; row < array2D.GetLength(0); row++)
                    Console.WriteLine(array2D[row, column]);
        }

        public int[] SumOfUpperAndLowerTriangles(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int[] result = new int[2];
            int upperSum = 0, lowerSum = 0;
            for(int row = 0; row < rows; row++)
            {
                for(int column = 0; column <= row; column++)
                {
                    lowerSum += arr[row, column];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int column = rows - 1; column >= row; column--)
                {
                    upperSum += arr[row, column];
                }
            }
            result[0] = lowerSum;
            result[1] = upperSum;
            return result;
    }
}
}
