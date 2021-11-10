using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures.Tree.GenericTree
{
    public class Node
    {
        public int data {  get; set; }
        public List<Node> children = new List<Node>();
    }

    public class GenericTree
    {
        Node root;

        /*
         *  1. Create a stack
         *  2. Iterate through array
         *  3. If array element is -1, pop node from stack
         *  4. If array element is not -1, create a node
         *      - If stack is empty, make this node as root node and push to the stack
         *      - If stack is not empty, make this node child of the peek node of stack and push to the stack
         * 
         * 
         * 
         * 
        */
        //int[] arr = new int[] { 10, 20, 50, -1, 60, -1, -1, 30, 70, -1, 80, 110, -1, 120, -1, -1, 40, 100, -1, -1 };
        public Node Create(int[] arr)
        {
            Stack<Node> nodes = new Stack<Node>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == -1)
                    nodes.Pop();
                else
                {
                    Node node = new Node { data = arr[i] };
                    if (nodes.Count > 0) //If some node already in stack add current node as child
                        nodes.Peek().children.Add(node);
                    else
                        root = node; //If stack is empth then make it root
                    nodes.Push(node);
                }
            }
            return root;
        }

        public void Display(Node root)
        {
            var str = root.data + "->";
            foreach(var child in root.children)
                str += child.data + ",";
            str += ".";
            
            Console.WriteLine(str);
            foreach(var child in root.children)
                Display(child);
        }

        public int Size(Node root)
        {
            int size = 0;
            if (root == null)
                return size;
            foreach (var child in root.children)
                size += Size(child);
            size = size + 1; //include itself
            return size;
        }

        public int Max(Node root)
        {
            int currentMax = int.MinValue;
            if(root == null)
                return -1;
            foreach(var child in root.children)
            {
                var childMax = Max(child);
                currentMax = Math.Max(currentMax, childMax);
            }
            return Math.Max(root.data, currentMax);
        }
    }
}
