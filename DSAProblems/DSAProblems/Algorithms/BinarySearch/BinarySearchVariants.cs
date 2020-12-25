using System;

namespace DSAProblems.Algorithms.BinarySearch
{
    
    //https://medium.com/better-programming/three-smart-ways-to-use-binary-search-in-coding-interviews-250ba296cb82
    //https://www.junhaow.com/lc/notes/binary-search-template-notes.html
    //https://www.programmersought.com/article/60462110795/
    //https://www.junhaow.com/lc/notes/binary-search-template-notes.html
    //https://labuladong.gitbook.io/algo-en/iii.-algorithmic-thinking/detailedbinarysearch#thirdly-we-implement-binary-search-to-find-right-border
    //https://leetcode.com/discuss/general-discussion/786126/Python-Powerful-Ultimate-Binary-Search-Template.-Solved-many-problems
    class BinarySearchVariants
    {
        //https://rosettacode.org/wiki/Binary_search
        //inclusive (high = N -1) vs exclusive upper bound (high = N)
        //How to convert inclusive upper bound to exclusive upper bound?
        //1.change high = N-1 to high = N
        //2.change high = mid-1 to high = mid
        //3.(for recursive algorithm) change if (high < low) to if (high <= low)
        //4.(for iterative algorithm) change while (low <= high) to while (low < high)

        public int BsHighInclusive(int[] arr, int target)
        {
            if(arr == null || arr.Length == 0)
                return -1;
            
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2; 
                if (target == arr[mid])
                    return mid;
                if (target > arr[mid]) 
                    left = mid + 1; 
                else
                    right = mid - 1; 
            }
            // End Condition: left > right
            return -1;
        }

        public int BsHighExclusive(int[] arr, int target)
        {
            if(arr == null || arr.Length == 0)
                return -1;
            
            int left = 0, right = arr.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2; 
                if (target == arr[mid])
                    return mid;
                if (target > arr[mid]) 
                    left = mid + 1; 
                else
                    right = mid; 
            }
            // End Condition: left > right
            return -1;
        }

        public static int StandardBsRecursive(int[] arr, int low, int high, int target)
        {
            if (low <= high) { 
                int mid = low + (high - low) / 2; 
  
                // If the element is present at the middle itself 
                if (target == arr[mid]) 
                    return mid; 
  
                // If target greater, ignore left half 
                if (target > arr[mid]) 
                    return StandardBsRecursive(arr, mid + 1, high, target);
  
                // If target is smaller, ignore right half 
                return StandardBsRecursive(arr, low, mid - 1, target);  
            } 
  
            // We reach here when element is not present in array 
            return -1; 
        }

        //How to handle duplicates
        //1.The first occurrence of a value
        //2.The last occurrence of a value 

        //Example
        //[1, 2, 3, 4, 4, 5, 6, 7] target = 4
        //low   high    mid     arr[mid]
        //0      7       3         4
        //0      3       1         2
        //2      3       2         3
        //3      3       3         4
        public int FindFirstOccurence(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1, result = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (target == arr[mid])
                {
                    result = mid;
                    high = mid - 1;//Moving high before mid to find first occurence
                } 
                else if (target > arr[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return result;
        }

        public int FindFirstOccurence2(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (target > arr[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return low;
        }

        public int FindLastOccurence(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1, result = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (target == arr[mid])
                {
                    result = mid;
                    low = mid + 1; //Moving low after mid to find last occurence
                } 
                else if (target > arr[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return result;
        }

        public int FindLastOccurence2(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (target >= arr[mid]) //include mid
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return high;
        }

        //Finding the least possible element greater than the key
        //[4, 5, 6, 6, 6, 7, 8, 9] and the searching key is 6. 
        //The least element greater than the key is 7. 
        //What is 7? It's the next immediate element of the last occurrence of the searching key.
        //Now there can be edge cases
        //1.last occurrence can be the last element which means for the searching key no greater key exists. 
        //2.If the last occurrence is not the last element then the least greater element will be the next immediate right element of the last occurrence. 
        public int LeastPossibleGreaterThanTarget(int[] arr, int target)
        {
            int index = FindLastOccurence(arr, target);
            if (index != -1 && index != arr.Length - 1) return arr[index + 1];
            return -1;
        }

        //Finding the greatest possible element less than the key
        //[4, 5, 6, 6, 6, 7, 8, 9] and the searching key is 6. 
        //The the greatest element less than the key is 5. 
        //What is 5? It's the immediate previous element of the first occurrence of the searching key.
        //Now there can be edge cases
        //1.first occurrence can be the first element(0th element) which means for the searching key no lesser key exists. 
        //2.If the first occurrence of the search key is not the first element then the greatest less element will be an immediate previous(left) element of the first occurrence of the search key.  
        public int GreatestPossibleLessThanTarget(int[] arr, int target)
        {
            int index = FindFirstOccurence(arr, target);
            if (index != -1 && index != 0) return arr[index - 1];
            return index;
        }

        //Approximate Matches
        //The above procedure only performs exact matches, finding the position of a target value
        //1.Its rank (the number of smaller elements)
        //2.Predecessor (next-smallest element),
        //3.Successor (next-largest element)
        //4.Nearest neighbor
        //Example - Target = 5 (5 is not present in array)

        //                  | (Predecessor or nearest neighbor)
        //      1   2   3   4   7   8   10  11  13  14  15        
        //      [  Rank = 4 ]   | (Successor)

        public int NearestNeighborBs(int[] arr, int target)//Predecessor or Next Smallest
        {
            int low = 0, high = arr.Length - 1;

            while (low <= high) {
                int mid = low + (high - low) / 2;
                if (target == arr[mid])
                    return arr[mid];
                if (target > arr[mid])
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            if (low >= arr.Length) { // low is out of bounds
                return high;
            }
            if (high < 0) { // high is out of bounds
                return low;
            }
            return arr[low] - target < Math.Abs(arr[high] - target) ? low : high;
        }
        public int BinarySearchOrNextLargest(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (target == arr[mid]) return mid;
                if (target > arr[mid]) low = mid + 1;
                else high = mid - 1;
            }

            return low >= arr.Length ? -1 : low;
        }
    }
}
