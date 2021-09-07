using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.LeetCode.BFS
{
//    Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
//
//    Example:
//
//    Input: [1,2,3,null,5,null,4]
//    Output: [1, 3, 4]
//    Explanation:
//
//    1            <---
//  /   \
// 2     3         <---
//  \     \
//   5     4       <---
    class LeetCode199
    {
        public static IList<int> RightSideViewUsingLL(TreeNode root) {
        
            List<int> result = new List<int>();
            if(root == null) return result;
        
            LinkedList<TreeNode> queue = new LinkedList<TreeNode>();
            queue.AddFirst(root);
            result.Add(root.val);
        
            while(queue.Any()) {
                int size = queue.Count;
                for(int i = 0; i < size; i++){
                    LinkedListNode<TreeNode> current = queue.First;
                    queue.RemoveFirst();
                    if(current.Value.left != null) queue.AddLast(current.Value.left);
                    if(current.Value.right != null) queue.AddLast(current.Value.right);
                }
                var lastOfLevel = queue.Last;
                if(lastOfLevel != null)
                    result.Add(lastOfLevel.Value.val);
            }
        
            return result;
        }

        public static IList<int> RightSideViewUsingQueue(TreeNode root) {
        
            List<int> result = new List<int>();
            if(root == null) return result;
        
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
        
            while(queue.Any()) {
                int size = queue.Count;
                for(int i = 0; i < size; i++){
                    TreeNode current = queue.Dequeue();
                    if(i == size - 1) result.Add(current.val); //right most node of level
                    if(current.left != null) queue.Enqueue(current.left);
                    if(current.right != null) queue.Enqueue(current.right);
                }
            }
        
            return result;
        }
    }
}
