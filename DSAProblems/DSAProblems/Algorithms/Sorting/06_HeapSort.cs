using System;
using System.Collections.Generic;

namespace DSAProblems.Algorithms.Sorting
{
    /* 1. Array representation of binary tree
     * 2. Full/Complete Binary Tree
     * 3. Heap
     * 4. Insert and delete
     * 5. Heap sort
     * 6. Heapify
     * 7. Priority Queue
     * 
     * Array representation of binary tree
     * 
     * if a node is at index = i
     * left child = 2 * i + 1
     * right child = 2 * i + 2
     * parent = floor(i - 1/2)
     * 
     * Full Binary Tree - 
     *  Tree with maximum no of nodes and to add new node we need to increase height
     *  Every full binary tree is complete binary tree
     * It can have 2^(h + 1) - 1 nodes
     *                              A                   
     *                          B       C               
     *                       D     E  F     G           
     * Complete Binary Tree
     *  Height - CEIL(log2(n+1))-1
     *  1 node gives log2(2) = 1
        3 nodes gives log2(4) = 2
        7 nodes gives log2(8) = 3
        15 nodes gives log2(16) = 4
     *  It is full binary tree upto height h - 1 and last level nodes filled from left to right
     *                              A
     *                          B       C
     *                       D      E
     * 
     * Heap Sort
     * 1. Create heap from given array elements
     * 2. Delete elements from heap one by one
     * 3. Store the deleted max element at last of array
     * 4. Read array from start to last  - its sorted
     * 
     * Heap property
     * 1. Root node should be greater (lesser for min heap) than all left and right subree nodes and its it recursively true for all its subtrees
     * 2. A leaf node always follows the min/max heap property as there is no child linked to it
     * 
     * 
     * 
     * Heapify
     * 
     * 1. If heapsize is N, range of leaves => ceil(N/2) to (N-1), range of internal nodes => 0 to ceil(N/2)-1
     * 2. We can heapify index i only if all elements in both left and right subrees are following heap property i.e. left and right subtrees
     *    are already a heap thats why build heap always starts from leaf node
     *      Heapify the nodes near the leaves first because their left and right subtree will be following heap property and then
     *      heapify parent internal node i.e. bottom-up
     *      
     *      
     *      
    *
*/

     //    https://algorithmtutor.com/Data-Structures/Tree/Binary-Heaps/
    //https://github.com/gwtw/csharp-sorting/blob/master/src/Heapsort.cs
    public class _06_HeapSort<T> : IGenericSortingAlgorithm<T> where T : IComparable
    {
        public int[] Sort(int[] arr)
        {
            int n = arr.Length;

            // build heap (rearrange array)
            BuildHeap(arr, n);

            // one by one extract an element from heap
            for (int i = n - 1; i >= 0; i--)
            {
                // arr[0] is the root and largest value. The swap moves it in front of the sorted elements
                Swap(arr, 0, i);

                // call max heapify on the reduced heap
                MaxHeapify(arr, i, 0);
            }
            return arr;
        }
        private int Left(int i) => 2 * i + 1;
        private int Right(int i) => 2 * i + 2;

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        private void MaxHeapify(int[] arr, int n, int i)
        {
            int largest = i;
            int l = Left(i);
            int r = Right(i);

            // if left child is larger than root
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // if right child is larger than largest so far
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // if largest is not root
            if (largest != i)
            {
                Swap(arr, i, largest);

                // recursively heapify the affected sub-tree
                MaxHeapify(arr, n, largest);
            }
        }

        private void BuildHeap(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                MaxHeapify(arr, n, i);
        }

        public void Sort(IList<T> list)
        {
            int heapSize = list.Count;
            BuildHeap(list, heapSize);
            while (heapSize > 1)
            {
                Swap(list, 0, heapSize - 1);
                heapSize--;
                Heapify(list, heapSize, 0);
            }
        }

        private void BuildHeap(IList<T> list, int heapSize)
        {
            for (int i = list.Count / 2; i >= 0; i--)
            {
                Heapify(list, heapSize, i);
            }
        }

        private void Heapify(IList<T> list, int heapSize, int i)
        {
            int largest = i;
            int left = Left(i);
            int right = Right(i);
            if (left < heapSize && list[left].CompareTo(list[i]) > 0)
                largest = left;
            if (right < heapSize && list[right].CompareTo(list[largest]) > 0)
                largest = right;
            if (largest != i)
            {
                Swap(list, i, largest);
                Heapify(list, heapSize, largest);
            }
        }

        private void Swap(IList<T> list, int a, int b)
        {
            T temp = list[a];
            list[a] = list[b];
            list[b] = temp;
        }
    }
}
