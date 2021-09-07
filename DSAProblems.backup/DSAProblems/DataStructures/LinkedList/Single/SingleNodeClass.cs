using System.Collections.Generic;

namespace DSAProblems.DataStructures.LinkedList.Single
{
    /*
        In this implementation
        1. There is no separate LinkedList Data structure
        2. We access the linked list through a reference to the head node of the linked list
        3. Problem with this approach
           If multiple objects need a reference to the linked list, and then the head of the
           linked list changes, some objects still be pointing to old head
    */
    public class Node
    {
        public Node Next;

        public int _data { get; }

        public Node(int data)
        {
            _data = data;
        }

        public void Append(int data)
        {
            Node current = this;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(data);
        }
    }

    /*
        To solve the issue with above implementation, we can just wrap the head pointer in another class SLinkedList
    */
    public class SLinkedList
    {
        private Node _head; //head pointer

        public void Append(int data)
        {
            if (_head == null)//if list empty
            {
                _head = new Node(data);
                return;
            }
            Node current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(data);
        }

        public void Prepend(int data)
        {
            Node newNode = new Node(data);
            newNode.Next = _head; //As head pointer is poiting to first node
            _head = newNode;
        }

        //Walk through linked list and stop one before the node we want to delete
        public void DeleteWithValue(int data)
        {
            if (_head == null) return;
            if (_head._data == data) // special case to delete head node, just move head pointer to next node after head node (to be deleted) to mark it as new head node
            {
                _head = _head.Next;
                return;
            }
            Node current = _head; //Copy of head pointer
            while (current.Next != null)
            {
                if (current.Next._data == data)
                {
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }
        }

        //Write code to remove duplicates from unsorted linked list
        //4->1->7->15->4->78
        //Two pointers
        //Current - to iterate list
        //Runner - to keep track of duplicates
        public void DeleteDuplicates(Node head)
        {
            if (_head == null) return;
            Node current = head;
            while (current != null)
            {
                Node runner = current;
                while (runner.Next != null)
                {
                    if (runner.Next._data == current._data)
                        runner.Next = current.Next.Next;
                    else
                        runner = runner.Next;
                }
                current = current.Next;
            }
        }


        public void DeleteDuplicates2(Node head)
        {
            // Hash to store seen values
            HashSet<int> hs = new HashSet<int>();
 
            // Pick elements one by one 
            Node current = head;
            Node prev = null;
            while (current != null) 
            {
                int curval = current._data;
         
                // If current value is seen before
                if (hs.Contains(curval))
                {
                    prev.Next = current.Next;
                }
                else
                {
                    hs.Add(curval);
                    prev = current;
                }
                current = current.Next;
            }
        }
    }
}
