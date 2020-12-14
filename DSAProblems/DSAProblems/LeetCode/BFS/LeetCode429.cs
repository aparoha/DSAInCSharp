using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LeetCode.BFS
{
    //Given an n-ary tree, return the level order traversal of its nodes' values.
    //
    //Nary-Tree input serialization is represented in their level order traversal, each group of children is separated by the null value (See examples).
    //
    // Input: root = [1,null,3,2,4,null,5,6]
    // Output: [[1],[3,2,4],[5,6]]
    //
    // Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
    // Output: [[1],[2,3,4,5],[6,7,8,9,10],[11,12,13],[14]]
    class LeetCode429
    {
        public class Node
        {
            public int val;
            public IList<Node> children;
            public Node() {}

            public Node(int _val) {
                val = _val;
            }

            public Node(int _val, IList<Node> _children) {
                val = _val;
                children = _children;
            }
        }
        public IList<IList<int>> LevelOrder(Node root) {
        
            List<IList<int>> result = new List<IList<int>>();
            if(root == null)
                return result;
        
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
        
            while(queue.Any()){
                int size = queue.Count;
                List<int> currentLevel = new List<int>();
                for(int i = 0; i < size; i++){
                    Node current = queue.Dequeue();
                    if(current != null){
                        currentLevel.Add(current.val);
                        foreach(Node child in current.children){
                            queue.Enqueue(child);
                        }
                    }
                }
                result.Add(currentLevel);
            }
        
            return result;
        }
    }
}
