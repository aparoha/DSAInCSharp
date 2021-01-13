namespace DSAProblems.LeetCode.StringProblems
{
    /*
     680. Valid Palindrome II
     Given a non-empty string s, you may delete at most one character. Judge whether you can make it a palindrome.

    Example 1:
    Input: "aba"
    Output: True

    Example 2:
    Input: "abca"
    Output: True
    Explanation: You could delete the character 'c'.
     */
    class LeetCode680
    {
        public bool ValidPalindrome(string s) {
            if(string.IsNullOrEmpty(s)) return false;
            int low = 0, high = s.Length - 1;
            while(low <= high){
                if (s[low] != s[high])
                    return IsPalindrome(s, low, high - 1) || IsPalindrome(s, low + 1, high);
                low++;
                high--;
            }
            return true;
        }
    
        private bool IsPalindrome(string s, int low, int high){
            while(low <= high)
            {
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
