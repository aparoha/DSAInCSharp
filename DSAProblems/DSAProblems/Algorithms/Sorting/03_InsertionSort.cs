namespace DSAProblems.Algorithms.Sorting
{
    public class _03_InsertionSort
    {
        /*  1. Its not the best sorting algorithm but little more efficient than selection sort and bubble sort
         *  2. The idea is 
         *      -> To divide the list into 2 parts - unsorted and sorted
         *      -> Initially all numbers are in unsorted part and sorted part is empty
         *      -> Pick one number from unsorted part at a time and insert it at correct position in sorted part
         *      -> Keep repeating these steps until unsorted part is empty
         *  3. Lets take example of array and assume there is virtual boundary (|) between sorted and unsorted part
         *          
         *          Consider first index value , 7 is sorted and rest of the array is unsorted
         *          7   |   2   4   1   5   3
         *          
         *          Take next index value to a variable, lets assume we taken out 2 from that position and created a hole
         *          value <- 2
         *          7   [HOLE]   4   1   5   3
         *          
         *          To insert 2 into the sorted part, we'll shift all numbers > 2 into the sorted part by 1 position to the right
         *          As we have only 1 element, 7 in sorted part so left shift 7 to the right by one position and the hole will 
         *          go to position zero
         *          [HOLE]  7   4   1   5   3
         *          
         *          Now fill 2 at position 0 and now we sorted till index 1
         *          
         *          2   7   4   1   5   3
         *          
         *          Now take first element from unsorted part and create a hole
         *          
         *          2   7   [HOLE]  1   5   3
         *          value <- 4
         *          
         *          we'll shift all numbers > 4 into the sorted part by 1 position to the right, we'll start at index 1
         *          2   [HOLE]  7  1   5   3
         *          
         *          Now check if 2 > 4 , which is false so no shifting is needed
         *          2   4   7   1   5   3
         *          
         *          Next number is 1
         *          2   4   7   [HOLE]   5   3
         *          value <- 1
         *          2   4   [HOLE]  7   5   3
         *          2   [HOLE]  4  7   5   3
         *          [HOLE]  2   4  7   5   3
         *          1   2   4   7   5   3
         *          
         *          
         *          
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */

        public int[] Sort(int[] arr)
        {
            int size = arr.Length;

            for(int i = 1; i < size; i++)
            {
                int key = arr[i];
                int j = i - 1;
                //Move elements of arr[0..i-1], that are
                //greater than key, to one position ahead
                //of their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }

            return arr;
        }
    }
}
