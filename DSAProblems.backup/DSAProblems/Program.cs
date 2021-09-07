using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using DSAProblems.Algorithms.DP.ZeroOneKnapsack;
using DSAProblems.LeetCode.BFS;
using DSAProblems.OA.Amazon;

namespace DSAProblems
{


  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }

    public class SNode {
        public TreeNode current;
        public TreeNode parent;
        public char dir;
    }

    class Program
    {
        //static List<int> result =  new List<int>();
        static void Main(string[] args)
        {
            LoadBalancer ll = new LoadBalancer();
            //Console.WriteLine(ll.canThreePartsEqualSum(new int[] {2, 4, 5, 3, 3, 9, 2, 2, 2}));
            Console.WriteLine(new List<char>() {'a', 'b', 'c'}.SequenceEqual(new List<char>() {'a', 'b', 'c'}));

            //CloseStrings("abc", "bca");
            Console.ReadLine();
        }

        public static bool CloseStrings(string word1, string word2) {
            if(string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2)) return false;
            Dictionary<char, int> word1Map = new Dictionary<char, int>();
            Dictionary<char, int> word2Map = new Dictionary<char, int>();
            foreach(char c in word1){
                if(!word1Map.ContainsKey(c))
                    word1Map.Add(c, 1);
                else
                    word1Map[c]++;
            }
            foreach(char c in word2){
                if(!word2Map.ContainsKey(c))
                    word2Map.Add(c, 1);
                else
                    word2Map[c]++;
            }

            if (!word1Map.Keys.OrderBy(k1 => k1).SequenceEqual(word2Map.Keys.OrderBy(k2 => k2)))
                return false;
        
            List<int> aValues = new List<int>(word1Map.Values);
            List<int> bValues = new List<int>(word2Map.Values);
            aValues.Sort();
            bValues.Sort();
        
            return aValues.SequenceEqual(bValues);
        }

        public static bool CloseStrings2(string word1, string word2)
        {
            if(string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2)) return false;
            if (word1.Length != word2.Length) return false;

            int[] counts1 = new int[26];
            int[] counts2 = new int[26];
            ISet<char> set1 = new HashSet<char>();
            ISet<char> set2 = new HashSet<char>();

            foreach (var c in word1)
            {
                counts1[c - 'a']++;
                set1.Add(c);
            }

            foreach (var c in word2)
            {
                counts2[c - 'a']++;
                set2.Add(c);
            }

            if (!counts1.SequenceEqual(counts2)) return false;

            Array.Sort(counts1);
            Array.Sort(counts2);

            return set1.SetEquals(set2);
        }

        private static int[] getFrequency(string word)
        {
            int[] frequency = new int[26];
            foreach (char c in word)
            {
                frequency[c - 'a']++;
            }

            return frequency;
        }
        public static bool IsValid(string s) {
            if (string.IsNullOrEmpty(s)) return true;
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0) return false;
                    char top = stack.Peek();
                    if ((c != ')' || top == '(') && (c != '}' || top == '{') && (c != ']' || top == '['))
                        stack.Pop();
                    else
                        return false;
                }

            }
            return stack.Count == 0;
        }

        public IList<string> TopKFrequent(string[] words, int k) {
            Dictionary<string, int> map = new Dictionary<string, int>();
            
            foreach (string t in words)
            {
                if(!map.ContainsKey(t))
                    map.Add(t, 1);
                else
                    map[t]++;
            }
            var lex = new SortedDictionary<string, int>(map.OrderByDescending(kv => kv.Value).ToDictionary(x => x.Key, y => y.Value));
            return lex.Take(k).Select(x => x.Key).ToList();
        }

        public static int LastStoneWeight(int[] stones) {
            var len = stones.Length;
            var set = new SortedSet<Tuple<int, int>>(new WeightComparer());
            for(var i = 0; i < stones.Length; i++)
                set.Add(new Tuple<int, int>(stones[i], i));

            while(set.Count > 1)
            {
                var y = set.First();
                set.Remove(y);
                var x = set.First();
                set.Remove(x);

                if (x.Item1 != y.Item1)
                {
                    len++;
                    set.Add(new Tuple<int, int>(y.Item1 - x.Item1, len));
                }
            }

            return set.Any() ? set.First().Item1 : 0;
        }

        internal class WeightComparer : IComparer<Tuple<int, int>>
        {
            public int Compare(Tuple<int, int> x, Tuple<int, int> y)
            {
                int result = y.Item1.CompareTo(x.Item1);
                if(result == 0)
                    result = y.Item2.CompareTo(x.Item2);
                return result;
            }
        }
    
        private static bool IsOpening(char c){
            return c == '(' || c == '[' || c == '{';
        }

        public static int MaxProduct(int[] nums) {
            if (nums == null || nums.Length == 0) return 0;

            int windowStart = 0, windowEnd = 0, n = nums.Length;
            long max = int.MinValue, curr = 1;

            while (windowEnd < n)
            {
                if ((curr < 0 && windowStart < windowEnd - 1) && nums[windowEnd] == 0)
                {
                    curr /= nums[windowStart];
                    max = Math.Max(curr, max);
                    windowStart++;
                }
                else
                {
                    if (nums[windowEnd] == 0)
                    {
                        max = Math.Max(0, max);
                        windowStart = ++windowEnd;
                        curr = 1;
                    }
                    else
                    {
                        curr *= nums[windowEnd];
                        max = Math.Max(curr, max);
                        windowEnd++;
                    }
                }
            }
            for (; curr < 0 && windowStart < n - 1; windowStart++) {
                curr /= nums[windowStart];
                max = Math.Max(curr, max);
            }

            return (int)max;
        }

        public char FindTheDifference(string s, string t)
        {
            int sum = t.Aggregate(0, (current, c) => current + c);
            sum = s.Aggregate(sum, (current, c) => current - c);
            return (char)sum;
        }

        public int[] SingleNumber(int[] nums) {
            Dictionary<int, int> hash = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++){
                if(!hash.ContainsKey(nums[i]))
                    hash.Add(nums[i], 1);
                else
                    hash[nums[i]]++;
            }
            return hash.OrderBy(kv => kv.Value).Take(2).Select(kv => kv.Key).ToArray();
        }

        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return s;
            string result = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if (IsPalindrome(s, i, j))
                    {
                        int len = j - i + 1;
                        if (len > result.Length)
                        {
                            result = s.Substring(i, len);
                        }
                    }
 
                }
            }
            return result;
        }
    
        private static bool IsPalindrome(string s, int low, int high)
        {
            while(low <= high){
                if (s[low] != s[high])
                {
                    return false;
                }
                low++;
                high--;
            }
            return true;
        }

        public static IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
            List<int> to_deleteList = new List<int>(to_delete);
            List<TreeNode> result = new List<TreeNode>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            if(!to_deleteList.Contains(root.val))
                result.Add(root);
            while (queue.Any())
            {
                TreeNode node = queue.Dequeue();
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    if (to_deleteList.Contains(node.left.val))
                        node.left = null;
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    if (to_deleteList.Contains(node.right.val))
                        node.right = null;
                }
                if (to_deleteList.Contains(node.val))
                {
                    if(node.left != null)
                        result.Add(node.left);
                    if(node.right != null)
                        result.Add(node.right);
                }
            }
            return result;
        }

        public static bool IsEvenOddTree(TreeNode root)
        {
            int level = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                int size = queue.Count;
                int currentMin = int.MinValue, currentMax = int.MaxValue;
                for (int i = 0; i < size; i++)
                {
                    TreeNode current = queue.Dequeue();
                    if (!MinMax(level, current.val, ref currentMin, ref currentMax)) return false;
                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);
                }
                level++;
            }
            return true;
       }

        private static bool MinMax(int level, int current, ref int currentMin, ref int currentMax)
        {
            if (level % 2 == 0 && current % 2 != 0)
            {
                if (current <= currentMin)
                    return false;
                currentMin = current;
            }
            else if (level % 2 != 0 && current % 2 == 0)
            {
                if (current >= currentMax)
                    return false;
                currentMax = current;
            }
            else
            {
                return false;
            }
            return true;
        }

        public static int SumEvenGrandparent2(TreeNode root) {
            if (root == null) return 0;
            int total = 0;
            Queue<TreeNode[]> queue = new Queue<TreeNode[]>();
            queue.Enqueue(new TreeNode[]{ root, null, null});
            while (queue.Any()) {
                TreeNode[] current = queue.Dequeue();
                if (current[2] != null) {
                    if (current[1] != null && current[1].val % 2 == 0) {
                    
                        total += current[0].val;
                    }
                    current[1] = current[2];
                }
                current[2] = current[0];
                if (current[0].left != null) {
                
                    queue.Enqueue(new TreeNode[]{ current[0].left, current[1], current[2]});
                }
            
                if (current[0].right != null) {
                
                    queue.Enqueue(new TreeNode[]{ current[0].right, current[1], current[2]});
                }
            }
        
            return total;
        }

        private static int Print(TreeNode node)
        {
            return node?.val ?? 0;
        }
//        public static int SumEvenGrandparent(TreeNode root) {
//            if (root == null) return 0;
//            int total = 0;
//            Queue<SNode> queue = new Queue<SNode>();
//            queue.Enqueue(new SNode()
//            {
//                current = root, parent = null, gp = null
//            });
//            while (queue.Any()) {
//                SNode snode = queue.Dequeue();
//                Console.WriteLine($"current {snode.current.val} parent {Print(snode.parent)} gp {Print(snode.gp)}");
//                if (snode.gp?.val % 2 == 0) {
//                    
//                    total += snode.current.val;
//                }
//                if (snode.current.left != null) {
//                
//                    queue.Enqueue(new SNode
//                    {
//                        current = snode.current.left,
//                        parent = snode.current,
//                        gp = snode.parent
//                    });
//                }
//            
//                if (snode.current.right != null) {
//                
//                    queue.Enqueue(new SNode
//                    {
//                        current = snode.current.right,
//                        parent = snode.current,
//                        gp = snode.parent
//                    });
//                }
//            }
//        
//            return total;
//        }
   

        public static List<string> TopNumCompetitors(int numCompetitors,
            int topNCompetitors,
            List<string> competitors,
            int numReviews, List<string> reviews)
        {
            if (competitors == null || reviews == null) return null;
            competitors = competitors.ConvertAll(d => d.ToLower());// to handle case in-sensitive
            Dictionary<string, int> competitorsFreqMap = competitors.ToDictionary(k => k, v => 0);
            for (int i = 0; i < numReviews; i++)
            {
                string currentReview = reviews[i].ToLower();
                foreach (string competitor in competitors.Where(comp => currentReview.Contains(comp)))
                {
                    competitorsFreqMap[competitor]++; //increase freq count if present in review
                }
            }

            List<string> result = competitorsFreqMap.OrderByDescending(descKv => descKv.Value)
                .Take(topNCompetitors)
                .Select(kv => kv.Key)
                .ToList();

            return result;
        }

        public static int FindUnsortedSubarray(int[] nums) {
            int start = 0, end = 0;
            for(int i = 0; i < nums.Length - 1; i++){
                if(nums[i] > nums[i+1]){
                    if (start == 0 && end == 0)
                    {
                        start = i;
                        end = i;
                    }
                    else
                    {
                        end = i + 1;
                    }
                    int temp = nums[i];
                    nums[i] = nums[i + 1];
                    nums[i + 1] = temp;
                }
            }
            return start == 0 && end == 0 ? 0 : end - start + 1;
        }

        public int[] PlusOne(int[] digits) {
            int n = digits.Length;
            for(int i = n - 1; i >= 0; i--) {
                if (digits[i] >= 9)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i]++;
                    return digits;
                }
            }

            int[] newNumber = new int[n+1];
            newNumber[0] = 1;
            return newNumber;
        }

        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
            if(nums == null || nums.Length == 0) return false;
            for(int i = 0; i < nums.Length; i++){
                for(int j = i + 1; j < nums.Length; j++){
                    if(IsValid(nums[i]) && IsValid(nums[j]) && Math.Abs(nums[i] - nums[j]) <= t &&
                       Math.Abs(i - j) <= k) 
                        return true;
                }
            }
            return false;
        }
    
        private static bool IsValid(int n){
            return n > int.MinValue;
        }

        public static List<List<int>> permuteQ(int[] nums) {
            Queue<Tuple<List<int>, List<int>> > q = new Queue<Tuple<List<int>, List<int>>>();
            List<List<int>> res = new List<List<int>>();
            q.Enqueue(Tuple.Create(nums.ToList(), new List<int>()));
            while (q.Any()) {
                var current = q.Dequeue();
                if (!current.Item1.Any()) {
                    res.Add(new List<int>(current.Item2));
                }
                for (int i=0; i< current.Item1.Count; i++) {
                    List<int> newPath = new List<int>(current.Item2);
                    newPath.Add(current.Item1[i]);
                    List<int> newNums = new List<int>(current.Item1);
                    newNums.RemoveAt(i);
                    q.Enqueue(Tuple.Create(newNums, newPath));
                }
            }
            return res;
        }

        //https://zxi.mytechroad.com/blog/sliding-window/leetcode-1658-minimum-operations-to-reduce-x-to-zero/

        public static int MinOperations(int[] nums, int x) {
            if(nums == null || nums.Length == 0) return -1;
            int ans = helper(nums, x, 0, nums.Length - 1, 0);
            return ans >= int.MaxValue ? -1 : ans;
        }

        private static int helper(int[] nums, int x, int l, int r, int count)
        {
            if (x == 0) return count;
            if (x < 0 || l > r) return int.MaxValue;
            int left = helper(nums, x - nums[l], l + 1, r, count + 1);
            int right = helper(nums, x - nums[r], l, r - 1, count + 1);
            return Math.Min(left, right);
        }

        //3,2,20,1,1,3
        //1,-18,19,0,-4
        public static int minOperations(int[] nums, int x) {
            int n = nums.Length;
            int target = nums.Sum() - x;    
            int ans = int.MaxValue;
            int currentSum = 0, windowStart = 0;
            for (int windowEnd = 0; windowEnd < n; windowEnd++) {
                currentSum += nums[windowEnd];
                while (currentSum > target && windowStart <= windowEnd)
                {
                    currentSum -= nums[windowStart];
                    windowStart++;
                }
                if (currentSum == target)
                    ans = Math.Min(ans, n - (windowEnd - windowStart + 1));
            }
            return ans > n ? -1 : ans;
        }

        public static int minOperations2(int[] nums, int x) {
            int n = nums.Length;
            int target = nums.Sum() - x;    
            int minSubarraySize = int.MaxValue;
            int currWindowSum = 0;
            int windowStart = 0;
            for(int windowEnd = 0; windowEnd < nums.Length; windowEnd++) {
                currWindowSum += nums[windowEnd];
                while(currWindowSum > target && windowStart <= windowEnd) {
                    currWindowSum -= nums[windowStart];
                    windowStart++;
                }
                if (currWindowSum == target)
                    minSubarraySize = Math.Min(minSubarraySize, n - (windowEnd - windowStart + 1));
            }
            return minSubarraySize;
        }
    }




}
