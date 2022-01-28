using System;
using System.Collections.Generic;
using System.Text;

namespace DSAProblems.Algorithms.Recursions
{

    /* 1. Print name given times
     * 2. Print from 1 to N
     * 3. Print from N to 1
     * 4. Print from 1 to N - backtracking
     * 5. Print from N to 1 - backtracking
     * 6. Sum of first N
     * 7. Reverse string or array
     * 8. String Palindrome
     * https://quanticdev.com/algorithms/primitives/subarray-vs-substring-vs-subsequence-vs-subset/
     * 9. Print all subsequences
     *      A subsequence is a sequence that can be derived from another sequence by deleting some elements without changing the order of the remaining elements. 
     *      A subsequence need not to be contiguous
     *      [1,2,3,4]
     *      For the same example, there are 15 sub-sequences. They are 
     *      (1), (2), (3), (4), (1,2), (1,3),(1,4), (2,3), (2,4), (3,4), (1,2,3), (1,2,4), (1,3,4), (2,3,4), (1,2,3,4). 
     *      More generally, we can say that for a sequence of size n, we can have (2^n-1) non-empty sub-sequences in total. 
     * 
     * Comparison Table
 	                    Subarray	Substring	Subsequence	    Subset
    Contiguous	        Yes	        Yes	        No	            No
    Elements Ordered	Yes	        Yes	        Yes	            No
     * 10. Print all subsequences with sum K
     * 
    */
    public class RecursionProblems
    {
        //TC - O(n), SC - O(n) where n is the target
        public void PrintName(int target)
        {
            PrintNameUtil(0, target);
        }

        public void PrintNameUtil(int count, int target)
        {
            if (count == target)
                return;
            Console.WriteLine("Abhay ");
            count++;
            PrintNameUtil(count, target); //or do PrintName(++count, target);
        }

        public void PrintTillN(int n)
        {
            PrintTillNInternal(0, n);
        }

        private void PrintTillNInternal(int count, int target)
        {
            if (count == target)
                return;
            count++;
            Console.Write(count);
            PrintTillNInternal(count, target);
        }

        public void PrintNTo1(int n)
        {
            PrintNTo1Internal(n, n);
        }

        private void PrintNTo1Internal(int count, int target)
        {
            if (count == 0)
                return;
            Console.WriteLine(count);
            count--;
            PrintNTo1Internal(count, target);
        }

        public void PrintNTo1WithoutMinus(int n)
        {
            PrintNTo1WithoutMinusInternal(1, n);
        }

        public void PrintNTo1WithoutMinusInternal(int count, int target)
        {
            if (count > target)
                return;
            PrintNTo1WithoutMinusInternal(count + 1, target);
            Console.WriteLine(count);
        }

        public void Print1ToNWithoutPlus(int n)
        {
            Print1ToNWithoutPlusInternal(n, n);
        }

        public void Print1ToNWithoutPlusInternal(int count, int target)
        {
            if (count < 1)
                return;
            Print1ToNWithoutPlusInternal(count - 1, target);
            Console.WriteLine(count);
        }

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

        public int[] Reverse(int[] arr)
        {
            int n = arr.Length;
            ReverseInternal(arr, 0, n - 1);
            return arr;
        }

        private void ReverseInternal(int[] arr, int left, int right)
        {
            if (left >= right)
                return;
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            ReverseInternal(arr, left + 1, right - 1);
        }

        public static bool IsPalindrome2(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length == 1)
                return true;
            if (str[0] == str[str.Length - 1])
                return IsPalindrome2(str.Substring(1, str.Length - 2));
            return false;
        }

        public static bool IsPalindrome(string str)
        {
            return IsPalindromeInternal(str, 0, str.Length - 1);
        }

        public static bool IsPalindromeInternal(string str, int left, int right)
        {
            if (left >= right)
                return true;
            if (str[left] != str[right])
                return false;
            return IsPalindromeInternal(str, left + 1, right - 1);
        }

        //Take / Not take pattern
        //Approach: For every element in the array, there are two choices, either to include it in the subsequence or not include it. Apply this for every element in the array starting from index 0 until we reach the last index.
        //Print the subsequence once the last index is reached. 
        //TC - 2^n, SC - n
        public List<List<int>> GetAllSubsequences(int[]  arr)
        {
            List<List<int>> result = new List<List<int>>();
            Dfs(0, new List<int>());
            void Dfs(int index, List<int> current)
            {
                if (index == arr.Length)
                {
                    result.Add(new List<int>(current));
                    return;
                }
                current.Add(arr[index]);
                Dfs(index + 1, current); // Take current element in result
                current.RemoveAt(current.Count - 1);
                Dfs(index + 1, current); // Not Take current element in result
            }
            return result;
        }

        public List<List<int>> GetAllSubsequencesWithSumK(int[] arr, int k)
        {
            List<List<int>> result = new List<List<int>>();
            Dfs(0, new List<int>(), 0);
            void Dfs(int index, List<int> current, int currentSum)
            {
                if (index == arr.Length)
                {
                    if (currentSum == k)
                        result.Add(new List<int>(current));
                    return;
                }
                current.Add(arr[index]);
                currentSum += arr[index];
                Dfs(index + 1, current, currentSum); // Take current element in result
                current.RemoveAt(current.Count - 1);
                currentSum -= arr[index];
                Dfs(index + 1, current, currentSum); // Not Take current element in result
            }
            return result;
        }

        public List<List<int>> GetOneSubsequenceSumK(int[] arr, int k)
        {
            List<List<int>> result = new List<List<int>>();
            Dfs(0, new List<int>(), 0);
            bool Dfs(int index, List<int> current, int currentSum)
            {
                if (index == arr.Length)
                {
                    if (currentSum == k)
                    {
                        result.Add(new List<int>(current));
                        return true;
                    }
                    return false;
                }
                current.Add(arr[index]);
                currentSum += arr[index];
                if(Dfs(index + 1, current, currentSum)) // Take current element in result
                    return true;
                current.RemoveAt(current.Count - 1);
                currentSum -= arr[index];
                if(Dfs(index + 1, current, currentSum)) // Not Take current element in result
                    return true;
                return false;
            }
            return result;
        }

        public int CountAllSubsequenceSumK(int[] arr, int k)
        {
            int result = Dfs(0, 0);
            int Dfs(int index, int currentSum)
            {
                if (index == arr.Length)
                {
                    if (currentSum == k)
                        return 1;
                    return 0;
                }
                currentSum += arr[index];
                int left = Dfs(index + 1, currentSum);
                currentSum -= arr[index];
                int right = Dfs(index + 1, currentSum);
                return left + right;
            }
            return result;
        }



        //N-Ary tree approach
        public void PrintAllSubsequences(int[] arr)
        {
            int[] p = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                PrintHelper(arr, i, p, 0);
            }
        }

        private void PrintHelper(int[] arr, int index, int[] p, int pi)
        {
            if (index >= arr.Length)
                return;
            p[pi] = arr[index];
            PrintPath(p, pi);
            for (int i = index + 1; i < arr.Length; i++)
                PrintHelper(arr, i, p, pi + 1);
        }

        private void PrintPath(int[] arr, int lastIndex)
        {
            for (int i = 0; i <= lastIndex; i++)
                Console.Write(arr[i]);
            Console.Write("\n");
        }

        public List<List<int>> GetAllSubsequences4(int[] arr)
        {
            List<List<int>> result = new List<List<int>>();
            Dfs(arr, result, new List<int>(), 0);
            return result;
        }

        private void Dfs(int[] arr, List<List<int>> result, List<int> current, int index)
        {
            result.Add(new List<int>(current));
            for (int i = index; i < arr.Length; i++)
            {
                current.Add(arr[i]);
                Dfs(arr, result, current, i + 1);
                current.RemoveAt(current.Count-1);
            }
        }

        /*Consider a rat placed at (0, 0) in a square matrix of order N * N. It has to reach the destination at (N - 1, N - 1). Find all possible paths that the rat can take to reach from source to destination. The directions in which the rat can move are 'U'(up), 'D'(down), 'L' (left), 'R' (right). Value 0 at a cell in the matrix represents that it is blocked and rat cannot move to it while value 1 at a cell in the matrix represents that rat can be travel through it.
            Note: In a path, no cell can be visited more than one time.

            Example 1:

            Input:
            N = 4
            m[][] = {{1, 0, 0, 0},
                     {1, 1, 0, 1}, 
                     {1, 1, 0, 0},
                     {0, 1, 1, 1}}
            Output:
            DDRDRR DRDDRR
            Explanation:
            The rat can reach the destination at 
            (3, 3) from (0, 0) by two paths - DRDDRR 
            and DDRDRR, when printed in sorted order 
            we get DDRDRR DRDDRR.
            Example 2:
            Input:
            N = 2
            m[][] = {{1, 0},
                     {1, 0}}
            Output:
            -1
            Explanation:
            No path exists and destination cell is 
            blocked.
         * 
         * 
        */
        public List<string> GetAllPathsRatInAMaze(int[][] maze, int n)
        {
            //Lexicographic order - Down Left Right Up
            List<string> result = new List<string>();
            (int, int)[] directions = new (int, int)[] { (1, 0), (0, -1), (0, 1), (-1, 0) };
            bool[,] visited = new bool[n,n];
            if(maze[0][0] == 1)
                Solve(0, 0, maze, n, result, "", visited, directions);
            return result;
        }

        private void Solve(int row, int column, int[][] maze, int n, List<string> result,
            string move, bool[,] visited, (int, int)[] directions)
        {
            var sb = new StringBuilder();
            if(row == n -1 && column == n - 1)
            {
                result.Add(move);
                return;
            }
            string dir = "DLRU";
            for(int index = 0; index < directions.Length; index++)
            {
                int nextRow = row + directions[index].Item1;
                int nextColumn = column + directions[index].Item2;
                if (nextRow < 0 || nextColumn < 0 || nextRow >= n || nextColumn >= n ||
                    visited[nextRow, nextColumn] || maze[nextRow][nextColumn] != 1)
                {
                    continue;
                }
                visited[row, column] = true;
                Solve(nextRow, nextColumn, maze, n, result, move + dir[index], visited, directions);
                visited[row, column] = false;
            }
        }

        public int FirstIndexOfArray(int[] arr, int data)
        {
            int result = FirstIndexOfArrayInternal(arr, data, 0);
            return result;
        }

        private int FirstIndexOfArrayInternal(int[] arr, int data, int index)
        {
            if (index == arr.Length)
                return -1;
            if (arr[index] == data)
                return index;
            else
                return FirstIndexOfArrayInternal(arr, data, index + 1);
        }

        public int LastIndexOfArray(int[] arr, int data)
        {
            int result = LastIndexOfArrayInternal(arr, data, 0);
            return result;
        }

        private int LastIndexOfArrayInternal(int[] arr, int data, int index)
        {
            if(index == arr.Length)
                return -1;
            int indexFromOneToN = LastIndexOfArrayInternal(arr, data, index + 1);
            if(indexFromOneToN == -1)
            {
                if(arr[index] == data)
                    return index;
                else
                    return -1;
            } else
                return indexFromOneToN;
        }

        public int[] GetAllIndices(int[] arr, int data)
        {
            return GetAllIndices(arr, data, 0, 0);
        }

        private int[] GetAllIndices(int[] arr, int data, int index, int foundSoFar)
        {
            if(index == arr.Length)
                return new int[foundSoFar];
            if(arr[index] == data)
            {
                int[] iarr = GetAllIndices(arr, data, index + 1, foundSoFar + 1);
                iarr[foundSoFar] = index;
                return iarr;
            } 
            else
            {
                int[] iarr = GetAllIndices(arr, data, index + 1, foundSoFar);
                return iarr;
            }
        }

        public List<string> GetStringSubsequences(string s)
        {
            if(s.Length == 0)
            {
                List<string> baseResult = new List<string>();
                baseResult.Add(string.Empty);
                return baseResult;
            }
            
            char ch = s[0];
            string restOfString = s.Substring(1);
            List<string> restOfResult = GetStringSubsequences(restOfString);

            List<string> result = new List<string>();
            foreach(var str in restOfResult)
            {
                result.Add("" + str);
                result.Add(ch + str);
            }
            return result;
        }

        public List<string> GetAllSubsequences(string str)
        {
            List<string> result = new List<string>();
            Dfs(0, new StringBuilder());
            void Dfs(int index, StringBuilder current)
            {
                if (index == str.Length)
                {
                    result.Add(current.ToString());
                    return;
                }
                current.Append(str[index]);
                Dfs(index + 1, current); // Take current element in result
                current.Remove(current.Length - 1, 1);
                Dfs(index + 1, current); // Not Take current element in result
            }
            return result;
        }

        //Print all paths from n to 0 when we cna take 1, 2 or 3 steps
        public List<string> GetStairPaths(int n)
        {
            if(n == 0)
                return new List<string>(){ string.Empty };
            else if(n < 0)
                return new List<string>();

            List<string> nMinusOneToZeroPaths = GetStairPaths(n - 1);
            List<string> nMinusTwoToZeroPaths = GetStairPaths(n - 2);
            List<string> nMinusThreeToZeroPaths = GetStairPaths(n - 3);

            List<string> paths = new List<string>();
            foreach(var path in nMinusOneToZeroPaths)
                paths.Add(1 + path);

            foreach (var path in nMinusTwoToZeroPaths)
                paths.Add(2 + path);

            foreach (var path in nMinusThreeToZeroPaths)
                paths.Add(3 + path);

            return paths;
        }

        public List<string> GetMazePaths(int sourceRow, int sourceColumn, int dr, int dc)
        {
            if(sourceRow == dr && sourceColumn == dc)
            {
                return new List<string>() { string.Empty };
            }

            List<string> verticalPaths = new List<string>();
            List<string> horizontalPaths = new List<string>();

            if(sourceRow < dr)
                verticalPaths = GetMazePaths(sourceRow + 1, sourceColumn, dr, dc);

            if(sourceColumn < dc)
                horizontalPaths = GetMazePaths(sourceRow, sourceColumn + 1, dr, dc);

            List<string> paths = new List<string>();
            foreach(var path in horizontalPaths)
                paths.Add("H" + path);
            foreach (var path in verticalPaths)
                paths.Add("V" + path);

            return paths;
        }

        //How to handle duplicates and return result in lexicographically order?
        //e.g. AABC - 12 outputs
        //AABC, AACB, ABAC, ABCA, ACAB, ACBA, BAAC, BACA, BCAA, CAAB, CABA, CBAA
        //Formula - 4!/2! = 12 (as A is duplicated 2 times so divided by 2!)
        //For AABBBC - 6!/2! * 3! (as A came 2 times and B came 3 times)
        public List<string> GetPermutations(string str)
        {
            List<string> result = new List<string>();
            GetPermutationsInternal(str, string.Empty, result);
            return result;
        }

        private void GetPermutationsInternal(string input, string resultSoFar, List<string> result)
        {
            if(input.Length == 0)
            {
                result.Add(resultSoFar);
                return;
            }
            //How many choices we have? - no of characters in original string
            for(int index = 0; index < input.Length; index++)
            {
                //abcdefghi -> ch is d, left substring is "abc", right substring is "efghi"
                char ch = input[index]; //choose character
                string leftSubString = input.Substring(0, index);
                string rightSubString = input.Substring(index + 1);
                string restOfInput = leftSubString + rightSubString;
                //bc  a    null
                //c   ab   null 
                //""  abc  null
                //b   ac   abc 
                //""  acb  abc 
                //ac  b    abc, acb
                GetPermutationsInternal(restOfInput, resultSoFar + ch, result);
            }
        }

        public List<string> Permute(string str)
        {
            var answer = new List<string>();
            int n = str.Length;
            Ank(str, n, 2, 0, new bool[n], new StringBuilder(), answer);
            return answer;
        }

        private static void Ank(string str, int n, int k, int depth, bool[] used, StringBuilder current, List<string> answer)
        {
            if (k == depth)
            {
                answer.Add(current.ToString());
                return;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (used[i])
                        continue;
                    //Generate the next solution from current
                    current.Append(str[i]);
                    used[i] = true;
                    Console.WriteLine(string.Join(",", current));
                    Ank(str, n, k, depth + 1, used, current, answer);
                    //Backtrack to the previous partial state
                    current.Remove(current.Length - 1, 1);
                    Console.WriteLine($"Backtrack {string.Join(",", current)}");
                    used[i] = false;
                }
            }
        }


    }
}
