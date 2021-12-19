using System;

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
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] _minHeap;
        private int _currentSize;
        private int _capacity;

        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;
        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < _currentSize;
        private bool HasRightChild(int index) => GetRightChildIndex(index) < _currentSize;
        private bool HasParent(int index) => GetParentIndex(index) >= 0;
        private T LeftChild(int index) => _minHeap[GetLeftChildIndex(index)];
        private T RightChild(int index) => _minHeap[GetRightChildIndex(index)];
        private T Parent(int index) => _minHeap[GetParentIndex(index)];
        public int Count => _currentSize;

        public MinHeap(int capacity)
        {
            _capacity = capacity;
            _minHeap = new T[_capacity];
            _currentSize = 0;
        }

        public void Insert(T element)
        {
            EnsureExtraCapacity();
            _minHeap[_currentSize] = element;
            _currentSize++;
            HeapifyUp();
        }

        public T Delete()
        {
            if (_currentSize == 0) throw new Exception();

            T item = _minHeap[0];
            _minHeap[0] = _minHeap[_currentSize - 1];
            _minHeap[_currentSize - 1] = default(T);
            _currentSize--;
            HeapifyDown();
            return item;
        }

        private void HeapifyDown(int index)
        {
            int leftChild = GetLeftChildIndex(index);
            int rightChild = GetRightChildIndex(index);
            int smallest = index;

            //if left child is smaller
            if (leftChild < _currentSize && _minHeap[leftChild].CompareTo(_minHeap[smallest]) < 0)
                smallest = leftChild;
            if (rightChild < _currentSize && _minHeap[rightChild].CompareTo(_minHeap[smallest]) < 0)
                smallest = rightChild;

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        private void HeapifyDown()
        {
            var index = 0;
            while (HasLeftChild(index))
            {
                var smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index).CompareTo(LeftChild(index)) < 0)
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }
                
                if (_minHeap[index].CompareTo(_minHeap[smallerChildIndex]) < 0)
                {
                    break;
                }
                else
                {
                    Swap(smallerChildIndex, index);
                    index = smallerChildIndex;
                }
            }
        }

        private void HeapifyUp()
        {
            var index = _currentSize - 1;
            while (HasParent(index) && Parent(index).CompareTo(_minHeap[index]) > 0)
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }

        private void Swap(int indexOne, int indexTwo)
        {
            T temp = _minHeap[indexOne];
            _minHeap[indexOne] = _minHeap[indexTwo];
            _minHeap[indexTwo] = temp;
        }

        private void EnsureExtraCapacity()
        {
            if (_currentSize == _capacity)
            {
                Array.Resize(ref _minHeap, _capacity * 2);
                _capacity *= 2;
            }
        }
    }

    public class Employee : IComparable<Employee>
    {
        private int _salary;
        public Employee(int salary)
        {
            _salary = salary;
        }
        public int Salary => _salary;

        public int CompareTo(Employee other)
        {
            return this.Salary.CompareTo(other.Salary);
        }
    }
}
