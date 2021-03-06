﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.LeetCode.BFS
{
    //    111. Minimum Depth of Binary Tree
    //    Given a binary tree, find its minimum depth.
    //
    //    The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
    //
    //    Note: A leaf is a node with no children.
    //
    //    Input: root = [3,9,20,null,null,15,7]
    //    Output: 2
    //
    //    Input: root = [2,null,3,null,4,null,5,null,6]
    //    Output: 5
    class LeetCode111
    {
        //Depth of Tree : Depth of tree is same as Height of Tree however it is calculated from top to bottom)
        //Depth of Node : Depth of a node is calculated from traversal from root to a given node. 
        //Height of Tree : Height of  tree represents the height of its root node (calculated from bottom to top).
        //Height of Node : It is the Height from given node to the last possible leaf node.
        //Below code is same as maxDepth except isLeaf condition
        public int MinDepthIterative(TreeNode root) {
        
            int minDepth = 0;
            if(root == null) return minDepth;
        
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            minDepth = 1;

            while(queue.Any()){
                int size = queue.Count;
                for(int i = 0; i < size; i++){
                    TreeNode current = queue.Dequeue();
                    if(current.left == null && current.right == null) return minDepth; //isLeaf, only difference here
                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);
                }
                minDepth++;//Same as maxDepth
            }
        
            return minDepth;
        }

        public int MinDepthRecursive(TreeNode root) {
        
            if(root == null) return 0;
            if(root.left == null && root.right == null) return 1; //isLeaf
            int leftDepth = root.left != null ? MinDepthRecursive(root.left) : int.MaxValue;
            int rightDepth = root.right != null ? MinDepthRecursive(root.right) : int.MaxValue;
        
            return Math.Min(leftDepth, rightDepth) + 1;
        }
    }
}
