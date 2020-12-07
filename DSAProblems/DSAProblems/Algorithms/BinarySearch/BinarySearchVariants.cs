using System;

namespace DSAProblems.Algorithms.BinarySearch
{
    
    //https://medium.com/better-programming/three-smart-ways-to-use-binary-search-in-coding-interviews-250ba296cb82
    //https://www.junhaow.com/lc/notes/binary-search-template-notes.html
    class BinarySearchVariants
    {
        //https://rosettacode.org/wiki/Binary_search
        //inclusive (high = N -1) vs exclusive upper bound (high = N)
        //How to convert inclusive upper bound to exclusive upper bound?
        //1.change high = N-1 to high = N
        //2.change high = mid-1 to high = mid
        //3.(for recursive algorithm) change if (high < low) to if (high <= low)
        //4.(for iterative algorithm) change while (low <= high) to while (low < high)
//        static void Main(string[] args)
//        {
//            int[] arr = { 1,   2,   3,   4,   7,   8,   10,  11,  13,  14,  15  }; 
//            int x = 10;
//
//            int[,] twoDArr = new int[3,3] {
//                                            {1,3,12},
//                                            {2,4,20},
//                                            {5,10,20}
//                                            };
//            var mbs = new MatrixBinarySearch();
//
//
//            //Console.WriteLine(mbs.BinarySearch(twoDArr, 4));
//
//            //Stricly sorted array,  first element of a row is greater than the last element of the previous row
//            int[,] twoDArrOne =
//            {
//                {4, 3, 2, -1},
//                {3, 2, 1, -1},
//                {1, 1, -1, -2},
//                {-1, -1, -2, -3}
//            };
//
//            var jagged = new[]
//            {
//                new[] {4, 3, 2, -1},
//                new[] {3, 2, 1, -1},
//                new[] {1, 1, -1, -2},
//                new[] {-1, -1, -2, -3}
//            };
//
////            jagged = new[]
////            {
////                new[] {3, 2},
////                new[] {1, 0}
////            };
//
//            
//            //Console.WriteLine(mbs.floorSqrt(2147395599));
//
//            Console.ReadLine();
//        }

        //Template #1
        //Used to search for an element or condition which can be determined by accessing a single index in the array
        //Search Condition can be determined without comparing to the element's neighbors (or use specific elements around it)
        //No post-processing required because at each step, you are checking to see if the element has been found. If you reach the end, then you know the element is not found
        //Initial Condition: left = 0, right = length-1
        //Termination: left > right
        //Searching Left: right = mid-1
        //Searching Right: left = mid+1
        public static int StandardBsIterative(int[] arr, int target)
        {
            if(arr == null || arr.Length == 0)
                return -1;
            
            int left = 0, right = arr.Length - 1;
            while (left <= right)
            {
                // same as (low + high) / 2, but prevents int overflows
                int mid = left + (right - left) / 2; 
  
                // Check if target is present at mid 
                if (arr[mid] == target)
                    return mid;
  
                // If target greater, ignore left half 
                if (arr[mid] < target) 
                    left = mid + 1; 
  
                // If target is smaller, ignore right half 
                else
                    right = mid - 1; 
            }
            // End Condition: left > right
            return -1;
        }

        //Template 2
        //It is used to search for an element or condition which requires accessing the current index and its immediate right neighbor's index in the array
        //Search Condition needs to access element's immediate right neighbor
        //Use element's right neighbor to determine if condition is met and decide whether to go left or right
        //Gurantees Search Space is at least 2 in size at each step
        //Post-processing required. Loop/Recursion ends when you have 1 element left. Need to assess if the remaining element meets the condition.
        //Initial Condition: left = 0, right = length
        //Termination: left == right
        //Searching Left: right = mid
        //Searching Right: left = mid+1    
        public static int StandardBsIterativeTemplate2(int[] arr, int target)
        {
            if(arr == null || arr.Length == 0)
                return -1;

            int left = 0, right = arr.Length;
            while(left < right){

                int mid = left + (right - left) / 2;

                if(arr[mid] == target)
                    return mid;
                if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid;
            }

            // Post-processing:
            // End Condition: left == right
            if(left != arr.Length && arr[left] == target) 
                return left;
            
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


        //1.Binary search stops immediately when arr[mid] is the value we’re looking for 
        //2.In FirstOccurence (or left most), we want to modify actual logic
        //3.When we find an occurrence, do not immediately return the index of mid, 
          //but instead begin searching for earlier occurrences that may appear in the range [low, mid] (inclusive)
        //4.If we’re interested in the range [low, mid] (inclusive) after we find one occurrence, 
          //we can just set right = mid to continue searching. Setting high = mid (instead of high = mid - 1) 
          //includes the occurrence we just found when searching our “lower half”, so in the following possible cases:
        // a. All values in the range [low, mid - 1] happen to be less than arr[mid], we don’t lose the occurrence we found
        // b. There is an earlier occurrence in the range [left, mid - 1], we’ll find it with the rest of our logic
        
        //When to stop searching?
        //when mid == low (after we’ve found an occurrence)
        //there is no earlier range to search through because our “lower half” is gone. 
        //So at this point, arr[mid] must be the earliest occurrence, and we’ll return it

        //Example
        //[1, 2, 3, 4, 4, 5, 6, 7] target = 4
        //low   high    mid     arr[mid]
        //0      7       3         4
        //0      3       1         2
        //2      3       2         3
        //3      3       3         4
        public static int FirstOccurenceBs(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                // same as (low + high) / 2, but prevents int overflows
                int mid = low + (high - low) / 2; 
  
                if (target > arr[mid]) {
                    low = mid + 1;
                } else if (target < arr[mid]) {
                    high = mid - 1;
                } else if (low != mid) {
                    high = mid;
                } else {
                    return mid;
                }
            }
            return -1;
        }

        public static int LastOccurenceBs(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (target > arr[mid]) {
                    low = mid + 1;
                } else if (target < arr[mid]) {
                    high = mid - 1;
                } else if (low != mid) { 
                    low = mid;
                } else {
                    return arr[high] == target ? high : low;
                }
            }
            return -1;
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

        public static int NearestNeighborBs(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1;

            while (low <= high) {
                int mid = low + (high - low) / 2;
                if (arr[mid] > target) {
                    high = mid - 1;
                } else if (arr[mid] < target) {
                    low = mid + 1;
                } else if (arr[mid] == target) {
                    return mid;
                }
            }

            if (low >= arr.Length) { // low is out of bounds
                return high;
            }
            if (high < 0) { // high is out of bounds
                return low;
            }
            if (arr[low] - target < Math.Abs(arr[high] - target)) 
            { 
                return low;
            }
            return high;
        }

        public static int NextLargest(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1;

            while (low <= high) {
                int mid = low + (high - low) / 2;
                if (arr[mid] > target) {
                    high = mid - 1;
                } else if (arr[mid] < target) {
                    low = mid + 1;
                } else if (arr[mid] == target) {
                    return mid;
                }
            }

            return (low >= arr.Length) ? -1 : low;
        }
    }
}
