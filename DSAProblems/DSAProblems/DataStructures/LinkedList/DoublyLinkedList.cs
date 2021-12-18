using System.Collections;
using System.Collections.Generic;

namespace DSAProblems.DataStructures.LinkedList
{
    public sealed class DoublyLinkedList<T> : IEnumerable<T>
    {
        private DoublyLinkedListNode<T> _head;
        private DoublyLinkedListNode<T> _tail;
        private int _count;
        public int Count => _count;
        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void AddFirst(T data)
        {
            //Case 1 - list is empty
            if(_head == null)
                AddFirstItem(data);
            else
            {
                //Case 2 - list is not empty
                DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(data);
                _head.Previous = node;
                node.Next = _head;
                _head = node;
            }
            _count++;
        }

        public void AddLast(T data)
        {
            //Case 1 - list is empty
            if (_head == null)
                AddFirstItem(data);
            else
            {
                //Case 2 - list is not empty
                DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(data);
                _tail.Next = node;
                node.Previous = _tail;
                _tail = node;
            }
            _count++;
        }

        public void AddAfter(T data, T existing)
        {
            //Case 1 - if existing not found in list
            DoublyLinkedListNode<T> existingNode = Search(existing);
            if(existingNode == null)
                return;
            //Case 2 - if existing is last element
            if(existingNode == _tail)
                AddLast(data);
            else
            {
                //Case 3 - if existing is in middle
                DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(data);
                DoublyLinkedListNode<T> nextNode = existingNode.Next;
                existingNode.Next = node;
                node.Previous = existingNode;
                node.Next = nextNode;
                nextNode.Previous = node;
            }
            _count++;
        }

        public void AddBefore(T data, T existing)
        {
            //Case 1 - if existing not found in list
            DoublyLinkedListNode<T> existingNode = Search(existing);
            if (existingNode == null)
                return;
            //Case 2 - if existing is first element
            if (existingNode == _head)
                AddFirst(data);
            else
            {
                //Case 3 - if existing is in middle
                DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(data);
                DoublyLinkedListNode<T> previousNode = existingNode.Previous;
                previousNode.Next = node;
                node.Previous = previousNode;
                node.Next = existingNode;
                existingNode.Previous = node;
            }
            _count++;
        }

        public T RemoveFirst()
        {
            //Case 1 - List is empty
            if(_head == null)
                return default(T);
            T result = _head.Value;
            //Case 2 - list has one element
            if (_head == _tail)
                _head = _tail = null;
            //Case 3 - list has multiple elements
            else
            {
                _head = _head.Next;
                _head.Previous = null;
            }
            _count--;
            return result;
        }

        public T RemoveLast()
        {
            //Case 1 - List is empty
            if (_head == null)
                return default(T);
            //Case 2 - list has single element
            if (_head == _tail)
                return RemoveFirst();
            //Case 3 - list has more than one element
            T result = _tail.Value;
            _tail = _tail.Previous;
            _tail.Next = null;
            _count--;
            return result;
        }

        public T Remove(T value)
        {
            DoublyLinkedListNode<T> node = Search(value);
            //Case 1 - element is not present
            if(node == null)
                return default(T);
            //Case 2 - node is first node
            if(node == _head)
                return RemoveFirst();
            //Case 3 - node is last element
            if(node == _tail)
                return RemoveLast();
            //Case 4 - node is middle element
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            _count--;
            return node.Value;

        }

        public DoublyLinkedListNode<T> Search(T value)
        {
            DoublyLinkedListNode<T> current = _head;
            while (current != null)
            {
                if (Comparer<T>.Default.Compare(current.Value, value) == 0)
                    return current;
                current = current.Next;
            }
            return null;
        }

        private void AddFirstItem(T item)
        {
            _head = _tail = new DoublyLinkedListNode<T>(item);
        }


        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = _head;
            if (current != null)
            {
                do
                {
                    yield return current.Value;
                    current = current.Next;
                } while (current != _tail);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
