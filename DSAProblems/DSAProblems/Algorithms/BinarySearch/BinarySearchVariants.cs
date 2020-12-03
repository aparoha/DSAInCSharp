using System;

namespace DSAProblems.Algorithms.BinarySearch
{
    class BinarySearchVariants
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 4, 5, 6, 7 }; 
            int x = 10;

            Console.WriteLine(LastOccurence(arr, 4));

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

        //Duplicate elements
        //The return value of binary search is quite binary - either it gives index of the value searched for or -1
        //It would be nice to handle duplicates in a way that is more useful. Perhaps getting information like the index of:
        //1.The first occurrence of a value
        //2.The last occurrence of a value or in the case where the value we’re searching for doesn’t exist, the index of the:
        //3.Closest value
        //4.Next largest value
        //5.Next smallest value

        //Approximate Matches
        //Binary search can be used to compute, for a given value
        //1.Its rank (the number of smaller elements)
        //2.Predecessor (next-smallest element),
        //3.Successor (next-largest element)
        //4.Nearest neighbor
        //Example - Target = 5 (5 is not present in array)

        //                  | (Predecessor or nearest neighbor)
        //      1   2   3   4   7   8   10  11  13  14  15        
        //      [  Rank = 4 ]   | (Successor)


        public static int FirstOccurence(int[] arr, int target)
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

        public static int LastOccurence(int[] arr, int target)
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
    }
}
