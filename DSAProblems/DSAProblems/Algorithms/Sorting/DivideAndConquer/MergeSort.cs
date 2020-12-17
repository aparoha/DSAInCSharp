namespace DSAProblems.Algorithms.Sorting.DivideAndConquer
{
    //Time complexity
    //Worst - O(nlogn)
    //Best - O(nlogn)
    //Average - O(nlogn)

    //https://www.geeksforgeeks.org/iterative-merge-sort/
    class MergeSort
    {
        public void MergeSortR(int[] arr, int l, int r)
        {
            if (l < r)
            {
            
                // Same as (l+r)/2 but avoids 
                // overflow for large l & h
                int m = l + (r - l) / 2; 
                MergeSortR(arr, l, m);
                MergeSortR(arr, m+1, r);
                Merge(arr, l, m, r);
            }
        }

        private void Merge(int[] arr, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;
     
            /* create temp arrays */
            int []L = new int[n1];
            int []R = new int[n2];
     
            /* Copy data to temp arrays L[] and R[] */
            for (i = 0; i < n1; i++)
                L[i] = arr[l + i];
            for (j = 0; j < n2; j++)
                R[j] = arr[m + 1+ j];
     
            /* Merge the temp arrays back into arr[l..r]*/
            i = 0;
            j = 0;
            k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
     
            /* Copy the remaining elements of L[], if there are any */
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
     
            /* Copy the remaining elements of R[], if there are any */
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
    }
}
