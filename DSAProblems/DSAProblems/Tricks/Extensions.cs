using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Tricks
{
    //https://www.techiedelight.com/get-subarray-of-array-csharp/
    public static class Extensions
    {
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        public static T[] SubArray2<T>(this T[] array, int offset, int length)
        {
            return array.Skip(offset)
                .Take(length)
                .ToArray();
        }

        public static T[] SubArray3<T>(this T[] array, int offset, int length)
        {
            return new ArraySegment<T>(array, offset, length)
                .ToArray();
        }

        public static T[] SubArray4<T>(this T[] array, int offset, int length)
        {
            return new List<T>(array)
                .GetRange(offset, length)
                .ToArray();
        }

        public static void Init<T>(this T[,] board) where T : new()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i,j] = new T();
                }
            }
        }
    }
}
