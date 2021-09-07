using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.LinkedList
{
    class LeetCode160
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
            if(headA == null || headB == null) return null;
            HashSet<ListNode> seen = new HashSet<ListNode>();
        
            //Loop first list
            ListNode currentA = headA;
            while(currentA != null){
                if(!seen.Contains(currentA)) seen.Add(currentA);
                currentA = currentA.next;
            }
        
            //Loop second list
            ListNode currentB = headB;
            while(currentB != null){
                if(seen.Contains(currentB)){
                    return currentB;
                }
                currentB = currentB.next;
            }
        
            return null;
        }

        public ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
        {
            int length1 = GetLength(headA);
            int length2 = GetLength(headB);

            var diff = Math.Abs(length1 - length2);

            ListNode cur1 = headA;
            ListNode cur2 = headB;

            if (length1 > length2)
            {
                while (diff != 0)
                {
                    diff--;
                    cur1 = cur1.next;
                }
            }
            else if (length2 > length1)
            {
                while (diff != 0)
                {
                    diff--;
                    cur2 = cur2.next;
                }
            }

            while (cur1 != null && cur2 != null)
            {
                if (cur1 == cur2)
                {
                    return cur1;
                }

                cur1 = cur1.next;
                cur2 = cur2.next;
            }
            return null;
        }

        public ListNode GetIntersectionNode3(ListNode headA, ListNode headB)
        {
            if(headA == null || headB == null) return null;

            ListNode a = headA;
            ListNode b = headB;

            //if a & b have different len, then we will stop the loop after second iteration
            while( a != b){
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;    
            }
            return a;
        }

        private int GetLength(ListNode head)
        {
            int length = 0;
            ListNode current = head;
            while (current != null)
            {
                length++;
                current = current.next;
            }
            return length;
        }
    }
}
