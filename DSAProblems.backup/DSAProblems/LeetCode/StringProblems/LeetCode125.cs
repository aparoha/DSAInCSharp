namespace DSAProblems.LeetCode.StringProblems
{
    /*
     125. Valid Palindrome
     Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

    Note: For the purpose of this problem, we define empty string as valid palindrome.

    Example 1:

    Input: "A man, a plan, a canal: Panama"
    Output: true
    Example 2:

    Input: "race a car"
    Output: false
     */
    class LeetCode125
    {
        public bool IsPalindrome(string s) {
            int low = 0;
            int high = s.Length-1;
            s = s.ToLower();
            while (low <= high){
                if (!char.IsLetterOrDigit(s[low]))
                {
                    low++; 
                    continue; 
                }
                if (!char.IsLetterOrDigit(s[high]))
                {
                    high--; 
                    continue;
                }
                if(s[low] != s[high]) return false;
                low++;
                high--;
            }
        
            return true;
        }
    }
}
