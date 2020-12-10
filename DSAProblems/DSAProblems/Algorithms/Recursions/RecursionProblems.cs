using System;
using System.Collections.Generic;

namespace DSAProblems.Algorithms.Recursions
{
    class RecursionProblems
    {
        //Get power set of string
        public IList<String> GetPowerSet(string s)
        {
            var result = new List<string>();
            PowerSetHelper(s, 0, "", result);
            return result;
        }

        private void PowerSetHelper(String str, int index, String curr, List<string> result)  
        {  
            int n = str.Length;  
  
            // base case  
            if (index == n) 
            { 
                result.Add(curr);
                return;
            }  
  
            // Two cases for every character  
            // (i) We consider the character  
            // as part of current subset  
            // (ii) We do not consider current  
            // character as part of current  
            // subset  
            PowerSetHelper(str, index + 1, curr + str[index], result);  
            PowerSetHelper(str, index + 1, curr, result); 
        } 
    }
}
