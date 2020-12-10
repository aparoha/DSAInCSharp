using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.DP
{
    //https://thealgorists.com/Algo/DynamicProgramming
    //https://jeffe.cs.illinois.edu/teaching/algorithms/book/03-dynprog.pdf
    class Fibonacci
    {
        //TC - O(2^n)
        //SC - O(n)
        public int Fib(int n)
        {
            if (n <= 2)
            {
                return n;
            }
            return Fib(n - 1) + Fib(n - 2);
        }

        //Memoization
        //TC - O(n)
        //SC - O(n)
        public long FibMemo(int n)
        {
            return FibMemoHelper(n, new Dictionary<int, long>()); //long to avoid overflow e.g. MemoFib(50)
        }

        private long FibMemoHelper(int n, Dictionary<int, long> memo)
        {
            if (memo.TryGetValue(n, out long result))
            {
                return result;
            }
            if (n <= 2)
            {
                return 1;
            }
            memo.Add(n, FibMemoHelper(n - 1, memo) + FibMemoHelper(n - 2, memo));
            return memo[n];
        }
    }
}
