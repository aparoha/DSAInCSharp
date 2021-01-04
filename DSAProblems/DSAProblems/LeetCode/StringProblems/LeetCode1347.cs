using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.StringProblems
{
    class LeetCode1347
    {
        //Frequency count using 2 dictionaries
        public int MinSteps(string s, string t) {
            if(string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return 0;
            if(s.Length != t.Length) return 0;
        
            Dictionary<Char, int> sMap = new Dictionary<Char, int>();
            Dictionary<Char, int> tMap = new Dictionary<Char, int>();
            fillMap(s, sMap);
            fillMap(t, tMap);
        
            int minSteps = 0;
        
            foreach(var kv in sMap)
            {
                //If character is not present in t then we need frequency of character from s
                if (!tMap.ContainsKey(kv.Key))
                {
                    minSteps += sMap[kv.Key];
                }
                else
                {
                    //If it is present in t then check the differenc eof frequency
                    //e.g. leetcode has 3 'e' (in s) and practice has 1 'e' (in t), so we need 2 more 'e' in t => 3 - 1 = 2
                    int diff = kv.Value - tMap[kv.Key];
                    if (diff > 0)
                        minSteps += diff;
                }
            }
            return minSteps;
        }

        private void fillMap(string str, Dictionary<Char, int> strMap){
            foreach(Char c in str){
                if(!strMap.ContainsKey(c))
                    strMap.Add(c, 1);
                else
                    strMap[c] += 1;
            }
        }

        //Frequency count using ASCII
        public int MinSteps2(string s, string t) {
        
            int[] steps = new int[26];
        
            for(int i = 0; i< s.Length; i++)
            {
                steps[s[i] - 'a']++;
                steps[t[i] - 'a']--;
            }
        
            int res = 0;
            for(int i = 0; i < 26; i++)
            {
                if(steps[i] > 0)
                    res += steps[i];
            }
        
            return res;
        }

        //Single Map
        public int MinSteps3(string s, string t) {
            Dictionary<Char, int> map = new Dictionary<Char, int>();
            for(int i = 0; i < s.Length; i++){
                map[s[i]] = GetOrDefault(s[i], map) + 1;
                map[t[i]] = GetOrDefault(t[i], map) - 1;
            }
            return map.Values.Where(val => val > 0).Sum();
        }

        private int GetOrDefault(Char c, Dictionary<Char, int> map)
        {
            return map.TryGetValue(c, out int result) ? result : 0;
        }
    }
}
