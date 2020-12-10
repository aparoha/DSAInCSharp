using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.DP
{
    class GridTraveler
    {
        //Recursive
        //TC - O(2^(m+n))
        //SC - O(m+n)
        public int GetTotalPathsInGrid(int m, int n)
        {
            if (m == 1 && n == 1) return 1;
            if (m == 0 || n == 0) return 0;
            //(m-1,n) - reducing row by 1
            //(m,n-1) - reducing column by 1
            return GetTotalPathsInGrid(m - 1, n) + GetTotalPathsInGrid(m, n - 1);
        }

        //TC - O(m * n)
        //SC - O(m + n)
        public long GetTotalPathsInGridMemo(int m, int n)
        {
            return GetTotalPathsInGridMemoHelper(m, n, new Dictionary<string, long>());
        }

        private long GetTotalPathsInGridMemoHelper(int m, int n, Dictionary<string, long> memo)
        {
            string key = $"{m},{n}";
            if (memo.TryGetValue(key, out long result))
            {
                return result;
            }
            if (m == 1 && n == 1) return 1;
            if (m == 0 || n == 0) return 0;
            memo.Add(key, GetTotalPathsInGridMemoHelper(m - 1, n, memo) + GetTotalPathsInGridMemoHelper(m, n -1, memo));
            return memo[key];
        }
    }
}
