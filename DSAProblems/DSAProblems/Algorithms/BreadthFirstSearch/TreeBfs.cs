using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.Algorithms.DepthFirstSearch
{
    //What does it mean to traverse a tree?
    //1. Tree traversal (also called tree search) is a form of graph traversal
    //2. Traversing a tree is usually known as th eprocess of either checking or updating each node in the tree exactly once
    //3. The order in which we visit nodes while traversing a tree is important 
    //4. The order of traversal is how we classify the different traversal algorithms

    //There are 2 ways to traverse a tree
    //1. Breadth first
    //      a. Go wide
    //      b. Traverse through all th echildren of a node before moving on to check/visit the granchildren nodes
    //2. Depth first
    //      a. Go deep
    //      b. Traverse through the grandchildren of a path before moving on to a new path
    //      c. In depth-first search, once we start down a path, we don’t stop until we get to the end. In other words, we traverse through one branch of a tree until we get to a leaf, and then we work our way back to the trunk of the tree


    public class Node
    {
        public int data;
        public Node left, right;
        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
        
    class TreeBfs
    {
        //BFS
        public List<int> LevelOrder(Node root)
        {
            if (root == null) return null;
            List<int> retVal = new List<int>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                Node current = queue.Dequeue();
                retVal.Add(current.data); //Visit Node, print or add in result
                if(current.left != null) queue.Enqueue(current.left);
                if(current.right != null) queue.Enqueue(current.right);
            }
            return retVal;
        }

        //        [3,9,20,null,null,15,7]
        //        3
        //       / \
        //      9  20
        //      /   \
        //     15    7
        //  Output
        //        [
        //        [3],
        //        [9,20],
        //        [15,7]
        //        ]
        public IList<IList<int>> LevelOrderLevelByLevel(Node root)
        {
            var result = new List<IList<int>>();
            if(root == null) 
                return result;
        
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Any()) 
            {
                var currentLevel = new List<int>();
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var frontNode = queue.Dequeue();
                    currentLevel.Add(frontNode.data);
                    if (frontNode.left != null) queue.Enqueue(frontNode.left);
                    if (frontNode.right != null) queue.Enqueue(frontNode.right);
                }
                result.Add(currentLevel);
            }
            return result;    
        }

        public List<int> LevelOrderR(Node root)
        {
            int h = GetHeight(root);
            List<int> result = new List<int>();
            for (int i = 1; i <= h; i++)
            {
                LevelOrderRHelper(root, i, result);
            }
            return result;
        }

        private int GetHeight(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            int lheight = GetHeight(root.left);
            int rheight = GetHeight(root.right);
            return lheight > rheight ? lheight + 1 : rheight + 1; //Use larger one
        }

        private void LevelOrderRHelper(Node root, int level, List<int> result)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                result.Add(root.data);
            }
            else if (level > 1)
            {
                LevelOrderRHelper(root.left, level - 1, result);
                LevelOrderRHelper(root.right, level - 1, result);
            }
        }

        //The height of a node is the length of the longest downward path to a leaf from that node. The height of the root is the height of the tree.
        //An empty tree has height -1
        public int TreeHeight(Node root)
        {
            int height = -1;
            if (root == null) return height;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                int nodesAtCurrentLevel = queue.Count;
                height++;
                //Dequeue all nodes of current level and Enqueue all nodes of next level 
                for (int i = 0; i < nodesAtCurrentLevel; i++)
                {
                    Node currentLevelNode = queue.Dequeue();
                    if(currentLevelNode.left != null) queue.Enqueue(currentLevelNode.left);
                    if(currentLevelNode.right != null) queue.Enqueue(currentLevelNode.right);
                }
            }

            return height;
        }
     
    }
}
