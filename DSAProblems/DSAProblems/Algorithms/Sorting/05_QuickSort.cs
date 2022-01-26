using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Sorting
{
    /*
     * Time Complexity
     * Best or Average case - O(nlogn)
     * Worst case - O(n^2)
     * In-place sorting algorithm
     * 
     * Despite having a worst case of TC - n^2, its very fast and efficient in practical scenario. The worst case scenario could be
     * avoided using randomized version of quick sort. Randomized quick sort gives O(nlogn) in worst case with high probability
     * 
     * 1. Select any element in array and call it pivot
     * 2. Re-arrange list such that all elements lesser than pivot are left side and all elements greater than pviot on right side
     * 3. Now there are 2 subproblems - sorting elements left of pivot and sorting elements right of pivot
     *      Unlike merge sort, here we dont create copies of array, we only track index of array
     * 
     * 
     * 1. Divide and conquer
     * 2. Recursive
     * 3. Not Stable
     * 
    */
    public class _05_QuickSort
    {
        //We are passing start end end index so that we can mark boundaries instead of copying sub lits
        //First call will pass start = 0 , end = array length - 1
        public int[] Sort(int[] arr, bool isLomuto = true)
        {
            if(isLomuto)
                return LomutoSort(arr, 0, arr.Length - 1);
            else
                return HoareSort(arr, 0, arr.Length - 1);
        }
        public int[] LomutoSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pivotIndex = LomutoPartition(arr, start, end);
                LomutoSort(arr, start, pivotIndex - 1);
                LomutoSort(arr, pivotIndex + 1, end);
            }
            return arr;
        }

        public int[] HoareSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pivotIndex = HoarePartition(arr, start, end);
                LomutoSort(arr, start, pivotIndex - 1);
                LomutoSort(arr, pivotIndex + 1, end);
            }
            return arr;
        }

        private int RandomizedPartition(int[] arr, int startIndex, int endIndex)
        {
            int pivotIndex = new Random().Next(startIndex, endIndex);
            Swap(arr, pivotIndex, endIndex);
            return LomutoPartition(arr, startIndex, endIndex);
        }

        // 1. It iterates from both ends at once towards the center. This means that we have more iterations, and more comparisons, but fewer swaps.
        //2. It works by initializing two indexes that start at two ends, the two indexes move toward each other until an inversion is (A smaller value on left side and greater value on right side) found.
        //3. When an inversion is found, two values are swapped and process is repeated.
        private int HoarePartition(int[] arr, int startIndex, int endIndex)
        {
            int pivot = arr[startIndex];
            int i = startIndex - 1;
            int j = endIndex + 1;

            while (true)
            {
                do
                {
                    i++;
                } while(arr[i] < pivot);

                do
                {
                    j--;
                } while (arr[j] > pivot);

                if(i >= j)
                    return j;

                Swap(arr, i, j);
            }
        }

        private int LomutoPartition(int[] arr, int low, int high)
        {
            //Choose the last element as pivot
            int pivot = arr[high];
            Console.WriteLine($"******Low index {low} High index {high} Pivot {pivot}******");
            //Index of the end of the smaller list
            int i = low - 1;
            //Iterate from first element to second last element - till element before pivot
            for (int j = low; j <= high - 1; j++)
            {
                //If current element is smaller than or equal to pivot
                if (arr[j] <= pivot)
                {
                    Console.WriteLine($"{arr[j]} <= {pivot}");
                    i = i + 1;
                    // insert smaller (for ascending) element to the end
                    // of the "smaller" list - i.e. insert from j to i;
                    // here i <= j always
                    Swap(arr, i, j);
                    Console.WriteLine($"Swap index {i} index {j} -> {string.Join(",", arr)}");
                }
            }
            // Now i points to last element smaller than pivot
            i = i + 1;
            //Swap pivot to correct position
            Swap(arr, i, high);
            Console.WriteLine($"Swapping pivot to correct position - swapping index {i} index {high} -> {string.Join(",", arr)}");
            return i;
        }

        private void Swap(int[] arr, int i, int pIndex)
        {
            int temp = arr[i];
            arr[i] = arr[pIndex];
            arr[pIndex] = temp;
        }
    }
}
