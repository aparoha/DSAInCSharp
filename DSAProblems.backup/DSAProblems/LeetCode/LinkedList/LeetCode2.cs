using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.LinkedList
{
    /*
    You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

    You may assume the two numbers do not contain any leading zero, except the number 0 itself.

        Input: l1 = [2,4,3], l2 = [5,6,4]
        Output: [7,0,8]
        Explanation: 342 + 465 = 807.
        Example 2:

        Input: l1 = [0], l2 = [0]
        Output: [0]
        Example 3:

        Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
        Output: [8,9,9,9,0,0,0,1]

        Constraints:

        The number of nodes in each linked list is in the range [1, 100].
        0 <= Node.val <= 9
        It is guaranteed that the list represents a number that does not have leading zeros.
    */
    class LeetCode2
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        
            if(l1 == null && l2 == null) return null;
            if(l1 == null) return l2;
            if(l2 == null) return l1;
        
            //As we are creating new list then there is no need to keep track of store l1 and l2 head 
            ListNode dummyNode = new ListNode(0); //dummy node
            ListNode current = dummyNode;

            int carry = 0;
        
            while(l1 != null || l2 != null || carry > 0){ //carry > 0 to check the condition to create new node if last digit sum carry exists
            
                int sum = carry;
                if(l1 != null){
                    sum += l1.val;
                    l1 = l1.next;
                }

                if(l2 != null){
                    sum += l2.val;
                    l2 = l2.next;
                }
            
                ListNode sumNode = new ListNode(sum % 10);
                current.next = sumNode;
                current = current.next;
                carry = sum / 10;
            }

            return dummyNode.next;
        }
    }
}
