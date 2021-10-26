using System;

namespace DSAProblems.Algorithms.Sorting
{
    /*
     * Rules
     *  1) A selection sort algorithm will divide its input list into a sorted and an unsorted section
     *  2) A selection sort algorithm will swap the smallest element it finds in each iteration, and add it to the sorted section
     *         of elements
     *         
     * Steps
     * 1) Set the smallest number to be the first element in the list.
       2) Look through the entire list and find the actual smallest number.
       3) Swap that value with the item at the index of the smallest number.
       4) Move on to look at the next unsorted item in the list, repeat steps 2 + 3.
       5) Continue to do this until we arrive at the last element in the list.

     * Another way of looking
     * 
     * Another way of looking at what’s actually happening when we swap is this: 
     * we find the smallest item in the array/list/dataset/collection, and then swap it with the first unordered item in the list. 
     * Then, we find the 2nd smallest item, and swap it with the second unordered item in the list. 
     * Then, find the 3rd smallest item, and swap it with the third unordered item. 
     * This process keeps going until the last item we’re looking at is the last item in the list, and there’s no sorting left to do!
     * 
     * 
     * 
     * There are two important aspects to the time complexity of selection sort: 
     * 1. how many comparisons the algorithm will make - C(n) 
     * 2. how many times it has to move or swap elements in the process of sorting - M(n)
     * 
     * Comparison count
     *  To sort n elements. selection sort has to perform n - 1 passes
     *  ->On the 1st pass, ot performs n -1 comparisons in order to find the smallest element
     *  ->On the 2nd pass, it performs n -2 comparisons
     *  ->On the (n - 1)st pass, it performs 1 comparisons, which compares the last 2 items
     *  
     *  If we add all comparisons up, the approximate number of compares is
     *      C(n) = n^2/2
     * 
     * Move count
     * In a worst case, to iterate through an unordered list, we might have to swap every element, so the potential move count is M(n)= n
     * 
     * Time complexity - O(n^2)
     * Space complexity - in-place
     * Stability - Unstable
     * Internal/External - internal
     * Recursive/non-recursive - recursive
     * Comparison sort - comparison
     * 

    */
    public class _01_SelectionSort
    {
        public int[] sort(int[] arr)
        {
            int size = arr.Length;
            for(int index = 0; index < size - 1; index++)
            {
                int smallestNumIndex = index; //Assume first index is the minimum 
                for(int nextNumIndex = index + 1; nextNumIndex < size; nextNumIndex++)
                {
                    Console.WriteLine($"Comparing {arr[smallestNumIndex]} and {arr[nextNumIndex]}");
                    // To sort in descending order, change sign to >
                    if (arr[nextNumIndex] < arr[smallestNumIndex])
                        smallestNumIndex = nextNumIndex; //Update index of minimum element
                }
                if(smallestNumIndex != index)
                {
                    Console.WriteLine($"Swapping the number {arr[smallestNumIndex]} for the number {arr[index]}");
                    int currentNumber = arr[index];
                    arr[index] = arr[smallestNumIndex];
                    arr[smallestNumIndex] = currentNumber;
                }
                Console.WriteLine($"Numbers currently looks like {string.Join(",", arr)}");
            }
            return arr;
        }
    }
}
