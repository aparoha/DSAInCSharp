using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.DataStructures.Tree.BinaryTree
{
    class Node
    {
        public int data;
        public Node left;
        public Node right;
    }

    class BinaryTree
    {
        //Create Binary Tree using this function
        //        BinaryTree bt = new BinaryTree();
        //        Node root = bt.CreateNewNode(2);
        //        root.left = bt.CreateNewNode(7);
        //        root.right = bt.CreateNewNode(5);
        //        root.left.left = bt.CreateNewNode(2);
        //        root.left.right = bt.CreateNewNode(6);
        //        root.left.right.left = bt.CreateNewNode(5);
        //        root.left.right.right = bt.CreateNewNode(11);
        //        root.right.right = bt.CreateNewNode(9);
        //        root.right.right.left = bt.CreateNewNode(4);
        public Node CreateNewNode(int value)
        {
            Node node = new Node
            {
                data = value,
                left = null,
                right = null
            };
            return node;
        }

        public void InOrder(Node root)
        {
            if (root == null) return;
            InOrder(root.left);
            Console.WriteLine($"{root.data} ");
            InOrder(root.right);
        }

        public void PreOrder(Node root)
        {
            if (root == null) return;
            Console.WriteLine($"{root.data} ");
            PreOrder(root.left);
            PreOrder(root.right);
        }

        public void PostOrder(Node root)
        {
            if (root == null) return;
            PostOrder(root.left);
            PostOrder(root.right);
            Console.WriteLine($"{root.data} ");
        }

        public int GetSumOfAllNodes(Node root)
        {
            if (root == null) return 0;
            return root.data + GetSumOfAllNodes(root.left) + GetSumOfAllNodes(root.right);
        }

        public int GetDifferenceOfValuesAtEvenOddLevels(Node root)
        {
            if (root == null) return 0;
            return root.data - 
                GetDifferenceOfValuesAtEvenOddLevels(root.left) - GetDifferenceOfValuesAtEvenOddLevels(root.right);
        }

        public int GetNoOfNodes(Node root)
        {
            if (root == null) return 0;
            return 1 + GetNoOfNodes(root.left) + GetNoOfNodes(root.right);
        }

        public int GetNoOfLeafNodes(Node root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 1; // leaf node
            return GetNoOfLeafNodes(root.left) + GetNoOfLeafNodes(root.right);
        }

        #region GetHeight

        //TC - O(n) n - no of nodes
        //Two ways to calculate - count no of edges (more correct) vs count no of nodes
        //height == max depth or maxlevel - 1
        //height (bottom - up) (distance from deepest leaf) of node - no of edges in longest path from node to leaf node
        //height of tree with one node = 0
        //height of tree (height of root) - no of edges in longest path from root to leaf node
        //maximum depth of any leaf node from the root node

        //depth (top -> down) (distance from root) of node - no of edges in path from root to that node
        public int GetHeightUsingNoOfEdges(Node root)
        {
            if (root == null) return -1;
            return 1 + Math.Max(GetHeightUsingNoOfEdges(root.left), GetHeightUsingNoOfEdges(root.right));
        }

        public int GetHeightIterative(Node root)
        {
            if (root == null) return -1;

            int height = 0;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    Node current = queue.Dequeue();
                    if(current.left != null) queue.Enqueue(current.left);
                    if(current.right != null) queue.Enqueue(current.right);
                }
                height++;
            }

            return height;
        }

        //No of nodes in longest path from root to leaf node
        public int GetHeightUsingNoOfNodes(Node root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(GetHeightUsingNoOfNodes(root.left), GetHeightUsingNoOfNodes(root.right));
        }
        

        #endregion

        #region PrintNodesAtGivenLevel

                // Algorithm to print nodes at given level
        // Let "node" be the pointer to any node of binary tree and we want to print all nodes at level L.
        //1. Do pre order traversal of given binary tree and keep track of the level of current node
        //2. If level of current node is equal to given level then print it on screen else continue pre order traversal
        //3. If node is equal to NULL, return.
        //4. If level of node is equal to given level, then print node and return.
        //5. Recursively traverse left and right sub trees at level given level + 1.
        //6. Time Complexity : O(n), n is the number of nodes in binary tree. We are traversing binary tree only once.
        public void PrintNodesAtGivenLevelApproach1(Node root, int level)
        {
            //1 - root only, first level
            PrintNodesAtGivenLevelHelper(root, 1, level);
        }

        private void PrintNodesAtGivenLevelHelper(Node root, int currentLevel, int inputLevel)
        {
            if (root == null) return;
            if (currentLevel == inputLevel)
            {
                Console.Write($"{root.data} ");
                return;
            }
            PrintNodesAtGivenLevelHelper(root.left, currentLevel + 1, inputLevel);
            PrintNodesAtGivenLevelHelper(root.right, currentLevel + 1, inputLevel);
        }

        public void PrintNodesAtGivenLevelApproach2(Node root, int level)
        {
            if (root == null) return;
            if (level == 1)
            {
                Console.Write($"{root.data} ");
            }
            PrintNodesAtGivenLevelApproach2(root.left, level - 1);
            PrintNodesAtGivenLevelApproach2(root.right, level - 1);
        }

        public void PrintNodesAtGivenLevelIterative(Node root, int level)
        {
            if (root == null) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            int currentLevel = 1;
            while (queue.Any())
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    Node current = queue.Dequeue();
                    if (currentLevel == level)
                    {
                        Console.Write($"{current.data} ");
                    }
                    if(current.left != null) queue.Enqueue(current.left);
                    if(current.right != null) queue.Enqueue(current.right);
                }
                currentLevel++;
            }
        }

        

        #endregion

        //Get the height of tree then iterate to print nodes
        //Total no of levels = height of tree + 1
        public void LevelOrderTraversalRecursion(Node root)
        {
            if (root == null) return;
            int height = GetHeightUsingNoOfEdges(root);
            for (int i = 0; i <= height; i++)
            {
                PrintNodesAtGivenLevelApproach1(root, i + 1);
                Console.Write("\n");
            }
        }
    }
}
