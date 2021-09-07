//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//
//namespace DSAProblems.DataStructures.dynamicarray
//{
//    public class DynamicArray<T> : IEnumerable<T>
//    {
//        private T[] arr;
//        private int len = 0; // length user thinks array is
//        private int capacity = 0; // Actual array size
//
//        public DynamicArray() {
//            this(16);
//        }
//
//        public DynamicArray(int capacity) {
//            if (capacity < 0) throw new ArgumentException("Illegal Capacity: " + capacity);
//            this.capacity = capacity;
//            arr = (new T[capacity]);
//        }
//
//        public int size() {
//            return len;
//        }
//
//        public bool isEmpty() {
//            return size() == 0;
//        }
//
//        public T get(int index) {
//            return arr[index];
//        }
//
//        public IEnumerator<T> GetEnumerator()
//        {
//            throw new NotImplementedException();
//        }
//
//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }
//    }
//}
