using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.BFS
{
//        104. Maximum Depth of Binary Tree
//        Given the root of a binary tree, return its maximum depth.
//
//        A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
// 
//        Input: root = [3,9,20,null,null,15,7]
//        Output: 3
//
//        Input: root = [1,null,2]
//        Output: 2
//
//        Input: root = []
//        Output: 0
//
//        Input: root = [0]
//        Output: 1
        
    class LeetCode104
    {
        public int MaxDepthIterative(TreeNode root) {
        
            int maxDepth = 0;
            if(root == null) return maxDepth;
        
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
        
            while(queue.Any()){
                int size = queue.Count;
                for(int i = 0; i < size; i++){
                    TreeNode current = queue.Dequeue();
                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);
                }
                maxDepth++;
            }
        
            return maxDepth;
        }

        public int MaxDepthR(TreeNode root) {
        
            if(root == null) return 0;
            return Math.Max(MaxDepthR(root.left), MaxDepthR(root.right)) + 1;
        }
    }
}
