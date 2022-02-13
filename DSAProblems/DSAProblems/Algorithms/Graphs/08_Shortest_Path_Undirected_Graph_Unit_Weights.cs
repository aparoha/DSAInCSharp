using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Graphs
{
    /*
        1. Problem of finding a path between two vertices in a graph such that the sum of the weights 
           of its constituent edges is minimized
        2. Types
            Single source shortest path problem
                To find shortest paths from a source vertex v to all other vertices in the graph
                Algorithms
                    Dijkstra's Algorithm - non-negative edge weight
                    Bellman ford algorithm - negative edge weights
                    A* - use heuristics to try to speed up the search
            Single destination shortest path problem - to find shortest paths from all vertices in the directed graph to a single destination vertex v. This can be reduced to the single-source shortest path problem by reversing the arcs in the directed graph
            All pairs shortest path problem - to find shortest paths between every pair of vertices v, v' in the graph.
                Floyd-Warshall Algorithm
     
     */
    public class _08_Shortest_Path_Undirected_Graph_Unit_Weights
    {
        public int[] SingleSourceShortestPathUnitWeights(Dictionary<int, List<int>> graph, int n, int source)
        {
            int[] distance = new int[n];
            for(int i = 0; i < n; i++)
                distance[i] = int.MaxValue;
            Queue<int> queue = new Queue<int>();
            distance[source] = 0;
            queue.Enqueue(source);
            while(queue.Count > 0)
            {
                int current = queue.Dequeue();
                foreach(int neighbor in graph[current])
                {
                    if(distance[neighbor] > distance[current] + 1)
                    {
                        distance[neighbor] = distance[current] + 1;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return distance;
        }
    }
}
