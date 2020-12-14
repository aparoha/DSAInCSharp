using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.BFS
{
    //    107. Binary Tree Level Order Traversal II
    //    Given a binary tree, return the bottom-up level order traversal of its nodes' values. (ie, from left to right, level by level from leaf to root).
    //
    //    For example:
    //    Given binary tree [3,9,20,null,null,15,7],
    //    3
    //    / \
    //   9  20
    //   /   \
    //  15    7
    //    return its bottom-up level order traversal as:
    //    [
    //    [15,7],
    //    [9,20],
    //    [3]
    //    ]
    class LeetCode107
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        
            List<IList<int>> result = new List<IList<int>>();
            if(root == null) 
                return result;
        
            Queue<TreeNode> queue = new Queue<TreeNode>();
            Stack<IList<int>> stack = new Stack<IList<int>>();
            queue.Enqueue(root);
        
            while(queue.Any()){
                var currentLevel = new List<int>();
                int size = queue.Count;
                for(int i = 0; i < size; i++){
                    var current = queue.Dequeue();
                    if(current != null){
                        currentLevel.Add(current.val);
                        queue.Enqueue(current.left);
                        queue.Enqueue(current.right);
                    }
                }
                if(currentLevel.Any())
                    stack.Push(currentLevel);
            }
        
            while(stack.Any()){
                var current = stack.Pop();
                result.Add(current);
            }
        
            return result;
        }

        public IList<IList<int>> LevelOrderBottomWithoutStack(TreeNode root) {
        
            List<IList<int>> result = new List<IList<int>>();
            if(root == null) 
                return result;
        
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
        
            while(queue.Any()){
                var currentLevel = new List<int>();
                int size = queue.Count;
                for(int i = 0; i < size; i++){
                    var current = queue.Dequeue();
                    if(current != null){
                        currentLevel.Add(current.val);
                        queue.Enqueue(current.left);
                        queue.Enqueue(current.right);
                    }
                }
                if(currentLevel.Any())
                    result.Insert(0, currentLevel); //if the order of the structure is important and it needs to mutate/change (for example if the new element NEEDS to be at position 4), then Insert is the way to go
            }
        
            return result;
        }
    }
}
