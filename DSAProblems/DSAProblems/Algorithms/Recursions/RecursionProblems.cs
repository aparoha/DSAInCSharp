using System;
using System.Collections.Generic;

namespace DSAProblems.Algorithms.Recursions
{
    public class RecursionProblems
    {
        public void PrintDecreasing(int n)
        {
            if(n == 0) return;
            Console.WriteLine(n);
            PrintDecreasing(n - 1);
        }

        public void PrintIncreasing(int n)
        {
            if (n == 0) return;
            PrintIncreasing(n - 1);
            Console.WriteLine(n);
        }

        public int SumOneToN(int n)
        {
            if(n == 0)
                return 0;
            int current = n + SumOneToN(n - 1);
            return current;
        }

        public int SumOfDigits(int n)
        {
            //last digit => (n % 10)
            //Remaining digits => n / 10
            if (n == 0) return 0;
            int currentSum = (n % 10) + SumOfDigits(n / 10);
            return currentSum;
        }

        public int ProductOfDigits(int n)
        {
            //last digit => (n % 10)
            //Remaining digits => n / 10
            if (n % 10 == n) return n;
            int product = (n % 10) * ProductOfDigits(n / 10);
            return product;
        }

        //public int ReverseNumber(int n)
        //{
        //    int lastDigit = (n % 10) + ReverseNumber(n);
        //}

        public void PrintDecreasingIncreasing(int n)
        {
            if (n == 0) return;
            Console.WriteLine(n);
            PrintDecreasingIncreasing(n - 1);
            Console.WriteLine(n);
        }

        public int Factorial(int n)
        {
            if (n == 1) return 1;
            int fnm1 = Factorial(n -1);
            int fn = n * fnm1;
            return fn;
        }

        public int Power(int x, int n)
        {
            if(n == 0) return 1;
            int xnm1 = Power(x, n - 1);
            int xn = x * xnm1;
            return xn;
        }

        public int PowerL(int x, int n)
        {
            if (n == 0) return 1;
            int xpnb2 = PowerL(x, n / 2);
            int xn = xpnb2 * xpnb2;
            if (n % 2 == 1)
                xn = xn * x;
            return xn;
        }

        //Pre 2, Pre 1, In 1, In 2
        public void PrintZigZag(int n)
        {
            if(n == 0) return;
            Console.WriteLine("Pre " + n);
            PrintZigZag(n -1);
            Console.WriteLine("In " + n);
            PrintZigZag(n - 1);
            Console.WriteLine("Post " + n);
        }

    }
}
