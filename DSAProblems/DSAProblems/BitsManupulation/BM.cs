using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.BitsManupulation
{
    //https://www.freecodecamp.org/news/algorithmic-problem-solving-efficiently-computing-the-parity-of-a-stream-of-numbers-cd652af14643/
    public class BM
    {
        public string IntToBinaryString(int n)
        {
            char[] b = new char[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                if ((n & (1 << i)) != 0) //Query ith bit
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b);
        }

        static string GetIntBinaryString(int value)
        {
            // Use Convert class and PadLeft.
            return Convert.ToString(value, 2).PadLeft(32, '0');
        }

        //00000000000000000000000000101001
        //00000000000000000000000000101001
        //00000000000000000000000000101000
        //00000000000000000000000000101000
        //True
        public void calculateMasks()
        {
            int n = 41;
            int i = 1;
            int j = 1;
            int k = 1;
            int m = 1;

            int ON_MASK = 1 << i - 1;
            int OFF_MASK = ~(1 << j - 1);
            int TOGGLE_MASK = 1 << k - 1;
            int QUERY_MASK = 1 << m - 1;

            Console.WriteLine(GetIntBinaryString(n));
            Console.WriteLine(GetIntBinaryString(n | ON_MASK));
            Console.WriteLine(GetIntBinaryString(n & OFF_MASK));
            Console.WriteLine(GetIntBinaryString(n ^ TOGGLE_MASK));
            Console.WriteLine((n & QUERY_MASK) == 0 ? false : true);
            Console.ReadLine();
        }

        //Right most set bit mask
        // X & Two's complement of X
        public int GetRightMostBitMask(int n)
        {
            int rsb = n & -n;
            return rsb;
        }

        //Kernighan's Algorithm
        public int GetAllSetBitsApproach1(int n)
        {
            int counter = 0;
            while(n != 0)
            {
                int rightMostSetBitMask = GetRightMostBitMask(n);
                n = n - rightMostSetBitMask;
                counter++;
            }
            return counter;
        }

//       Subtracting 1 from a decimal number flips all the bits after the rightmost 
//       set bit(which is 1) including the rightmost set bit.
//      for example : 10 in binary is 00001010, 9 in binary is 00001001
//      So if we subtract a number by 1 and do bitwise & with itself(n & (n-1)), 
//      we unset the rightmost set bit.If we do n & (n-1) in a loop and 
//      count the no of times loop executes we get the set bit count.
        public int GetAllSetBitsApproach2(int n)
        {
            int counter = 0;
            while (n != 0)
            {
                n &= (n - 1);
                counter++;
            }
            return counter;
        }
    }
}
