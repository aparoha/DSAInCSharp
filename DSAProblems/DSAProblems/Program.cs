using System;
using System.Collections.Generic;
using System.Linq;
using DSAProblems.Algorithms.BinarySearch;
using DSAProblems.Algorithms.DepthFirstSearch;
using DSAProblems.Algorithms.DP;
using DSAProblems.Algorithms.DP.ZeroOneKnapsack;
using DSAProblems.DataStructures.Tree.BinaryTree;
using DSAProblems.LeetCode.BFS;

namespace DSAProblems
{
    class Program
    {
        //static List<int> result =  new List<int>();
        static void Main(string[] args)
        {
//            Node root = new Node(1) {children = new List<Node>()};
//            root.children.Add(new Node(3) {children = new List<Node>
//            {
//                new Node(5) {children = new List<Node>()}, 
//                new Node(6) {children = new List<Node>()}
//            }});
//            root.children.Add(new Node(2) {children = new List<Node>()});
//            root.children.Add(new Node(4) {children = new List<Node>()});
//
//            Console.WriteLine(MaxDepth(root));

//            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4)), new TreeNode(3));
//            Console.WriteLine(IsCousins(root, 4, 3));

//            var gbfs = new GridBfs();
//            Console.WriteLine(gbfs.PathExists(new []
//            {
//                new []{'S', '0', '1', '1'},
//                new []{'1', '1', '0', '1'},
//                new []{'0', '1', '1', '1'},
//                new []{'1', '0', 'D', '1'}
//            }));

                    BinaryTree bt = new BinaryTree();
            DataStructures.Tree.BinaryTree.Node root = bt.CreateNewNode(2);
                    root.left = bt.CreateNewNode(7);
                    root.right = bt.CreateNewNode(5);
                    root.left.left = bt.CreateNewNode(2);
                    root.left.right = bt.CreateNewNode(6);
                    root.left.right.left = bt.CreateNewNode(5);
                    root.left.right.right = bt.CreateNewNode(11);
                    root.right.right = bt.CreateNewNode(9);
                    root.right.right.left = bt.CreateNewNode(4);
            BinarySearchVariants bsv = new BinarySearchVariants();
//            Console.WriteLine(bsv.BsLeftMost(new []{1,2,3,4,4, 4, 4, 4, 5,6}, 4));
//            Console.WriteLine(bsv.BsLeftMost2(new []{1,2,3,4,4, 4, 4, 4, 5,6}, 4));
//
//            Console.WriteLine(bsv.BsRightMost(new []{1,2,3,4,4, 4, 4, 4, 5,6}, 4));
//            Console.WriteLine(bsv.NearestNeighborBs(new []{1,2 ,3 ,4 ,7 ,8 ,10,11,13,14,15 }, 5));
//            Console.WriteLine(bsv.BinarySearchOrNextLargest(new []{1,2 ,3 ,4 ,7 ,8 ,10,11,13,14,15 }, 5));

            RotatedSortedArray rsa = new RotatedSortedArray();

            ZeroOneKnapsack ks = new ZeroOneKnapsack();
            int[] profits = {1, 6, 10, 16};
            int[] weights = {1, 2, 3, 5};
            int maxProfit = ks.solveRMemo(profits, weights, 7, 4);
            Console.WriteLine("Total knapsack profit ---> " + maxProfit);

            
            Console.ReadLine();
        }
    }


}
