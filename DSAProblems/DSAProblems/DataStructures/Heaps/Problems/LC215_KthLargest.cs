using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures.Heaps.Problems
{
    public class LC215_KthLargest
    {
        //O(klogn)
        public int FindKthLargestMaxHeap(int[] nums, int k)
        {
            PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(nums.Select(num => (num, num)),
                Comparer<int>.Create((num1, num2) => num2.CompareTo(num1)));
            for (int i = 0; i < k - 1; i++)
                maxHeap.Dequeue();
            return maxHeap.Dequeue();
        }

        //O(nlogk)
        public int FindKthLargestMinHeap(int[] nums, int k)
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            foreach (int num in nums)
            {
                minHeap.Enqueue(num, num);
                if (minHeap.Count > k)
                    minHeap.Dequeue();
            }
            return minHeap.Dequeue();
        }

        public int FindKthLargestQuickSelect(int[] nums, int k)
        {
            return SelectIterative(nums, 0, nums.Length - 1, nums.Length - k);
        }

        private int SelectIterative(int[] a, int low, int high, int k)
        {
            while (low <= high)
            {
                int partition = Partition(a, low, high);
                if (partition == k)
                    return a[partition];
                else if (partition > k)
                    high = partition - 1;
                else
                    low = partition + 1;
            }
            return -1;
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j] <= pivot)
                {
                    i = i + 1;
                    Swap(arr, i, j);
                }
            }
            i = i + 1;
            Swap(arr, i, high);
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
