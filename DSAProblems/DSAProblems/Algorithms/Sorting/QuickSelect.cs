using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.Algorithms.Sorting
{
    public class QuickSelect
    {
        //Median of medians
        //1. Divide array into chunks
        //2. Calculate median directly for each chunk
        //3. Recursively calculate median of set of medians from previous step
        //4. Use final median of medians as the pivot element
        private int SelectMoM(IEnumerable<int> list, int position)
        {
            var values = new List<int>(list);
            if (values.Count() < 10)
            {
                var l = new List<int>(values);
                l.Sort();
                return l[position - 1];
            }

            var chunkedList = new List<List<int>>();
            var chunkSize = values.Count() / 5;
            var wrapper = new List<int>(values);

            for (var i = 0; i < chunkSize; i++)
                chunkedList.Add(new List<int>(wrapper.GetRange(i * 5, 5)));

            var medians = chunkedList.Select(sl => SelectMoM(sl, 3)).ToList();

            var medianOfMedians = SelectMoM(medians, values.Count() / 10);

            var l1 = new List<int>();
            var l3 = new List<int>();

            foreach (var d in values)
                if (d < medianOfMedians)
                    l1.Add(d);
                else
                    l3.Add(d);

            if (position <= l1.Count)
                return SelectMoM(l1, position);
            else if (position > l1.Count + l3.Count)
                return SelectMoM(l3, position - l1.Count - l3.Count);
            else
                return medianOfMedians;
        }

        public int MedianMom(int[] arr)
        {
            var values = new List<int>(arr);
            if (!values.Any())
                throw new ArgumentException("Must provide at least 1 item");

            var count = values.Count();
            if (count % 2 == 0)
                return SelectMoM(values, count / 2 + 1);
            else
                return SelectMoM(values, count / 2);
        }

        public int Median(int[] arr)
        {
            int length = arr.Length;
            if(length % 2 == 1)
                return SelectIterative(arr, 0, length - 1, length / 2);
            else
            {
                int first = SelectIterative(arr, 0, length - 1, length / 2);
                int second = SelectIterative(arr, 0, length - 1, length / 2 - 1);
                return (first + second) / 2;
            }
        }

        public int KthSmallest(int[] arr, int k)
        {
            return SelectIterative(arr, 0, arr.Length - 1, k - 1);
        }

        public int KthLargest(int[] arr, int k)
        {
            return SelectIterative(arr, 0, arr.Length - 1, arr.Length - k);
        }

        private int SelectRecursive(int[] arr, int low, int high, int k)
        {
            if(low <= high)
            {
                int partition = Partition(arr, low, high);
                if (partition == k)
                    return arr[partition];
                else if (partition > k)
                    return SelectRecursive(arr, low, partition - 1, k);
                else
                    return SelectRecursive(arr, partition + 1, high, k);
            }
            return -1;

        }

        // Implementation of QuickSelect
        public int SelectIterative(int[] a, int low, int high, int k)
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


        //Lomuto partition
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
                } while (arr[i] < pivot);

                do
                {
                    j--;
                } while (arr[j] > pivot);

                if (i >= j)
                    return j;

                Swap(arr, i, j);
            }
        }

        private int RandomizedPartition(int[] arr, int startIndex, int endIndex)
        {
            int pivotIndex = new Random().Next(startIndex, endIndex);
            Swap(arr, pivotIndex, endIndex);
            return Partition(arr, startIndex, endIndex);
        }

        private void Swap(int[] arr, int i, int pIndex)
        {
            int temp = arr[i];
            arr[i] = arr[pIndex];
            arr[pIndex] = temp;
        }
    }
}
