using System;
using System.Collections.Generic;

namespace DSAProblems.DataStructures.Heaps
{
    /*      MinHeap<Employee> minHeap = new MinHeap<Employee>(10);
            minHeap.Insert(new Employee(10));
            minHeap.Insert(new Employee(25));
            minHeap.Insert(new Employee(1));
            minHeap.Insert(new Employee(40));
            minHeap.Insert(new Employee(-1));

            Console.WriteLine(minHeap.Delete().Salary);
            Console.WriteLine(minHeap.Delete().Salary);
            Console.WriteLine(minHeap.Delete().Salary);
            Console.WriteLine(minHeap.Delete().Salary);

    */
    public class MaxHeap<T> where T : IComparable<T>
    {
        private T[] _maxHeap;
        private int _currentSize;
        private int _capacity;

        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;
        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < _currentSize;
        private bool HasRightChild(int index) => GetRightChildIndex(index) < _currentSize;
        private bool HasParent(int index) => GetParentIndex(index) >= 0;
        private T LeftChild(int index) => _maxHeap[GetLeftChildIndex(index)];
        private T RightChild(int index) => _maxHeap[GetRightChildIndex(index)];
        private T Parent(int index) => _maxHeap[GetParentIndex(index)];
        public int Count => _currentSize;

        public MaxHeap(int capacity)
        {
            _capacity = capacity;
            _maxHeap = new T[_capacity];
            _currentSize = 0;
        }

        public MaxHeap(int capacity, T[] elements = null)
        {
            if (elements != null)
            {
                _capacity = capacity;
                _maxHeap = elements;
                _currentSize = _maxHeap.Length;
                for (int i = elements.Length / 2; i >= 0; i--)
                {
                    HeapifyDown(i);
                }
            } 
            else
            {
                _capacity = capacity;
                _maxHeap = new T[_capacity];
                _currentSize = 0;
            }
        }

        public void Insert(T element)
        {
            EnsureExtraCapacity();
            _maxHeap[_currentSize] = element;
            _currentSize++;
            HeapifyUp();
        }

        public T Delete()
        {
            if (_currentSize == 0) throw new Exception();

            T item = _maxHeap[0];
            _maxHeap[0] = _maxHeap[_currentSize - 1];
            _maxHeap[_currentSize - 1] = default(T);
            _currentSize--;
            HeapifyDown();
            return item;
        }

        public void HeapifyDown(int index)
        {
            int leftChild = GetLeftChildIndex(index);
            int rightChild = GetRightChildIndex(index);
            int biggest = index;

            //if left child is bigger
            if(leftChild < _currentSize && _maxHeap[leftChild].CompareTo(_maxHeap[biggest]) > 0)
                biggest = leftChild;
            if (rightChild < _currentSize && _maxHeap[rightChild].CompareTo(_maxHeap[biggest]) > 0)
                biggest = rightChild;

            if(biggest != index)
            {
                Swap(index, biggest);
                HeapifyDown(biggest);
            }
        }

        private void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var biggerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index).CompareTo(LeftChild(index)) > 0)
                {
                    biggerChildIndex = GetRightChildIndex(index);
                }

                if (_maxHeap[index].CompareTo(_maxHeap[biggerChildIndex]) > 0)
                {
                    break;
                }
                else
                {
                    Swap(biggerChildIndex, index);
                    index = biggerChildIndex;
                }
            }
        }

        private void HeapifyUp()
        {
            var index = _currentSize - 1;
            while (HasParent(index) && Parent(index).CompareTo(_maxHeap[index]) < 0)
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }

        private void Swap(int indexOne, int indexTwo)
        {
            T temp = _maxHeap[indexOne];
            _maxHeap[indexOne] = _maxHeap[indexTwo];
            _maxHeap[indexTwo] = temp;
        }

        private void EnsureExtraCapacity()
        {
            if (_currentSize == _capacity)
            {
                Array.Resize(ref _maxHeap, _capacity * 2);
                _capacity *= 2;
            }
        }
    }
}
