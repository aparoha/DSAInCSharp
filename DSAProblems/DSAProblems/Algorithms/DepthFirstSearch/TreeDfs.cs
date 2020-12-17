using System.Collections.Generic;
using System.Linq;
using DSAProblems.LeetCode.BFS;

namespace DSAProblems.Algorithms.DepthFirstSearch
{
    //Depth first search strategies
    //Most commonly used
    //[root][left][right] - PreOrder - Read the data of the node, then visit the left subtree/nodes, followed by the right subtree/nodes
    //[left][root][right] - InOrder - Visit the left subtree/nodes, then read the data of the node, and finally visit the right subtree/nodes.
    //[left][right][root] - PostOrder - Visit the left subtree/nodes, then visit the right subtree/nodes, and finally read the data of the node.

    //Less commonly used
    //[root][right][left]
    //[right][root][left]
    //[right][left][root]

    //https://leetcode.com/discuss/general-discussion/937307/iterative-recursive-dfs-bfs-tree-traversal-in-pre-post-levelorder-views
    class TreeDfs
    {
    //        1
    //      /   \
    //     2     3
    //    /       \
    //    4       5
    //
    //        Step 1 Creates an empty stack: S = NULL
    //
    //        Step 2 sets current as address of root: current -> 1
    //
    //        Step 3 Pushes the current node and set current = current->left until current is NULL
    //        current -> 1
    //        push 1: Stack S -> 1
    //        current -> 2
    //        push 2: Stack S -> 2, 1
    //        current -> 4
    //        push 4: Stack S -> 4, 2, 1
    //        current = NULL
    //
    //        Step 4 pops from S
    //        a) Pop 4: Stack S -> 2, 1
    //        b) print "4"
    //        c) current = NULL /*right of 4 */ and go to step 3
    //        Since current is NULL step 3 doesn't do anything. 
    //
    //        Step 4 pops again.
    //        a) Pop 2: Stack S -> 1
    //        b) print "2"
    //        c) current -> 5/*right of 2 */ and go to step 3
    //
    //        Step 3 pushes 5 to stack and makes current NULL
    //        Stack S -> 5, 1
    //        current = NULL
    //
    //        Step 4 pops from S
    //        a) Pop 5: Stack S -> 1
    //        b) print "5"
    //        c) current = NULL /*right of 5 */ and go to step 3
    //        Since current is NULL step 3 doesn't do anything
    //
    //        Step 4 pops again.
    //        a) Pop 1: Stack S -> NULL
    //        b) print "1"
    //        c) current -> 3 /*right of 1 */  
    //
    //        Step 3 pushes 3 to stack and makes current NULL
    //        Stack S -> 3
    //        current = NULL
    //
    //        Step 4 pops from S
    //        a) Pop 3: Stack S -> NULL
    //        b) print "3"
    //        c) current = NULL /*right of 3 */  
    //
    //        Traversal is done now as stack S is empty and current is NULL. 

        //Input - [1,2,3,4,5]
        //Output - [4,2,5,1,3]
        //[left root right]
        public List<int> InOrderIterative(TreeNode root) {
            List<int> result = new List<int>();
            if (root == null) return result; 
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
            while(current != null || stack.Any() ) {
                //Reach the left most Node of the  current node 
                while(current != null) {
                    //place pointer to a tree node on the stack before traversing the node's left subtree
                    stack.Push(current);
                    current = current.left;
                }
                //current must be null at this point
                current = stack.Pop();
                result.Add(current.val);
                //we have visited the node and its left subtree.Now, it's right subtree's turn
                current = current.right;
            }
            return result;
        }

        public List<int> InorderTraversalRecursive(TreeNode root) {
            List<int> list = new List<int>();
            InorderTraversalRecursiveHelper(root, list);
            return list;
        }
    
        private void InorderTraversalRecursiveHelper(TreeNode root, List<int> list) {
            if(root == null)
                return;
            InorderTraversalRecursiveHelper(root.left, list);
            list.Add(root.val);
            InorderTraversalRecursiveHelper(root.right, list);
        }
        
        //Input - [1,2,3,4,5]
        //Output - [1 2 4 5 3]
        //[root left right]
        public List<int> PreorderTraversalIterative(TreeNode root) {
            List<int> list = new List<int>();
            if(root == null)
                return list;
            //Create an empty stack and push root to it
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            //Pop all items one by one, Do following fo revery popped item
                //Add it it result or print it
                //Push its right child
                //Push its left child
            //Note -> Right child is pushed first so that left is processed first
            while(stack.Any()) {
                root = stack.Pop();
                list.Add(root.val);
                //Push right an dleft children of the popped node to stack
                if(root.right != null)
                    stack.Push(root.right);
                if(root.left != null)
                    stack.Push(root.left);
            }
        
            return list;
        }
    }
}
