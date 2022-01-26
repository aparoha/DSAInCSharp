using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSAProblems.Algorithms.BinarySearch;
using DSAProblems.Algorithms.Recursions;
using DSAProblems.Algorithms.Sorting;
using DSAProblems.DataStructures;
using DSAProblems.DataStructures.Heaps;
using DSAProblems.DataStructures.LinkedList;
using DSAProblems.DataStructures.PriorityQueue;
using DSAProblems.DynamicProgramming;
using DSAProblems.LeetCode.BFS;

namespace DSAProblems
{
    public class TreeAncestor
    {
        private int _n;
        private int[] _parents;
        private Dictionary<int, List<int>> _pathMap = new Dictionary<int, List<int>>();
        private Dictionary<int, List<int>> _children = new Dictionary<int, List<int>>();
        private int[] _depths;

        public TreeAncestor(int n, int[] parents)
        {
            _n = n;
            _parents = parents;
            _depths = new int[_n];
            int root = -1;
            for (int i = 0; i < n; i++)
                _children.Add(i, new List<int>());
            for (int i = 0; i < _parents.Length; i++)
            {
                if (_parents[i] != -1)
                {
                    _children[_parents[i]].Add(i);
                }
                else
                    root = i;
            }
            traverse(root, -1, new List<int>(), 0);
        }

        private void traverse(int node, int parent, List<int> path, int depth)
        {
            _depths[node] = depth;
            if(_children.TryGetValue(node, out List<int> children))
            {
                if(children.Count == 0)
                {
                    if (!_pathMap.ContainsKey(parent))
                    {
                        var copy = new List<int>(path);
                        foreach (var n in copy)
                            _pathMap[n] = copy;
                        _pathMap[node] = copy;
                    }
                    else
                    {
                        _pathMap[node] = _pathMap[parent];
                    }
                }
                else
                {
                    path.Add(node);
                    foreach (var child in children)
                        traverse(child, node, path, depth + 1);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }

        public int GetKthAncestor(int node, int k)
        {
            List<int> list = _pathMap[node];
            int depth = _depths[node];
            int pos = depth - k;
            return pos >= 0 && pos < list.Count ? list[pos] : -1;
        }

    }
    public class MovingAverage
    {

        private Queue<int> _currentWindow;
        private int _size;
        private double _windowSum;

        public MovingAverage(int size)
        {
            _currentWindow = new Queue<int>();
            _size = size;
        }

        public double Next(int val)
        {
            int count = _currentWindow.Count;
            if (count == _size)
                _windowSum -= _currentWindow.Dequeue();
            _currentWindow.Enqueue(val);
            _windowSum += val;
            return _windowSum / count;
        }
    }
    public class GrpahNode
    {
        public char value { get; set;}
        public int distance {  get; set;}
        public GrpahNode parent {  get; set;}
    }

    public class KthLargest
    {
        private PriorityQueue<int, int> _minHeap;
        private int _kValue;

        public KthLargest(int k, int[] nums)
        {
            _minHeap = new PriorityQueue<int, int>();
            _kValue = k;
            foreach(var num in nums)
                _minHeap.Enqueue(num, num);
        }

        public int Add(int val)
        {
            _minHeap.Enqueue(val, val);
            while(_minHeap.Count > _kValue)
                _minHeap.Dequeue();
            return _minHeap.Peek();
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class SNode
    {
        public TreeNode current;
        public TreeNode parent;
        public char dir;
    }

    class Program
    {
        static void Main(string[] args)
        {
            QuickSelect qs = new QuickSelect();
            var arr = new int[] { 7, 2, 1, 8, 6, 3, 5, 4};
            Console.WriteLine($"Original Array {string.Join(",", arr)}");

            Console.WriteLine(qs.Median(new int[] { 32, 22, 55, 36, 50, 9 }));
            Console.WriteLine(qs.Median(new int[] { 32, 22, 9, 35, 50 }));

            Console.WriteLine(qs.KthSmallest(arr, 1));
            Console.WriteLine(qs.KthSmallest(arr, 2));
            Console.WriteLine(qs.KthSmallest(arr, 3));
            Console.WriteLine(qs.KthSmallest(arr, 4));
            Console.WriteLine(qs.KthSmallest(arr, 5));
            Console.WriteLine(qs.KthSmallest(arr, 6));
            Console.WriteLine(qs.KthSmallest(arr, 7));
            Console.WriteLine(qs.KthSmallest(arr, 8));

            Console.WriteLine(qs.KthLargest(arr, 1));
            Console.WriteLine(qs.KthLargest(arr, 2));
            Console.WriteLine(qs.KthLargest(arr, 3));
            Console.WriteLine(qs.KthLargest(arr, 4));
            Console.WriteLine(qs.KthLargest(arr, 5));
            Console.WriteLine(qs.KthLargest(arr, 6));
            Console.WriteLine(qs.KthLargest(arr, 7));
            Console.WriteLine(qs.KthLargest(arr, 8));
            var rp = new RecursionProblems();
            Console.WriteLine(string.Join(",", rp.GetStairPaths(3)));
            //var result = rp.GetAllSubsequences(new int[] { 1, 2, 3, 4 });
            //foreach(var r in result)
            //    Console.WriteLine(string.Join(",", r));
            //Console.WriteLine("**********");
            //result = rp.GetAllSubsequences4(new int[] { 1, 2, 3, 4 });
            //foreach (var r in result)
            //    Console.WriteLine(string.Join(",", r));
            //Console.WriteLine("**********");
            //result = rp.GetAllSubsequencesWithSumK(new int[] { 1, 2, 3, 4 }, 3);
            //foreach (var r in result)
            //    Console.WriteLine(string.Join(",", r));
            //Console.WriteLine("**********");
            //result = rp.GetOneSubsequenceSumK(new int[] { 1, 2, 3, 4 }, 3);
            //foreach (var r in result)
            //    Console.WriteLine(string.Join(",", r));
            //Console.WriteLine("**********");
            //Console.WriteLine(rp.CountAllSubsequenceSumK(new int[] { 1, 2, 3, 4 }, 3));

            _01_Fibonacci f = new _01_Fibonacci();
            Console.WriteLine(f.Fib(5));
            Console.WriteLine(f.FibMemo(5));
            Console.WriteLine(f.FibTabulation(5));
            Console.WriteLine(f.FibTabulationOptimize(5));
            //var paths = rp.GetAllPathsRatInAMaze(new int[][]
            //{
            //    new int[] { 1, 0, 0, 0},
            //    new int[] { 1, 1, 0, 1},
            //    new int[] { 1, 1, 0, 0},
            //    new int[] { 0, 1, 1, 1},
            //}, 4);
            //Console.WriteLine(string.Join(",", paths));
            //var result = Combination(new int[] {1, 2, 3}, 3);
            //foreach(var r in result)
            //    Console.WriteLine(string.Join(",", r));

            //var kthLargest = new KthLargest(3, new int[] {4, 5, 8, 2});
            //Console.WriteLine(kthLargest.Add(3));
            //Console.WriteLine(kthLargest.Add(5));
            //Console.WriteLine(kthLargest.Add(10));
            //Console.WriteLine(kthLargest.Add(9));
            //Console.WriteLine(kthLargest.Add(4));
            Console.ReadKey();
        }

        public static int FindLeastNumOfUniqueInts(int[] arr, int k)
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            foreach (var a in arr)
            {
                if (frequency.ContainsKey(a))
                    frequency[a]++;
                else
                    frequency.Add(a, 1);
            }

            var Keys = frequency.OrderBy(x => x.Value);

            int count = 0;
            int currentK = 0;

            foreach (var key in Keys)
            {
                if (frequency[key.Key] + currentK > k)
                    count++;
                else
                    currentK += frequency[key.Key];
            }
            return count;
        }
        public static bool IsPalindrome(string s)
        {
            s = s.ToLower();
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return true;
            if (!char.IsLetterOrDigit(s[0]))
                return IsPalindrome(s.Substring(1));
            if (!char.IsLetterOrDigit(s[s.Length - 1]))
                return IsPalindrome(s.Substring(0, s.Length - 1));
            if (s[0] == s[s.Length - 1])
                return IsPalindrome(s.Substring(1, s.Length - 2));
            return false;
        }

        public static IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Dfs(nums, result, new List<int>(), 0);
            return result;
        }

        public static IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(digits))
                return result;
            Dictionary<char, string> digitToCharMap = new Dictionary<char, string>()
            {
                { '2', "abc"},
                { '3', "def"},
                { '4', "ghi"},
                { '5', "jkl"},
                { '6', "mno"},
                { '7', "pqrs"},
                { '8', "tuv"},
                { '9', "wxyz"},
            };
            return Dfs(digits, digitToCharMap);
        }

        private static List<string> Dfs(string digits, Dictionary<char, string> digitToCharMap)
        {
            if (digits.Length == 0)
            {
                List<string> baseList = new List<string>();
                baseList.Add("");
                return baseList;
            }
            char ch = digits[0];
            string ros = digits.Substring(1);

            List<string> rres = Dfs(ros, digitToCharMap);
            List<string> mres = new List<string>();

            string codeforch = digitToCharMap[ch];
            for (int i = 0; i < codeforch.Length; i++)
            {
                foreach (var rstr in rres)
                    mres.Add(codeforch[i] + rstr);
            }
            return mres;
        }
        private static void Dfs(int[] arr, List<IList<int>> result, List<int> current, int index)
        {
            result.Add(new List<int>(current));
            Console.WriteLine($"Answer {string.Join(",", current)}");
            for (int i = index; i < arr.Length; i++)
            {
                current.Add(arr[i]);
                Console.WriteLine(string.Join(",", current));
                Dfs(arr, result, current, i + 1);
                current.RemoveAt(current.Count - 1);
                Console.WriteLine($"Backtrack {string.Join(",", current)}");
            }
        }

        public static IList<IList<int>> Combination(int[] nums, int k)
        {
            var answer = new List<IList<int>>();
            int n = nums.Length;
            Cnk(nums, n, k, 0, 0, new List<int>(), answer);
            return answer;
        }

        private static void Cnk(int[] nums, int n, int k, int start, int depth, List<int> current, IList<IList<int>> answer)
        {
            if (k == depth)
            {
                Console.WriteLine($"Answer {string.Join(",", current)}");
                answer.Add(new List<int>(current)); // Deep copy
                return;
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    //Generate the next solution from current
                    current.Add(nums[i]);
                    Console.WriteLine(string.Join(",", current));
                    Cnk(nums, n, k, i + 1, depth + 1, current, answer);
                    //Backtrack to the previous partial state
                    current.RemoveAt(current.Count - 1);
                    Console.WriteLine($"Backtrack {string.Join(",", current)}");
                }
            }
        }

        public static IList<IList<int>> Permute(int[] nums)
        {
            var answer = new List<IList<int>>();
            int n = nums.Length;
            Ank(nums, n, n, 0, new bool[n], new List<int>(), answer);
            return answer;
        }

        private static void Ank(int[] nums, int n, int k, int depth, bool[] used, List<int> current, IList<IList<int>> answer)
        {
            if (k == depth)
            {
                Console.WriteLine($"Answer {string.Join(",", current)}");
                answer.Add(new List<int>(current)); // Deep copy
                return;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (used[i])
                        continue;
                    //Generate the next solution from current
                    current.Add(nums[i]);
                    used[i] = true;
                    Console.WriteLine(string.Join(",", current));
                    Ank(nums, n, k, depth + 1, used, current, answer);
                    //Backtrack to the previous partial state
                    current.RemoveAt(current.Count - 1);
                    Console.WriteLine($"Backtrack {string.Join(",", current)}");
                    used[i] = false;
                }
            }
        }

    }
}
