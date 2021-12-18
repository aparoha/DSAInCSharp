using System;
using System.Collections;
using System.Collections.Generic;

namespace DSAProblems.DataStructures.LinkedList
{
    public sealed class CircularDoublyLinkedList<T>: ICollection<T>, IEnumerable<T>
    {
        DoublyLinkedListNode<T> head = null;
        DoublyLinkedListNode<T> tail = null;
        int count = 0;
        readonly IEqualityComparer<T> comparer;
        public CircularDoublyLinkedList()
            : this(null, EqualityComparer<T>.Default)
        {
        }

        public CircularDoublyLinkedList(IEnumerable<T> collection)
            : this(collection, EqualityComparer<T>.Default)
        {
        }

        public CircularDoublyLinkedList(IEqualityComparer<T> comparer)
            : this(null, comparer)
        {
        }

        public CircularDoublyLinkedList(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException("comparer");
            this.comparer = comparer;
            if (collection != null)
            {
                foreach (T item in collection)
                    this.AddLast(item);
            }
        }

        public DoublyLinkedListNode<T> Tail => tail;
        public DoublyLinkedListNode<T> Head => head;
        public int Count => count;

        public DoublyLinkedListNode<T> this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                    throw new ArgumentOutOfRangeException("index");
                else
                {
                    DoublyLinkedListNode<T> node = this.head;
                    for (int i = 0; i < index; i++)
                        node = node.Next;
                    return node;
                }
            }
        }

        public void AddLast(T item)
        {
            // if head is null, then this will be the first item
            if (head == null)
                this.AddFirstItem(item);
            else
            {
                DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(item);
                tail.Next = newNode;
                newNode.Next = head;
                newNode.Previous = tail;
                tail = newNode;
                head.Previous = tail;
            }
            ++count;
        }

        void AddFirstItem(T item)
        {
            head = new DoublyLinkedListNode<T>(item);
            tail = head;
            head.Next = tail;
            head.Previous = tail;
        }

        public void AddFirst(T item)
        {
            if (head == null)
                this.AddFirstItem(item);
            else
            {
                DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(item);
                head.Previous = newNode;
                newNode.Previous = tail;
                newNode.Next = head;
                tail.Next = newNode;
                head = newNode;
            }
            ++count;
        }

        public void AddAfter(DoublyLinkedListNode<T> node, T item)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            // ensuring the supplied node belongs to this list
            DoublyLinkedListNode<T> temp = this.FindNode(head, node.Value);
            if (temp != node)
                throw new InvalidOperationException("Node doesn't belongs to this list");

            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(item);
            newNode.Next = node.Next;
            node.Next.Previous = newNode;
            newNode.Previous = node;
            node.Next = newNode;

            // if the node adding is tail node, then repointing tail node
            if (node == tail)
                tail = newNode;
            ++count;
        }

        public void AddAfter(T existingItem, T newItem)
        {
            // finding a node for the existing item
            DoublyLinkedListNode<T> node = this.Find(existingItem);
            if (node == null)
                throw new ArgumentException("existingItem doesn't exist in the list");
            this.AddAfter(node, newItem);
        }

        public void AddBefore(DoublyLinkedListNode<T> node, T item)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            // ensuring the supplied node belongs to this list
            DoublyLinkedListNode<T> temp = this.FindNode(head, node.Value);
            if (temp != node)
                throw new InvalidOperationException("Node doesn't belongs to this list");

            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(item);
            node.Previous.Next = newNode;
            newNode.Previous = node.Previous;
            newNode.Next = node;
            node.Previous = newNode;

            // if the node adding is head node, then repointing head node
            if (node == head)
                head = newNode;
            ++count;
        }

        public void AddBefore(T existingItem, T newItem)
        {
            // finding a node for the existing item
            DoublyLinkedListNode<T> node = this.Find(existingItem);
            if (node == null)
                throw new ArgumentException("existingItem doesn't exist in the list");
            this.AddBefore(node, newItem);
        }

        public DoublyLinkedListNode<T> Find(T item)
        {
            DoublyLinkedListNode<T> node = FindNode(head, item);
            return node;
        }

        public bool Remove(T item)
        {
            // finding the first occurance of this item
            DoublyLinkedListNode<T> nodeToRemove = this.Find(item);
            if (nodeToRemove != null)
                return this.RemoveNode(nodeToRemove);
            return false;
        }

        bool RemoveNode(DoublyLinkedListNode<T> nodeToRemove)
        {
            DoublyLinkedListNode<T> previous = nodeToRemove.Previous;
            previous.Next = nodeToRemove.Next;
            nodeToRemove.Next.Previous = nodeToRemove.Previous;

            // if this is head, we need to update the head reference
            if (head == nodeToRemove)
                head = nodeToRemove.Next;
            else if (tail == nodeToRemove)
                tail = tail.Previous;

            --count;
            return true;
        }

        public void RemoveAll(T item)
        {
            bool removed = false;
            do
            {
                removed = this.Remove(item);
            } while (removed);
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool RemoveHead()
        {
            return this.RemoveNode(head);
        }

        public bool RemoveTail()
        {
            return this.RemoveNode(tail);
        }

        DoublyLinkedListNode<T> FindNode(DoublyLinkedListNode<T> node, T valueToCompare)
        {
            DoublyLinkedListNode<T> result = null;
            if (comparer.Equals(node.Value, valueToCompare))
                result = node;
            else if (result == null && node.Next != head)
                result = FindNode(node.Next, valueToCompare);
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = head;
            if (current != null)
            {
                do
                {
                    yield return current.Value;
                    current = current.Next;
                } while (current != head);
            }
        }

        public IEnumerator<T> GetReverseEnumerator()
        {
            DoublyLinkedListNode<T> current = tail;
            if (current != null)
            {
                do
                {
                    yield return current.Value;
                    current = current.Previous;
                } while (current != tail);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayIndex < 0 || arrayIndex > array.Length)
                throw new ArgumentOutOfRangeException("arrayIndex");

            DoublyLinkedListNode<T> node = this.head;
            do
            {
                array[arrayIndex++] = node.Value;
                node = node.Next;
            } while (node != head);
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        void ICollection<T>.Add(T item)
        {
            this.AddLast(item);
        }

    }
}
