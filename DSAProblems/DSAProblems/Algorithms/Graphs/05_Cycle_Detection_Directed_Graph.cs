using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Graphs
{
    /*
        Different approaches
        The algorithm we use for directed graph will not work here

        To detect a back edge, we can keep track of vertices currently in 
        recursion stack of function for DFS traversal. 
        If we reach a vertex that is already in the recursion stack, then 
        there is a cycle in the tree. The edge that connects current vertex 
        to the vertex in the recursion stack is a back edge. 
        We have used recStack[] array to keep track of vertices in the recursion stack.

            //False
            Console.WriteLine(cd.IsCycleDfs(4, new Dictionary<int, List<int>>() 
            {
                {0, new List<int> {1, 2} },
                {1, new List<int> {2} },
                {2, new List<int> {3} },
                {3, new List<int>() }
            }));

            //True
            Console.WriteLine(cd.IsCycleDfs(4, new Dictionary<int, List<int>>() 
            {
                {0, new List<int> {1, 2} },
                {1, new List<int> {2} },
                {2, new List<int> {0, 3} },
                {3, new List<int> {3} },
            }));
    */
    public class _05_Cycle_Detection_Directed_Graph
    {
        public bool IsCycleDfs(int n, Dictionary<int, List<int>> graph)
        {
            bool[] visited = new bool[n];
            bool[] dfsVisited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    if (IsCycleDfs(i, graph, visited, dfsVisited))
                        return true;
                }
            }
            return false;
        }

        private bool IsCycleDfs(int current, Dictionary<int, List<int>> graph, bool[] visited, bool[] dfsVisited)
        {
            visited[current] = true;
            dfsVisited[current] = true;
            foreach(int neighbor in graph[current])
            {
                if (!visited[neighbor])
                {
                    if(IsCycleDfs(neighbor, graph, visited, dfsVisited))
                        return true;
                }
                else if(dfsVisited[neighbor])
                    return true;
            }
            dfsVisited[current] = false;
            return false;
        }
    }
}
