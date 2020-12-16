using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.BFS
{
    //515. Find Largest Value in Each Tree Row
    //Given the root of a binary tree, return an array of the largest value in each row of the tree (0-indexed).
    //    Input: root = [1,3,2,5,3,null,9]
    //    Output: [1,3,9]
    //
    //    Input: root = [1,2,3]
    //    Output: [1,3]
    //
    //    Input: root = [1]
    //    Output: [1]
    //
    //    Input: root = [1,null,2]
    //    Output: [1,2]
    //
    //    Input: root = []
    //    Output: []
    class LeetCode515
    {
        public IList<int> LargestValues(TreeNode root) {
        
            List<int> result = new List<int>();
            if(root == null) return result;
        
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
        
            while(queue.Any()) {
                int size = queue.Count;
                int max = int.MinValue;
                for(int i = 0; i < size; i++){
                    TreeNode current = queue.Dequeue();
                    max = Math.Max(current.val, max);
                    if(current.left != null){
                        queue.Enqueue(current.left);
                    }
                    if(current.right != null){
                        queue.Enqueue(current.right);
                    }
                }
                result.Add(max);
            }
        
            return result;
        }
    }
}
