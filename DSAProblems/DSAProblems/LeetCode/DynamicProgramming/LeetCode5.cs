using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.DynamicProgramming
{
    class LeetCode5
    {
        public string LongestPalindrome(string s) {
            if (string.IsNullOrEmpty(s))
                return s;
            int n = s.Length;
            string result = string.Empty;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int len = j - i + 1;
                    if (len > result.Length && IsPalindrome(s, i, j)){
                        result = s.Substring(i, len);
                    }
                }
            }
            return result;
        }

        public int SingleNumber(int[] nums) {
            Dictionary<int, int> hash = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++){
                if(!hash.ContainsKey(nums[i]))
                    hash.Add(nums[i], 1);
                else
                    hash[nums[i]]++;
            }
            return hash.OrderBy(kv => kv.Value).First().Key;
        }

        public string LongestPalindrome2(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            int maxLen = 0, n = s.Length;
            string result = string.Empty;
            foreach (int parity in new[] {0, 1})
            {
                int low = 1, high = n;
                if (low % 2 != parity) low++;
                if (high % 2 != parity) high--;
                while(low <= high) {
                    int mid = low + (high - low) / 2;
                    if(mid % 2 != parity) {
                        mid++;
                    }
                    if(mid > high) {
                        break;
                    }
                    int tmp = good(mid, s);
                    if(tmp != -1) {
                        if(mid > maxLen) {
                            maxLen = mid;
                            result = s.Substring(tmp, mid);
                        }
                        low = mid + 2;
                    }
                    else {
                        high = mid - 2;
                    }
                }
            }
            return result;
        }

        private int good(int x, string s) {
            int n = s.Length;
            for(int L = 0; L + x <= n; L++) {
                if(IsPalindrome2(s.Substring(L, x))) {
                    return L;
                }
            }
            return -1;
        }

        private bool IsPalindrome2(string s)
        {
            int low = 0, high = s.Length - 1;
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
    
        private bool IsPalindrome(string s, int low, int high)
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
    }
}
