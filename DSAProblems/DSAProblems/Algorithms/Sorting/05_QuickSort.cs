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
                return LomutoSort(arr, 0, arr.Length - 1);
        }
        public int[] LomutoSort(int[] arr, int start, int end)
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

        private int LomutoPartition(int[] arr, int startIndex, int endIndex)
        {
            int pivot = arr[endIndex];
            
            Console.WriteLine($"Before partition : Array looks like {string.Join(",", arr)} pivot {pivot}");
            
            //We'll swap i and partitionIndex as we go through the list when we find values less than or equal to
            //pivot this will become our pivot index in the end as we'll swap the pivot
            //with this element
            int partitionIndex = startIndex; 
            //loop through array excluding the pivot which we hold at the end
            for (int i = startIndex; i < endIndex; i++)
            {
                //we find value less than pivot so we swap it with partition index
                if(arr[i] <= pivot)
                {
                    Console.WriteLine($"{arr[i]} <= {pivot} Swapping {arr[i]} and {arr[partitionIndex]}");
                    //Swap arr[i] with arr[partitionIndex]
                    Swap(arr, i, partitionIndex);
                    //We increase the partitonIndex after the space has been used so one number less
                    //than pivot swapped
                    partitionIndex++;
                }
            }
            
            Console.WriteLine($"Swapping partitionIndex {arr[partitionIndex]} and pivot {arr[endIndex]}");
            //Swap arr[partitionIndex] with pivot value
            Swap(arr, partitionIndex, endIndex);
            Console.WriteLine($"After partition : Array looks like {string.Join(",", arr)}");
            
            return partitionIndex;
        }

        private void Swap(int[] arr, int i, int pIndex)
        {
            int temp = arr[i];
            arr[i] = arr[pIndex];
            arr[pIndex] = temp;
        }
    }
}
