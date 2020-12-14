using System;
using System.Collections.Generic;
using System.Linq;
using DSAProblems.LeetCode.BFS;

namespace DSAProblems
{
    class Program
    {
        //static List<int> result =  new List<int>();
        static void Main(string[] args)
        {
            Node root = new Node(1) {children = new List<Node>()};
            root.children.Add(new Node(3) {children = new List<Node>
            {
                new Node(5) {children = new List<Node>()}, 
                new Node(6) {children = new List<Node>()}
            }});
            root.children.Add(new Node(2) {children = new List<Node>()});
            root.children.Add(new Node(4) {children = new List<Node>()});

            Console.WriteLine(MaxDepth(root));
            
           Console.ReadLine();
        }

        public static int MaxDepth(Node root) {
        
            int maxDepth = 0;
            if(root == null) return maxDepth;
        
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
        
            while(queue.Any()){
                int size = queue.Count;
                for(int i = 0; i < size; i++){
                    Node current = queue.Dequeue();
                    if (current.children == null) continue;
                    foreach(var child in current.children) 
                        queue.Enqueue(child);
                }
                maxDepth++;
            }
        
            return maxDepth;
        }

    }

                            


}
