using System;

namespace DSAProblems.LeetCode.LinkedList
{
    public class LeetCode1290
    {
        public int GetDecimalValue(ListNode head)
        {
            ListNode newHead = Reverse(head);
            int result = 0, index = 0;
            while (newHead != null)
            {
                result = result + (int) (newHead.val * Math.Pow(2, index++));
                newHead = newHead.next;
            }
            return result;
        }

        private ListNode Reverse(ListNode head)
        {
            ListNode current = head, following = head, previous = null;
            while (current != null)
            {
                following = current.next;
                current.next = previous;
                previous = current;
                current = following;
            }
            return previous;
        }
    }
}
