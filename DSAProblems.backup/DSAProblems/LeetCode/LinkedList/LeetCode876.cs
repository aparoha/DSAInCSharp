namespace DSAProblems.LeetCode.LinkedList
{
    /*
    876. Middle of the Linked List
    Given a non-empty, singly linked list with head node head, return a middle node of linked list.

    If there are two middle nodes, return the second middle node.
    Example 1:

    Input: [1,2,3,4,5]
    Output: Node 3 from this list (Serialization: [3,4,5])
    The returned node has value 3.  (The judge's serialization of this node is [3,4,5]).
    Note that we returned a ListNode object ans, such that:
    ans.val = 3, ans.next.val = 4, ans.next.next.val = 5, and ans.next.next.next = NULL.
    Example 2:

    Input: [1,2,3,4,5,6]
    Output: Node 4 from this list (Serialization: [4,5,6])
    Since the list has two middle nodes with values 3 and 4, we return the second one.

    Note:

    The number of nodes in the given list will be between 1 and 100.
    */
    class LeetCode876
    {
        //Two pointers technique
        //When traversing the list with a pointer slow, make another pointer fast that traverses twice as fast. When fast reaches the end of the list, slow must be in the middle.
        public ListNode MiddleNode(ListNode head) {
        
            ListNode slow = head, fast = head;
            while(fast != null && fast.next != null){
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        //Get length of list and again loop till length / 2
        public ListNode MiddleNode2(ListNode head) {
        
            ListNode current = head;
            int length = 0;
            while(current != null){
                length++;
                current = current.next;
            }
            current = head;
            for(int i = 1; i <= length / 2; i++){
                current = current.next;
            }
            return current;
        }
    }
}
