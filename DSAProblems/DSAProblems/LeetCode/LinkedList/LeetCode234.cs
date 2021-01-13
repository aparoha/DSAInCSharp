using System.Collections.Generic;

namespace DSAProblems.LeetCode.LinkedList
{
    /*
     234. Palindrome Linked List
     Given a singly linked list, determine if it is a palindrome.

    Example 1:

    Input: 1->2
    Output: false
    Example 2:

    Input: 1->2->2->1
    Output: true
    Follow up:
    Could you do it in O(n) time and O(1) space? 
     */
    class LeetCode234
    {
        public bool IsPalindrome(ListNode head) {
            if(head == null) return true;
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode current = head;
            while(current != null){
                stack.Push(current);
                current = current.next;
            }
            current = head;
            while(current != null){
                int popped = stack.Pop().val;
                if(current.val != popped){
                    return false;
                }
                current = current.next;
            }
            return true;
        }

        public bool IsPalindrome2(ListNode head) {
            if(head == null) return true;
            //Get Middle
            //Reverse second half
            //Compare linked list values

            //Step 1 Get middle
            ListNode slow = head, fast = head;
            while (fast?.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            //Step 2 reverse second half
            slow = Reverse(slow);

            //Step 3 - compare values
            while (slow != null)
            {
                if (head.val != slow.val) {
                    return false;
                }
                head = head.next;
                slow = slow.next;
            }
            return true;
        }

        private ListNode Reverse(ListNode head)
        {
            ListNode previous = null, current = head;
            while (current != null)
            {
                var following = current.next;
                current.next = previous;
                previous = current;
                current = following;
            }
            return previous;
        }
    }
}
