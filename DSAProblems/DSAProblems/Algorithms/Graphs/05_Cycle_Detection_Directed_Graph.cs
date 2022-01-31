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
    */
    public class _05_Cycle_Detection_Directed_Graph
    {
        public bool IsCycleDfs(int n, Dictionary<int, List<int>> graph)
        {

        }
    }
}
