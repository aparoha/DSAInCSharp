using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.OA.Amazon
{
    /*
     
        A company would like to know how much inventory exists in their closed inventory compartments.

        Given 
        1. A string s consisting of items as * and closed compartments as an open and close |, 
        2. An array of starting indices startIndices, 
        3. An array of ending indices endIndices, 
        
        Determine the number of items in closed compartments within the substring between the two indices, inclusive.

        An item is represented as an asterisk ( * = ascii decimal 42)
        A compartment is represented as a pair of pipes that may or may not have items between them ( | = ascii decimal 124).
        Example 1:
        Input: s = |**|*|*, startIndices = [1, 1], endIndices = [5, 6]
        Output: [2, 3]
        Explanation:
        The string has a total of 2 closed compartments, one with 2 items and one with 1 item.

        For the first pair of indices, (1, 5), the substring |**|*. There are 2 items in a compartment.

        For the second pair of indices, (1, 6), the substring is |**|*| and there are 2 + 1 = 3 items in compartments.

        Both of the answers are returned in an array, [2, 3]

        Example 2:
        Input: s = *|*|, startIndices = [1], endIndices = [3]
        Output: []
        Explanation:
        the substring from index = 1 to index = 3 is *|*. There is no compartments in this string.

        Constraints:
        1 <= m, n <= 10^5
        1 <= startIndices[i] <= endIndices[i] <= n
        Each character or s is either * or |

    */

    //https://github.com/neerazz/FAANG/tree/master/Algorithms/Neeraj/topAmazonQuestions
    public class ItemsInContainer
    {
        public int[] numberOfItems(string str, int[] starts, int[] ends)
        {
            if (string.IsNullOrEmpty(str)) return null;
            List<Bucket> buckets = new List<Bucket>();
            List<int> result = new List<int>();
            int startOfC = -1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '|')
                {
                    startOfC = i;
                }
                else
                {
                    int itemsCount = 0;
                    if (str[i] == '*' && startOfC >= 0)
                    {
                        int j = i;
                        while (j < str.Length && str[j] != '|')
                        {
                            itemsCount++;
                            j++;
                        } 
                        var bucket = new Bucket() {start = startOfC + 1, end = j + 1, items = itemsCount};
                        buckets.Add(bucket);
                        i = j;
                    }
                }
            }

            for (int i = 0; i < starts.Length; i++)
            {
                int items = 0;
                foreach (var b in buckets)
                {
                    if (b.start >= starts[i] && b.end <= ends[i])
                    {
                        items = items + b.items;
                    }
                }
                result.Add(items);
            }
            return result.ToArray();
        }

        class Bucket
        {
            public int start;
            public int end;
            public int items;
        }

        public int[] numberOfItems2(string str, int[] starts, int[] ends) {
            int len = str.Length;
            int[] result = new int[starts.Length], left = new int[len], right = new int[len];
            //Left array will have the index of close\open located on the left side.
            //Right array will have the index of close\open located on the right side.
            int closeIdx = int.MaxValue;
            for (int i = len - 1; i >= 0; i--) {
                if (str[i] == '|') 
                    closeIdx = i;
                right[i] = closeIdx;
            }
            closeIdx = int.MaxValue;
            for (int i = 0; i < len; i++) {
                if (str[i] == '|') 
                    closeIdx = i;
                left[i] = closeIdx;
            }
            for (int i = 0; i < starts.Length; i++) {
                int start = starts[i], end = ends[i];
                int startIdx = right[start - 1], endIdx = left[end - 1];
                result[i] = getCount(startIdx, endIdx, str);
            }
            return result;
        }

        private int getCount(int startIdx, int endIdx, String str) {
            if (startIdx == int.MaxValue || endIdx == int.MaxValue || startIdx >= endIdx) return 0;
            int count = 0;
            for (int i = startIdx + 1; i < endIdx; i++) {
                count += str[i] == '*' ? 1 : 0;
            }
            return count;
        }

    }
}
