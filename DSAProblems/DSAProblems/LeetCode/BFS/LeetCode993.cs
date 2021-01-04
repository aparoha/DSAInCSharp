using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.BFS
{
    class LeetCode993
    {
        TreeNode _xParent;
        TreeNode _yParent;
        int _xDepth = -1, _yDepth = -1;

        public bool IsCousinsIterative(TreeNode root, int x, int y) {
        
            if(root == null) return false;
        
            Dictionary<int, Tuple<int?, int>> parentMap = new Dictionary<int, Tuple<int?, int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            parentMap.Add(root.val, Tuple.Create<int?, int>(null, 0));
        
            while(queue.Any()){
                int size = queue.Count;
                for(int i = 0; i < size; i++){
                    TreeNode current = queue.Dequeue();
                    if(current.left != null){
                        queue.Enqueue(current.left);
                        parentMap.Add(current.left.val, Tuple.Create<int?, int>(current.val, parentMap[current.val].Item2 + 1));
                    }
                    if(current.right != null){
                        queue.Enqueue(current.right);
                        parentMap.Add(current.right.val, Tuple.Create<int?, int>(current.val, parentMap[current.val].Item2 + 1));
                    }
                }      
            }
        
            return (parentMap[x].Item1 != parentMap[y].Item1 && parentMap[x].Item2 == parentMap[y].Item2);
        
        }


        public bool IsCousinsR(TreeNode root, int x, int y) {
            GetDepthAndParent(root, x, y, 0, null);
            return _xDepth == _yDepth && _xParent != _yParent;
        }
        //get both the depth and parent for x and y
        public void GetDepthAndParent(TreeNode root, int x, int y, int depth, TreeNode parent){
            if(root == null){
                return;
            }
            if(root.val == x){
                _xParent = parent;
                _xDepth = depth;
            }else if(root.val == y){
                _yParent = parent;
                _yDepth = depth;
            }       
            GetDepthAndParent(root.left, x, y, depth + 1, root);
            GetDepthAndParent(root.right, x, y, depth + 1, root);
        }
    }
}
