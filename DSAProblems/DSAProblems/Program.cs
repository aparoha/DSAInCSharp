using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DSAProblems.Algorithms.BinarySearch;
using DSAProblems.Algorithms.Graphs;
using DSAProblems.Algorithms.Recursions;
using DSAProblems.Algorithms.Sorting;
using DSAProblems.DataStructures;
using DSAProblems.DataStructures.Heaps;
using DSAProblems.DataStructures.LinkedList;
using DSAProblems.DataStructures.PriorityQueue;
using DSAProblems.DynamicProgramming;
using DSAProblems.LeetCode.BFS;
using DSAProblems.LLD.ProducerConsumer;

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
            Console.WriteLine(FindRedundantConnection(new int[][]
            {
                new int[] {1, 2},
                new int[] {1, 3},
                new int[] {2, 3}
            }));
            Console.WriteLine("Hello, world!");
            Console.WriteLine(LongestSubstring("aaabb", 3));

            // This using block defines the lifetime of the queue and therefore the lifetime of all producers and consumers
            using (SynchronizedQueue<string> sq = new SynchronizedQueue<string>(true))
            {
                // Now we're creating several producers and consumers
                AbstractQueueProducer<string> producer1 = new DummyProducer(sq);
                AbstractQueueProducer<string> producer2 = new DummyProducer(sq);
                AbstractQueueProducer<string> producer3 = new DummyProducer(sq);
                AbstractQueueProducer<string> producer4 = new DummyProducer(sq);
                AbstractQueueConsumer<string> consumer1 = new DummyConsumer(sq);
                AbstractQueueConsumer<string> consumer2 = new DummyConsumer(sq);
                AbstractQueueConsumer<string> consumer3 = new DummyConsumer(sq);
                AbstractQueueConsumer<string> consumer4 = new DummyConsumer(sq);
                AbstractQueueConsumer<string> consumer5 = new DummyConsumer(sq);

                // All consumers/producers have been created. Now let's have the main thread rest for a while.
                Thread.Sleep(5000);

                // Alright, enough sleeping for the main thread! Let's get out of this using block and therefore kill all consumers/workers and the queue itself!
            }

            Console.WriteLine("Goodbye, world! (press enter)");
            Console.Read();
            var rp1 = new RecursionProblems();
            Console.WriteLine(string.Join(",", rp1.GetPermutations("AABC")));
            Console.WriteLine(string.Join(",", rp1.Permute("AABC")));
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

        public static int[] FindRedundantConnection(int[][] edges)
        {
            int n = edges.Length;
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            bool[] visited = new bool[n];
            for (int i = 1; i <= n; i++)
                graph.Add(i, new List<int>());
            foreach (int[] edge in edges)
            {
                if (HasPath(edge[0], edge[1], visited, graph))
                    return edge;
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            return null;
        }

        private static bool HasPath(int source, int target, bool[] visited, Dictionary<int, List<int>> graph)
        {
            if (source == target)
                return true;
            visited[source] = true;
            foreach (var node in graph[source])
            {
                if (!visited[node])
                    if (HasPath(node, target, visited, graph))
                        return true;
            }
            return false;
        }

        public static int LongestSubstring(string s, int k)
        {
            if (string.IsNullOrEmpty(s))
                return 0;
            HashSet<char> uniqueChars = new HashSet<char>(s);
            int result = 0;
            for (int i = 1; i <= uniqueChars.Count; i++)
            {
                //Do sliding window for each character
                Dictionary<char, int> freqMap = new Dictionary<char, int>();
                int currUnique = 0, countAtLeastK = 0;
                for (int left = 0, right = 0; right < s.Length; right++)
                {
                    if (!freqMap.ContainsKey(s[right]))
                        freqMap.Add(s[right], 1);
                    else
                        freqMap[s[right]] += 1;
                    if (freqMap[s[right]] == k)
                        countAtLeastK++;
                    if (freqMap[s[right]] == 1)
                        currUnique++;
                    while (freqMap.Count > i && left < right)
                    {
                        char leftChar = s[left];
                        if (freqMap.ContainsKey(leftChar))
                        {
                            if (freqMap[leftChar] == k)
                                countAtLeastK--;
                            freqMap[leftChar] -= 1;
                        }
                        else
                            currUnique--;
                        left++;
                    }
                    if (currUnique == countAtLeastK) //item is at least k repeat
                        result = Math.Max(result, right - left + 1);
                }
            }
            return result;
        }

        private static bool AllItemsAtLeastKRepeat(Dictionary<char, int> dict, int k)
        {
            foreach (var item in dict)
            {
                if (item.Value < k)
                {
                    return false;
                }
            }
            return true;
        }
        public int LongestSubstringWithKDistinctCharacters(string s, int k)
        {
            if(string.IsNullOrEmpty(s))
                return 0;
            int maxLength = int.MinValue;
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            for(int left = 0, right = 0; right < s.Length; right++)
            {
                if(!freqMap.ContainsKey(s[right]))
                    freqMap.Add(s[right], 1);
                else
                    freqMap[s[right]] += 1;
                while(freqMap.Count > k)
                {
                    char leftChar = s[left];
                    freqMap[leftChar] -= 1;
                    if(freqMap[leftChar] == 0)
                        freqMap.Remove(leftChar);
                    left++;
                }
                maxLength = Math.Max(maxLength, right - left + 1);
            }
            return maxLength;
        }
        public static int MaxSumSubarrayOfSizeK(int[] nums, int k)
        {
            if(nums.Length == 0)
                return 0;
            int maxSum = int.MinValue;
            int runningSum = 0;
            for(int left = 0, right = 0; right < nums.Length; right++)
            {
                runningSum += nums[right];
                if(right - left + 1 == k)
                {
                    maxSum = Math.Max(runningSum, maxSum);
                    runningSum -= nums[left];
                    left++;
                }
            }
            return maxSum;
        }

        public static int SmallestSubarrayWithGivenSum(int[] nums, int targetSum)
        {
            if (nums.Length == 0)
                return 0;
            int minWindowSize = int.MaxValue;
            int currentWindowSum = 0;
            for(int left = 0, right = 0; right < nums.Length; right++)
            {
                currentWindowSum += nums[right];
                while(currentWindowSum >= targetSum)
                {
                    minWindowSize = Math.Min(minWindowSize, right - left + 1);
                    currentWindowSum -= nums[left];
                    left++;
                }
            }
            return minWindowSize;
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
