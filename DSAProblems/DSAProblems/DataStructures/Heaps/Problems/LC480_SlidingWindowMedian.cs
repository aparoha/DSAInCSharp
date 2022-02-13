using System.Collections.Generic;

namespace DSAProblems.DataStructures.Heaps.Problems
{
    public class LC480_SlidingWindowMedian
    {
        private PriorityQueue<int, int> _minHeap = new PriorityQueue<int, int>();//all bigger numbers
        private PriorityQueue<int, int> _maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));//all smaller numbers

        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            double[] medians = new double[nums.Length - k + 1];
            for (int left = 0, right = 0; right < nums.Length; right++)
            {
                AddNum(nums[right]);
                if (right - left + 1 == k)
                {
                    medians[right - k + 1] = FindMedian();
                    Remove(nums[left]);
                    left++;
                }
            }
            return medians;
        }

        public void AddNum(int num)
        {
            if (_maxHeap.Count == 0 || _maxHeap.Peek() >= num)
                _maxHeap.Enqueue(num, num);
            else
                _minHeap.Enqueue(num, num);
            Balance();
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

        public double FindMedian()
        {
            return _maxHeap.Count > _minHeap.Count ?
                _maxHeap.Peek() :
                _minHeap.Peek() / 2.0 + _maxHeap.Peek() / 2.0;
        }

        public void Remove(int num)
        {
            if (num > _maxHeap.Peek())
                Remove(_minHeap, num);
            else
                Remove(_maxHeap, num);
            Balance();
        }

        public void Remove(PriorityQueue<int, int> heap, int num)
        {
            List<int> buffer = new List<int>();
            while (heap.Count > 0 && heap.Peek() != num)
                buffer.Add(heap.Dequeue());
            heap.Dequeue();
            buffer.ForEach(n => heap.Enqueue(n, n));
        }
    }
}
