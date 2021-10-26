namespace DSAProblems.Algorithms.Sorting
{
    public class _02_BubbleSort
    {
        /*
         *  1. Given list of integers
         *  2. We are going to scan array from left to right multiple times
         *  3. We will call each scan as "one pass" on the array
         *  4. In each scan, we'll compare current element with adjacent element (next element)
         *  5. If element at current position is greater than the next adjacent element then swap these two elements
         *  6. After each pass (lest say n pass), nth largest element will be at the correct position i.e. after first pass, 
         *     largest element will move to the right most index
         *  7. With every pass on array, array will be divided into 2 parts - unsorted part and sorted part
         *  8. With each pass, the largest element in the unsorted half will bubble up to the highest index in the unsorted part
         *  
         *  The algorithm consists of two nested loops. The index j in the inner loop travels up the array, 
         *  comparing adjacent entries in the array (at j and j+1), while the outer loop causes the inner 
         *  loop to make repeated passes through the array. After the first pass, the largest element is 
         *  guaranteed to be at the end of the array, after the second pass, the second largest element 
         *  is in position, and so on. That is why the upper bound in the inner loop (n-1-i) decreases with each pass: 
         *  we don't have to re-visit the end of the array.
         *
         * Why bubble sort outer loop end at (n - 1)?
         *  1. It is because the largest element is already sorted in the first iteration
         *  2. There is no need for the last element because bubble sort is all about swapping adjacent elements and the last element 
         *     doesn't have any adjacent element
         *  3. Array indexing is done as 0 to n-1. If there are 10 elements in array, indexing will be n-1. 
         *     So in first, iteration of inner loop (n-1) comparison will take place. 
         *     First pass of bubble sort will bubble up the largest number to its position.
         *     In the next iteration (n-1-1) iteration will take place and it will bubble up the second largest value to its place 
         *     and so on until the whole array is sorted.
         *     
         *     
         *     how many iterations we’d have to make given an array with n elements

                1. For 2 numbers we'd need to iterate once {9, 8} -> {8, 9}
                2. For 3 numbers we'd need to iterate twice {9, 8, 7} -> {8, 7, 9} -> {7, 8, 9}
                3. For 4 numbers, we'd need to iterate thrice to sort

                In general, it takes (n - 1) iterations in order to sort a collection of n elements

                1. After two iterations through our array, checking the last two elements was unnecessary, since they were already sorted.
                2. After three iterations through our array, checking last 3 elements is unnecessary
                Pattern - After x iterations, checking last x elements is redundant
         *
        */

        //In this algorithm, all the comparisons are made even if the array is already sorted
        //This increases the execution time

        //Outer loop tells the number of passes required to sort a list - to sort a list of n elements (n - 1) passes are required
        //Inner loop is basically there to decrease the comparison with each pass (n - pass - 1), after each iteration, since with each pass,
        //we place the largest element to the right side(of the logically unsorted list). Hence since that element is in it's rightful position, 
        //so we don't have to compare that with other elements.
        public int[] UnoptimizedSort(int[] arr)
        {
            int size = arr.Length;

            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
                    }
                }
            }

            return arr;
        }

        //To solve above problem, we can introduce an extra variable swapped.
        //The value of swapped is set true if there occurs swapping of elements. Otherwise, it is set false.
        //After an iteration, if there is no swapping, the value of swapped will be false.
        //This means elements are already sorted and there is no need to perform further iterations.
        //This will reduce the execution time and helps to optimize the bubble sort.
        public int[] OptimizedSort(int[] arr)
        {
            int size = arr.Length;

            for (int i = 0; i < size - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }
                if(!swapped)
                    break;
            }

            return arr;
        }
    }
}
