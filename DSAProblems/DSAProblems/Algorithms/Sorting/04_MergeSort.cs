namespace DSAProblems.Algorithms.Sorting
{
    /*
        1. We have talked about 3 sorts which are O(n^2) in average case - selection, bubble, insertion 
        2. Merge sort is O(nlogn) in worst case, space complexity - O(n)
        3. Steps
            a. Break this problem into subproblems - divide the array into 2 possibly equal halves
            b. Get some middle index and elements before this index belongs to first half and elements after this index belongs to second half
            c. Sort these 2 halves (separate arrays) and merge them
        4. Divide and conquer
        5. Recursive
        6. Stable - for equal keys, relative order is same as original list
        7. Not in-place

        Time Complexity
        C1 = lines 24 - 29
        C2 * n = lines 31 - 34
        T(n / 2) = line 36
        T(n / 2) = line 37
        C3*n + C4 = line 40
        T(n) = C , if n = 1
                   if n > 1
        T(n) = C1 + C2 * n + 2 * T (n / 2) + c3 * n + C4
             = 2T(n/2) + (C2+C3)n + (C1+C4)
             = 2T(n/2) + C'n + C''
             = 2T(n/2) + C'n
             = 4T(n/4) + 2C'n
             = 8T(n/8) + 3C'n
             = 16T(n/16) + 4C'n
             = 2^K T(n/2^K) + KC'n
             = 2^logn T(1) + logn C' n
             = n C + C' nlogn
             = O(nlogn)
        
    */
    public class _04_MergeSort
    {
        public int[] Sort(int[] arr)
        {
            int size = arr.Length;
            if(size < 2)
                return arr;
            int mid = size / 2;
            int[] left = new int[mid];
            int[] right = new int[size - mid];
            for (int i = 0; i < mid; i++)
                left[i] = arr[i];
            for (int i = mid; i < size; i++)
                right[i - mid] = arr[i];
            Sort(left);
            Sort(right);
            Merge(left, right, arr);
            return arr;
        }

        void Merge(int[] left, int[] right, int[] arr)
        {
            int nL = left.Length;
            int nR = right.Length;
            int i = 0, j = 0, k = 0;
            while(i < nL && j < nR)
            {
                if(left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while(i < nL)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < nR)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
