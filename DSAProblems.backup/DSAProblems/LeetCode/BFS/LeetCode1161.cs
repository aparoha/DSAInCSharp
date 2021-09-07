using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.LeetCode.BFS
{
    //1161. Maximum Level Sum of a Binary Tree
    //
    //Given the root of a binary tree, the level of its root is 1, the level of its children is 2, and so on.
    //Return the smallest level X such that the sum of all the values of nodes at level X is maximal.

    //Example 1:
    //Input: root = [1,7,0,7,-8,null,null]
    //Output: 2
    //Explanation: 
    //Level 1 sum = 1.
    //Level 2 sum = 7 + 0 = 7.
    //Level 3 sum = 7 + -8 = -1.
    //So we return the level with the maximum sum which is level 2.

    //Example 2:
    //Input: root = [989,null,10250,98693,-89388,null,null,null,-32127]
    //Output: 2
    class LeetCode1161
    {
        public int MaxLevelSum(TreeNode root) {
        
            if(root == null) 
                return 0;
        
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int smallestLevel = 1, currentLevel = 1, maxSum = root.val;

            while (queue.Any()) 
            {
                int currentLevelSum = 0;
                int size = queue.Count;

                for (var i = 0; i < size; i++) {
                    var current = queue.Dequeue();
                    currentLevelSum += current.val;

                    if (current.left != null) {
                        queue.Enqueue(current.left);
                    }

                    if (current.right != null) {
                        queue.Enqueue(current.right);
                    }
                }

                if(currentLevelSum > maxSum) {
                    smallestLevel = currentLevel;
                    maxSum = currentLevelSum;
                }
                currentLevel++;
            }

            return smallestLevel;
        }
    }
}
