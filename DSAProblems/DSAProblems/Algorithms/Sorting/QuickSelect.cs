﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.Algorithms.Sorting
{
    public class QuickSelect
    {
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
