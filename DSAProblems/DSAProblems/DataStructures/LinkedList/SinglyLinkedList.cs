using System;
using System.Collections;
using System.Collections.Generic;

namespace DSAProblems.DataStructures.LinkedList
{
    /*
     * 1. AddFirst
     * 2. AddLast
     * 3. AddAfter
     * 4. AddBefore
     * 5. RemoveFirst
     * 6. RemoveLast
     * 7. Find
     * 
     */
    public sealed class SinglyLinkedListNode<T>
    {
        public T Value { get; private set; }
        public SinglyLinkedListNode<T> Next { get; internal set; }
        internal SinglyLinkedListNode(T item)
        {
            this.Value = item;
            this.Next = null;
        }
    }
    //https://devwithus.com/implement-linked-list-java/
    //https://github.com/microsoft/referencesource/blob/master/System/compmod/system/collections/generic/linkedlist.cs
    //https://www.algolist.net/Data_structures/Singly-linked_list/Insertion
    public sealed class SinglyLinkedList<T> : IEnumerable<T>
    {
        SinglyLinkedListNode<T> head = null;
        SinglyLinkedListNode<T> tail = null;
        int count;
        readonly IEqualityComparer<T> comparer;

        public SinglyLinkedList(): this(null, EqualityComparer<T>.Default)
        {
        }

        public SinglyLinkedList(IEnumerable<T> collection)
            : this(collection, EqualityComparer<T>.Default)
        {
        }

        public SinglyLinkedList(IEqualityComparer<T> comparer)
            : this(null, comparer)
        {
        }

        public SinglyLinkedList(IEnumerable<T> collection, IEqualityComparer<T> comparer)
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

        public int Count => count;
        public SinglyLinkedListNode<T> Tail => tail;
        public SinglyLinkedListNode<T> Head => head;

        public SinglyLinkedListNode<T> this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                    throw new ArgumentOutOfRangeException("index");
                else
                {
                    SinglyLinkedListNode<T> node = this.head;
                    for (int i = 0; i < index; i++)
                        node = node.Next;
                    return node;
                }
            }
        }

        /*
         * 1. Create a node with data
         * 2. Set's node next to head
         * 3. Make current node as new head
         * 
        */
        public void AddFirst(T data)
        {
            //Case 1 - empty list
            if (head == null)
                AddFirstItem(data);
            else
            {
                //Case 2 = non empty list
                SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>(data);
                node.Next = head;
                head = node;
            }
            count++;
        }

        //O(1)
        public void AddLast(T data)
        {
            //Case 1 - Empty List
            if (head == null)
                AddFirstItem(data);
            else
            {
                //Case 2 - non empty list
                SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>(data);
                tail.Next = node;
                tail = node;
            }
            count++;
        }

        //O(n)
        public void AddLastWithoutTail(T data)
        {
            //Case 1 - Empty List
            if (head == null)
                AddFirstItem(data);
            else
            {
                //Case 2 - non empty list
                SinglyLinkedListNode<T> node = new SinglyLinkedListNode<T>(data);
                SinglyLinkedListNode<T> temp = head;
                while(temp.Next != null)
                    temp = temp.Next;
                temp.Next = node;
            }
            count++;
        }

        private void AddFirstItem(T item)
        {
            head = tail = new SinglyLinkedListNode<T>(item);
        }

        public T RemoveFirst()
        {
            if(head == null) // empty list
                return default(T);
            T result = head.Value;
            if(head == tail) // single element list
                head = tail = null;
            else
                head = head.Next;
            count--;
            return result;
        }

        /*
         * 1. If we have tail pointer then we can move it back one place but how do we move it back. The only way is to go from front
         * 2. How to get node before last node?
         *      - Keep track of current size and remember once we reach current size - 1
         *      - Effective way
         *          a. Create 2 temporary pointers
         *          b. First pointer called - current, it will point to head
         *          c. Second pointer called - previous, it will point to null when we start
         *          d. As we iterate through list, we'll update 
         *              previous = current and current = current.next
         *          e. Keep doing until we reach end of list - 2 ways to check if we reach end of list
         *              current == tail OR current.next == null
         *          f. Set previous.next = null to delete last
         * 
        */
        public T RemoveLast()
        {
            if (head == null) // empty list
                return default(T);
            if (head == tail) // single element list
                return RemoveFirst();
            //2 ways to do - 1) loop till size - 1 2) Two pointers approach
            SinglyLinkedListNode<T> current = head, previous = null;
            while(current != tail) // or current.Next != null
            {
                previous = current;
                current = current.Next;
            }
            previous.Next = null;
            tail = previous;
            count--;
            return current.Value;
        }

        public T Remove(T value)
        {
            SinglyLinkedListNode<T> current = head, previous = null;
            while (current != null)
            {
                if (Comparer<T>.Default.Compare(current.Value, value) == 0)
                {
                    if (current == head)
                        return RemoveFirst();
                    if (current == tail) // or current.Next == null
                        return RemoveLast();
                    count--;
                    previous.Next = current.Next;
                    return current.Value;
                }
                previous = current;
                current = current.Next;
            }
            return default(T);
        }

        public T KthElementFromLast(int k)
        {
            SinglyLinkedListNode<T> slow = head, fast = head;
            while (k > 1)
            {
                fast = fast.Next;
                k--;
            }
            while (fast != tail)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
            return slow.Value;
        }

        public bool Contains(T value)
        {
            SinglyLinkedListNode<T> current = head;
            while(current != null)
            {
                if (Comparer<T>.Default.Compare(current.Value, value) == 0)
                    return true;
                current = current.Next;
            }
            return false;
        }

        public T PeekFirst()
        {
            //Case 1 = list is empty
            if (head == null) 
                return default(T);
            return head.Value;
        }

        //temp.next != null - stop at last node
        //temp != null past the last node
        public T PeekLast()
        {
            //Case 1 = list is empty
            if (head == null) 
                return default(T);
            return tail.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            SinglyLinkedListNode<T> current = head;
            if (current != null)
            {
                do
                {
                    yield return current.Value;
                    current = current.Next;
                } while (current != null);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /* 1. Take 2 pointers - previous set to null, current set to head
 * 2. Iterate till end of list - while current != null
 * 3. Do these 3 things
 *      Store current's next to next
 *      Make current's next as new previous
 *      Make previous as new current
 *      Assign next to current
 * 
 * 
 */
        public SinglyLinkedListNode<T> Reverse()
        {
            SinglyLinkedListNode<T> current = head;
            SinglyLinkedListNode<T> previous = null;
            SinglyLinkedListNode<T> forward = null;

            while (current != null)
            {
                forward = current.Next;
                current.Next = previous;
                previous = current;
                current = forward;
            }

            SinglyLinkedListNode<T> temp = head;
            head = tail;
            tail = temp;

            return head;
        }

        public void Unfold()
        {
            if(head == null || head.Next == null) return;

            SinglyLinkedListNode<T> firstHead = head;
            SinglyLinkedListNode<T> secondHead = head.Next;
            SinglyLinkedListNode<T> firstPrevious = firstHead;
            SinglyLinkedListNode<T> secondPrevious = secondHead;

            while(secondPrevious != null && secondPrevious.Next != null)
            {
                //Backup
                SinglyLinkedListNode<T> forward = secondPrevious.Next;

                //Links
                firstPrevious.Next = forward;
                secondPrevious.Next = forward.Next;

                //Move
                firstPrevious = firstPrevious.Next;
                secondPrevious = secondPrevious.Next;
            }

            firstPrevious.Next = null;

            secondHead = Reverse();
            firstPrevious.Next = secondHead;

        }
    }

}
