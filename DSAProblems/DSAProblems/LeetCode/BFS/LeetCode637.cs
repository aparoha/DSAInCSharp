using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.LeetCode.BFS
{
//    637. Average of Levels in Binary Tree
//    Given a non-empty binary tree, return the average value of the nodes on each level in the form of an array.
//    Example 1:
//    Input:
//    3
//    / \
//    9  20
//    /  \
//    15   7
//    Output: [3, 14.5, 11]
//    Explanation:
//    The average value of nodes on level 0 is 3,  on level 1 is 14.5, and on level 2 is 11. Hence return [3, 14.5, 11].
    class LeetCode637
    {
        public IList<double> AverageOfLevels(TreeNode root) {
            List<double> avg = new List<double>();
            if(root == null) return avg;
        
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
        
            while(queue.Any()){
                int size = queue.Count;
                double sum = 0.0;
                for(int i = 0; i < size; i++){
                    TreeNode current = queue.Dequeue();
                    sum += current.val;
                    if(current.left != null){
                        queue.Enqueue(current.left);
                    }
                    if(current.right != null){
                        queue.Enqueue(current.right);
                    }
                }
                avg.Add(sum/size);
            }
        
            return avg;
        }
    }
}
