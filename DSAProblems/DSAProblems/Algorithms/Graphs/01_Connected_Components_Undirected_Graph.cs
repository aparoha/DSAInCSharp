using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Graphs
{
    /*
        1. Disconnedted graph with multiple components
        2. Multiple approaches
            BFS, DFS, Disjoint Sets
        3. For all unvisited vertices - run BFS or DFS
            Count the no of time your code goes inside the if statement
    
    
    

    */
    //LC 323 - https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/
    public class _01_Connected_Components_Undirected_Graph
    {
        public int CountComponentsDfs(int n, int[][] edges)
        {
            if (n <= 1)
                return n;
            Dictionary<int, List<int>> graph = CreateGraph(n, edges);
            int count = 0;
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    Dfs(i, visited, graph);
                    count++;
                }
            }
            return count;
        }

        public int CountComponentsBfs(int n, int[][] edges)
        {
            if (n <= 1)
                return n;
            Dictionary<int, List<int>> graph = CreateGraph(n, edges);
            int count = 0;
            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    Bfs(graph, visited, queue, i);
                    count++;
                }
            }
            return count;
        }

        private static void Bfs(Dictionary<int, List<int>> graph, bool[] visited, Queue<int> queue, int i)
        {
            queue.Enqueue(i);
            visited[i] = true;
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                foreach (int neighbor in graph[current])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        private Dictionary<int, List<int>> CreateGraph(int n, int[][] edges)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
                graph.Add(i, new List<int>());
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            return graph;
        }

        private void Dfs(int node, bool[] visited, Dictionary<int, List<int>> graph)
        {
            foreach (int neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    Dfs(neighbor, visited, graph);
                }
            }
        }
    }
}
