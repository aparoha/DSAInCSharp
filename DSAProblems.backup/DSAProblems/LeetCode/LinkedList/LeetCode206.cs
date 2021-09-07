using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.LinkedList
{
    /*
     Reverse a singly linked list.

        Example:

        Input: 1->2->3->4->5->NULL
        Output: 5->4->3->2->1->NULL
        Follow up:

        A linked list can be reversed either iteratively or recursively. Could you implement both?
     */
    class LeetCode206
    {
        public ListNode ReverseList(ListNode head) {
            if(head == null) return null;
            // Step 1
            ListNode previous = null, current = head, following = head;
            // Step 2
            while(current != null) {
                following = following.next; // Save next, this should be 1st step
                current.next = previous;
                previous = current;          
                current = following;            
            }
            // Step 3  
            return previous;
        }

        public ListNode ReverseListR(ListNode head) {
            if(head?.next == null)
                return head;
            //reverse the rest list and put the first element at the end
            ListNode rest = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return rest;
        }
    }
}
