namespace DSAProblems.Algorithms.Sorting
{
    /*
        1. We have talked about 3 sorts which are O(n^2) in average case - selection, bubble, insertion 
        2. Merge sort is O(nlogn) in worst case
        3. Steps
            a. Break this problem into subproblems - divide the array into 2 possibly equal halves
            b. Get some middle index and elements before this index belongs to first half and elements after this index belongs to second half
            c. Sort these 2 halves (separate arrays) and merge them
        
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
            merge(left, right, arr);
            return arr;
        }

        void merge(int[] left, int[] right, int[] arr)
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
