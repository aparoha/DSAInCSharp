using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.DataStructures.Heaps.Problems
{
    /*
        Partition numbers into 2 heaps - maxHeap (for all smaller numbers) minHeap (for all bigger numbers)
        Balance heaps
        Find median
            odd - maxHeap peek
            even - average of minHeap peek and maxHeap peek
     
     */
    public class MedianFinder
    {
        private readonly PriorityQueue<int, int> _minHeap;
        private readonly PriorityQueue<int, int> _maxHeap;

        public MedianFinder()
        {
            _minHeap = new PriorityQueue<int, int>();
            _maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        }

        public void AddNum(int num)
        {
            if (_maxHeap.Count == 0 || _maxHeap.Peek() >= num)
                _maxHeap.Enqueue(num, num);
            else
                _minHeap.Enqueue(num, num);
            Balance();
        }

        public double FindMedian()
        {
            return _maxHeap.Count > _minHeap.Count ?
                _maxHeap.Peek() :
                _minHeap.Peek() / 2.0 + _maxHeap.Peek() / 2.0;
        }

        private void Balance()
        {
            if (_maxHeap.Count == _minHeap.Count)
                return;
            if (_maxHeap.Count > _minHeap.Count + 1)
            {
                int maxHeapPeek = _maxHeap.Dequeue();
                _minHeap.Enqueue(maxHeapPeek, maxHeapPeek);
            }
            else if (_maxHeap.Count < _minHeap.Count)
            {
                int minHeapPeek = _minHeap.Dequeue();
                _maxHeap.Enqueue(minHeapPeek, minHeapPeek);
            }
        }
    }
}
