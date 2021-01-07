using System;
using System.Collections.Generic;

namespace DSAProblems.LeetCode.DynamicProgramming
{
    /*
     Given a string s and a string t, check if s is subsequence of t.

    A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ace" is a subsequence of "abcde" while "aec" is not).

    Follow up:
    If there are lots of incoming S, say S1, S2, ... , Sk where k >= 1B, and you want to check one by one to see if T has its subsequence. In this scenario, how would you change your code?

    Credits:
    Special thanks to @pbrother for adding this problem and creating all test cases.

    Example 1:

    Input: s = "abc", t = "ahbgdc"
    Output: true
    Example 2:

    Input: s = "axc", t = "ahbgdc"
    Output: false
 
    Constraints:

    0 <= s.length <= 100
    0 <= t.length <= 10^4
    Both strings consists only of lowercase characters. 
    */
    class LeetCode392
    {
        //Recursive
        public bool IsSubsequenceR(string s, string t) {
            return helper(s, t, s.Length, t.Length);
        }
    
        public bool helper(string s, string t, int n, int m) {
            if(n == 0) return true;
            if(m == 0) return false;
            if(s[n - 1] == t[m -1])
                return helper(s, t, n - 1, m - 1);
            return helper(s, t, n, m - 1);
        }

        //Two Pointers
        public bool IsSubsequence(string s, string t) {
            int si = 0, ti = 0;
            while (si < s.Length && ti < t.Length)
            {
                if (s[si] == t[ti])
                    si++;
                ti++;
            }
			
            return si == s.Length;
        }

        public bool isSubsequenceBinarySearch(string s, string t) {
            if (s == null || t == null) return false;
    
            Dictionary<Char, List<int>> map = new Dictionary<Char, List<int>>(); //<character, index>
    
            //preprocess t and store indexes of all characters
            for (int i = 0; i < t.Length; i++) {
                if (!map.ContainsKey(t[i])) {
                    map.Add(t[i], new List<int>());
                }
                map[t[i]].Add(i);
            }
    
            int prev = -1;  //index of previous character
            for (int i = 0; i < s.Length; i++) {
                if (map[s[i]] == null)  {
                    return false;
                }
                List<int> list = map[s[i]];
                prev = binarySearch(prev, list, 0, list.Count - 1);
                if (prev == -1) {
                    return false;
                }
                prev++;
            }
    
            return true;
        }

        private int binarySearch(int index, List<int> list, int start, int end) {
            while (start <= end) {
                int mid = start + (end - start) / 2;
                if (list[mid] < index) {
                    start = mid + 1;
                } else {
                    end = mid - 1;
                }
            }
    
            return start == list.Count ? -1 : list[start];
        }
    }
}
