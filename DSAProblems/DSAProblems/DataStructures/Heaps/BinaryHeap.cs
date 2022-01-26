using System;
using System.Collections.Generic;

namespace DSAProblems.DataStructures.Heaps
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private IList<T> heap;

        public BinaryHeap(T[] elements = null)
        {
            if (elements != null)
            {
                this.heap = new List<T>(elements);
                for (int i = elements.Length / 2; i >= 0; i--)
                {
                    this.HeapifyDown(i);
                }
            }
            else
            {
                this.heap = new List<T>();
            }
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public T ExtractMax()
        {
            var max = this.heap[0];
            this.heap[0] = this.heap[this.Count - 1];
            this.heap.RemoveAt(this.Count - 1);

            if (this.Count > 0)
            {
                this.HeapifyDown(0);
            }

            return max;
        }

        public T PeekMax()
        {
            var max = this.heap[0];

            return max;
        }

        public void Insert(T node)
        {
            this.heap.Add(node);

            this.HeapifyUp(this.Count - 1);
        }

        private void HeapifyDown(int i)
        {
            var leftChild = (i * 2) + 1;
            var rightChild = (i * 2) + 2;
            var biggest = i;

            if (leftChild < this.Count && this.heap[leftChild].CompareTo(this.heap[biggest]) > 0)
            {
                biggest = leftChild;
            }

            if (rightChild < this.Count && this.heap[rightChild].CompareTo(this.heap[biggest]) > 0)
            {
                biggest = rightChild;
            }

            if (biggest != i)
            {
                T old = this.heap[i];
                this.heap[i] = this.heap[biggest];
                this.heap[biggest] = old;
                this.HeapifyDown(biggest);
            }
        }

        private void HeapifyUp(int i)
        {
            var parent = (i - 1) / 2;
            while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) > 0)
            {
                var temp = this.heap[parent];
                this.heap[parent] = this.heap[i];
                this.heap[i] = temp;
                i = parent;
                parent = (i - 1) / 2;
            }
        }
    }
}
