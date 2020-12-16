using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.BFS
{
    //Works for LeetCode117 also
    class LeetCode116
    {
        public class Node {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() {}

            public Node(int _val) {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next) {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
        public static Node Connect(Node root) {
            
            if(root == null) return null;
        
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            root.next = null;
        
            while(queue.Any()) {
                int size = queue.Count;
                Node previous = null;
                for(int i = 0; i < size; i++){
                    Node current = queue.Dequeue();
                    if(current.left != null) queue.Enqueue(current.left);
                    if(current.right != null) queue.Enqueue(current.right);
                    if(previous != null) previous.next = current; //As right hand child already have NULL to next so only task to set right to left next
                    previous = current;
                }
            }
        
            return root;
        }
    }
}
