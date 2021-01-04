using System.Collections;

namespace DSAProblems.Tricks
{
    /*
     An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
     For example, anagram -> nagaram, binary -> brainy, adobe -> abode

        Method 1 (Use Sorting) - O(nLogn)
        1. Sort both strings
        2. Compare the sorted strings

        Method 2 (Count characters)  - O(n)
        This method assumes that the set of possible characters in both strings is small. In the following implementation, it is assumed that the characters are stored using 8 bit and there can be 256 possible characters. 

        Create count arrays of size 256 for both strings. Initialize all values in count arrays as 0.
        Iterate through every character of both strings and increment the count of character in the corresponding count arrays.
        Compare count arrays. If both count arrays are same, then return true.

        Method 3 (count characters using one array) 
        The above implementation can be further to use only one count array instead of two. We can increment the value in count array for characters in str1 and decrement for characters in str2. Finally, if all count values are 0, then the two strings are anagram of each other.
    
        Method 4 (Taking sum) - O(n)
        The problem can be Done in Linear time and constant space. 

        We initialize a variable say count to 0.
        Then we take the sum of all the characters of the first String and then decreasing the value of all the characters from the second String.
        If the Count value finally is 0, i.e. before performing any operation then its an anagram, else it is not.
         
      */
    class Anagrams
    {
        public static bool areAnagram(ArrayList str1, ArrayList str2)
        {
            // Get lenghts of both strings
            int n1 = str1.Count;
            int n2 = str2.Count;
 
            // If length of both strings is not
            // same, then they cannot be anagram
            if (n1 != n2) {
                return false;
            }
 
            // Sort both strings
            str1.Sort();
            str2.Sort();
 
            // Compare sorted strings
            for (int i = 0; i < n1; i++) {
                if (str1[i] != str2[i]) {
                    return false;
                }
            }
 
            return true;
        }

        static bool areAnagram2(char[] str1, char[] str2)
        {
            // Create 2 count arrays and initialize
            // all values as 0
            int[] count1 = new int[256];
            int[] count2 = new int[256];
            int i;
 
            // For each character in input strings,
            // increment count in the corresponding
            // count array
            for (i = 0; i < str1.Length && i < str2.Length;
                i++) {
                count1[str1[i]]++;
                count2[str2[i]]++;
            }
 
            // If both strings are of different length.
            // Removing this condition will make the program
            // fail for strings like "aaca" and "aca"
            if (str1.Length != str2.Length)
                return false;
 
            // Compare count arrays
            for (i = 0; i < 256; i++)
                if (count1[i] != count2[i])
                    return false;
 
            return true;
        }

        static bool isAnagram3(char[] str1, char[] str2)
        {
     
            // Create a count array and initialize
            // all values as 0
            int[] count = new int[256];
            int i;
 
            // For each character in input strings,
            // increment count in the corresponding 
            // count array
            for(i = 0; i < str1.Length; i++) 
            {
                count[str1[i] - 'a']++;
                count[str2[i] - 'a']--;
            }
 
            // If both strings are of different 
            // length. Removing this condition 
            // will make the program fail for
            // strings like "aaca" and "aca"
            if (str1.Length != str2.Length)
                return false;
 
            // See if there is any non-zero 
            // value in count array
            for(i = 0; i < 256; i++)
                if (count[i] != 0) 
                {
                    return false;
                }
            return true;
        }

        static bool isAnagram4(string c, string d)
        {
            if (c.Length != d.Length)
                return false;
         
            int count = 0;
     
            // Take sum of all characters of, first String
            for(int i = 0; i < c.Length; i++)
            {
                count = count + c[i];
            }
 
            // Subtract the Value of all the, characters of second String
            for(int i = 0; i < d.Length; i++)
            {
                count = count - d[i];
            }
 
            // If Count = 0 then they are anagram, If count > 0 or count < 0 then, they are not anagram
            return (count == 0);
        }
    }
}
