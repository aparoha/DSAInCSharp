using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.LeetCode.BFS
{
    //    Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).
    //
    //    For example:
    //    Given binary tree [3,9,20,null,null,15,7],
    //    3
    //    / \
    //   9  20
    //   /   \
    //  15    7
    //    return its level order traversal as:
    //    [
    //    [3],
    //    [9,20],
    //    [15,7]
    //    ]

    class LeetCode102
    {
        public IList<IList<int>> LevelOrderQueue(TreeNode root)
        {
            var result = new List<IList<int>>();
            if(root == null) 
                return result;
        
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Any()) 
            {
                var currentLevel = new List<int>();
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var frontNode = queue.Dequeue();
                    currentLevel.Add(frontNode.val);
                    if (frontNode.left != null) queue.Enqueue(frontNode.left);
                    if (frontNode.right != null) queue.Enqueue(frontNode.right);
                }
                result.Add(currentLevel);
            }
            return result;    
        }

        public IList<IList<int>> LevelOrderDfs(TreeNode root)
        {
            var result = new List<IList<int>>();
            Dfs(root, 0, result);
            return result;
        }

        private void Dfs(TreeNode root, int level, List<IList<int>> result)
        {
            if (root == null) return;
            if(level == result.Count) result.Add(new List<int>());
            result[level].Add(root.val);
            Dfs(root.left, level + 1, result);
            Dfs(root.right, level + 1, result);
        }
    }
}
