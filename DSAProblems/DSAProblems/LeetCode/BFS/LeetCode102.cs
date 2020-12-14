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
        public IList<IList<int>> LevelOrder(TreeNode root) {
        
            if(root == null) 
                return new List<IList<int>>();
        
            var result = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Any()) 
            {
                var size = queue.Count;
                var currentLevel = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    var frontNode = queue.Dequeue();
                    if (frontNode != null)
                    {
                        currentLevel.Add(frontNode.val);
                        queue.Enqueue(frontNode.left);
                        queue.Enqueue(frontNode.right);
                    }
                }
                if (currentLevel.Any())
                {
                    result.Add(currentLevel);
                }
            }
            return result;    
        }
    }
}
