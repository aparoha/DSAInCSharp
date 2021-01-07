namespace DSAProblems.LeetCode.LinkedList
{
    /*
        Given the head of a linked list, rotate the list to the right by k places.
        Input: head = [1,2,3,4,5], k = 2
        Output: [4,5,1,2,3]

        Input: head = [0,1,2], k = 4
        Output: [2,0,1]
    */
    class LeetCode61
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode RotateRight(ListNode head, int k) {

            if(head == null || k == 0) return head;
            int len = 1;
            ListNode current = head;
            while(current.next != null){
                len++;
                current = current.next;
            }
            current.next = head; //now last node pointing to head node
            k = k % len; //this will take care when k > length of list
            for(int i = 1; i <= len - k; i++){
                current = current.next;
            }
            head = current.next;//current was pointing to node before new head
            current.next = null;
            return head;
        }
    }
}
