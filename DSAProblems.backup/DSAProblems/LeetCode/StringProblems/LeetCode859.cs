using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.LeetCode.StringProblems
{
    /*
     Given two strings A and B of lowercase letters, return true if you can swap two letters in A so the result is equal to B, otherwise, return false.

     Swapping letters is defined as taking two indices i and j (0-indexed) such that i != j and swapping the characters at A[i] and A[j]. For example, swapping at indices 0 and 2 in "abcd" results in "cbad".

    Example 1:

    Input: A = "ab", B = "ba"
    Output: true
    Explanation: You can swap A[0] = 'a' and A[1] = 'b' to get "ba", which is equal to B.
    Example 2:

    Input: A = "ab", B = "ab"
    Output: false
    Explanation: The only letters you can swap are A[0] = 'a' and A[1] = 'b', which results in "ba" != B.
    Example 3:

    Input: A = "aa", B = "aa"
    Output: true
    Explanation: You can swap A[0] = 'a' and A[1] = 'a' to get "aa", which is equal to B.
    Example 4:

    Input: A = "aaaaaaabc", B = "aaaaaaacb"
    Output: true
    Example 5:

    Input: A = "", B = "aa"
    Output: false
 

    Constraints:

    0 <= A.length <= 20000
    0 <= B.length <= 20000
    A and B consist of lowercase letters.
    */
    class LeetCode859
    {
        public bool BuddyStrings(string A, string B) {
            if(string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B) || A.Length != B.Length)
                return false;
            if(SortString(A) != SortString(B))//when A and B has any element that are not common, then
                return false;
            if(A == B && new HashSet<Char>(A.ToCharArray()).Count == A.Length) //when A is same as B and all characters are distinct in A
                return false;
            int count = 0;
            for(int i = 0; i < A.Length; i++){
                if(A[i] != B[i]) count++;
                if(count == 3) return false;
            }
            return true;
        }
    
        private string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
