using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.BFS
{
//    1448. Count Good Nodes in Binary Tree
//    Given a binary tree root, a node X in the tree is named good if in the path from root to X there are no nodes with a value greater than X.
//
//    Return the number of good nodes in the binary tree.
//
//    Input: root = [3,1,4,3,null,1,5]
//    Output: 4
//    Explanation: Nodes in blue are good.
//    Root Node (3) is always a good node.
//    Node 4 -> (3,4) is the maximum value in the path starting from the root.
//    Node 5 -> (3,4,5) is the maximum value in the path
//    Node 3 -> (3,1,3) is the maximum value in the path.
    class LeetCode1448
    {
        public int GoodNodesIterative(TreeNode root) {
        
            int result = 0;
            if(root == null) return 0;
        
            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(Tuple.Create(root, int.MinValue));

            while(queue.Any()){
                int size = queue.Count;
                for(int i = 0; i < size; i++){
                    var tuple = queue.Dequeue();
                    var current = tuple.Item1;
                    var maxValue = tuple.Item2;
                    if(current.val >= maxValue) result++;
                    if(current.left != null) queue.Enqueue(Tuple.Create(current.left, Math.Max(maxValue, current.val)));
                    if(current.right != null) queue.Enqueue(Tuple.Create(current.right, Math.Max(maxValue, current.val)));
                }
            }
            return result;
        }

        public int GoodNodesR(TreeNode root)
        {
            return GoodNodesRHelper(root, int.MinValue);
        }

        private int GoodNodesRHelper(TreeNode current, int maxVal)
        {
            if (current == null) return 0;//base case
            int count = 0;
            if (current.val >= maxVal)
            {
                count++;
                maxVal = current.val;
            }
            count += GoodNodesRHelper(current.left, maxVal);
            count += GoodNodesRHelper(current.right, maxVal);
            return count;
        }
    }
}
