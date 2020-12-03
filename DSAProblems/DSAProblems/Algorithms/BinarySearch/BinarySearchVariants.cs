using System;

namespace DSAProblems.Algorithms.BinarySearch
{
    class BinarySearchVariants
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 4, 10, 40 }; 
            int x = 10;

            Console.WriteLine(StandardBsRecursive(arr, 0, 9, 10));

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
    }
}
