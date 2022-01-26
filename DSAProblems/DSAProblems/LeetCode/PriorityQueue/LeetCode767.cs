using DSAProblems.DataStructures.Heaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.PriorityQueue
{
    public class LeetCode767
    {
        /* 
 * 1. Approach 1
 *      a. Create a frequency dictionary map for each character in string
 *      b. Input string - aaabbcc
 *              a -> 3
 *              b -> 2
 *              c -> 2
 *      c. Sort dictionary by frequency of character such that the most frequent should be the first element
 *      d. Iterate dictionary and use alternate character to build result, decrease frequency by 1 if we use it in our result
 *              a -> 2
 *              b -> 1
 *              c -> 1
 *          current result : abc
 *      e. After 2nd pass
 *              a -> 1
 *              b -> 0
 *              c -> 0
 *          current result : abcabc
 *      f. After 3rd pass
 *              a -> 0
 *              b -> 0
 *              c -> 0
 *           final result : abcabca
 *      g. This approach will not work, example - aaabc
 * 2. Approach 2
 *    a. Take the most frequent character
 *    b. Then take second most frequent character
 *    c. Keep repeating step a and b
 * 
 * 
 * 
*/
        public string ReorganizeString(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            Dictionary<char, int> frequencyMap = new Dictionary<char, int>();
            foreach (char ch in s)
            {
                if (!frequencyMap.ContainsKey(ch))
                    frequencyMap.Add(ch, 1);
                else
                    frequencyMap[ch] += 1;
            }
            PriorityQueue<char, int> maxHeap = new PriorityQueue<char, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            maxHeap.EnqueueRange(frequencyMap.Select(kv => (kv.Key, kv.Value)));
            (char prevChar, int prevCharPriority) previous = ('\0', 0);
            StringBuilder result = new StringBuilder();
            while (maxHeap.Count > 0)
            {
                if (maxHeap.TryDequeue(out char currentChar, out int currentCharPriority))
                {
                    result.Append(currentChar);
                    if (previous.prevChar != '\0' && previous.prevCharPriority > 0)
                        maxHeap.Enqueue(previous.prevChar, previous.prevCharPriority);
                    previous = (currentChar, currentCharPriority - 1);
                }
            }
            return result.ToString().Length == s.Length ? result.ToString() : string.Empty;
        }

        public string ReorganizeString2(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            Dictionary<char, int> frequencyMap = new Dictionary<char, int>();
            foreach (char ch in s)
            {
                if (!frequencyMap.ContainsKey(ch))
                    frequencyMap.Add(ch, 1);
                else
                    frequencyMap[ch] += 1;
            }

            BinaryHeap<Pair> maxHeap = new BinaryHeap<Pair>(frequencyMap.Select(kv => new Pair(kv.Key, kv.Value)).ToArray());
            Pair previous = new Pair();
            StringBuilder result = new StringBuilder();
            while (maxHeap.Count > 0)
            {
                var current = maxHeap.ExtractMax();
                result.Append(current.Value);
                if (previous.Value != '\0' && previous.Priority > 0)
                    maxHeap.Insert(new Pair(previous.Value, previous.Priority));
                previous = new Pair(current.Value, current.Priority - 1);
            }
            return result.ToString().Length == s.Length ? result.ToString() : string.Empty;
        }
    }

    public class Pair : IComparable<Pair>
    {
        private char _value;
        private int _priority;
        public char Value { get { return _value; } }
        public int Priority { get { return _priority; } }

        public Pair()
        {
            this._value = '\0';
            this._priority = 0;
        }
        public Pair(char value, int priority)
        {
            this._value = value;
            this._priority = priority;
        }

        public int CompareTo(Pair other)
        {
            return this._priority.CompareTo(other._priority);
        }
    }
}


