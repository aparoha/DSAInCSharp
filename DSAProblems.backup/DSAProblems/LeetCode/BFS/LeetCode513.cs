using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.BFS
{
    class LeetCode513
    {
        public int FindBottomLeftValue(TreeNode root) {
        
            int result = -1;
            if(root == null) return result;
            
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
        
            while(queue.Any()) {
                int size = queue.Count;
                for(int i = 0; i < size; i++){
                    TreeNode current = queue.Dequeue();
                    if(i == 0) result = current.val; // always keep left most node of level, last one is the left most of last row
                    if(current.left != null) queue.Enqueue(current.left);
                    if(current.right != null) queue.Enqueue(current.right);
                }
            }
        
            return result;  
        }
    }
}
