using System;

namespace DSAProblems.Algorithms.BinarySearch
{
    
    //https://medium.com/better-programming/three-smart-ways-to-use-binary-search-in-coding-interviews-250ba296cb82
    class BinarySearchVariants
    {
        static void Main(string[] args)
        {
            int[] arr = { 1,   2,   3,   4,   7,   8,   10,  11,  13,  14,  15  }; 
            int x = 10;

            int[,] twoDArr = new int[3,3] {
                                            {1,3,12},
                                            {2,4,20},
                                            {5,10,20}
                                            };
            var mbs = new MatrixBinarySearch();


            //Console.WriteLine(mbs.BinarySearch(twoDArr, 4));

            //Stricly sorted array,  first element of a row is greater than the last element of the previous row
            int[,] twoDArrOne =
            {
                {1, 5, 9, 11},
                {14, 20, 21, 26},
                {30, 34, 43, 50}
            };

            
            Console.WriteLine(mbs.EfficientLinearTimeSearchOnGrid(twoDArrOne, 34));

            Console.ReadLine();
        }
        public static int StandardBsIterative(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                // same as (low + high) / 2, but prevents int overflows
                int mid = low + (high - low) / 2; 
  
                // Check if target is present at mid 
                if (target == arr[mid])
                    return mid;
  
                // If target greater, ignore left half 
                if (target > arr[mid]) 
                    low = mid + 1; 
  
                // If target is smaller, ignore right half 
                else
                    high = mid - 1; 
            }
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
