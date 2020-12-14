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

     public class TreeNode {
          public int val;
          public TreeNode left;
          public TreeNode right;
          public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
              this.val = val;
              this.left = left;
              this.right = right;
          }
      }

    class LeetCode102
    {
        public IList<IList<int>> LevelOrder(TreeNode root) {
        
            if(root == null) return new List<IList<int>>();
        
            var res = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any()) 
            {
                var size = queue.Count;
                var one = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    var top = queue.Dequeue();
                    if (top != null)
                    {
                        one.Add(top.val);
                        queue.Enqueue(top.left);
                        queue.Enqueue(top.right);
                    }
                }
                if (one.Any())
                {
                    res.Add(one);
                }
            }
            return res;
        
        }
    }
}
