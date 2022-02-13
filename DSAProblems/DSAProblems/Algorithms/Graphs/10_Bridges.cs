using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Graphs
{
    /*
     1. Start at any node and do a DFS traversal labeling nodes with and increasing id value as you go
     2. Keep track of the id of each node and the smallest low-link value
     3. During the DFS, bridges will be found where the id of the node your edge is coming from < low link value of the node your edge is going to
     4. The low-link value of a node is defined as the smallest [lowest] id reachable from that node when doing a DFS (including itself)
            The low-link value of a node is defined as the smallest id reachable from that node using forward and backward edges
      
     */
    public class _10_Bridges
    {
        public List<Edge> FindBridges(Dictionary<int, List<int>> graph, int n)
        {
            bool[] visited = new bool[n];
            int[] disc = new int[n];
            int[] low = new int[n];

            Array.Fill(disc, -1);
            Array.Fill(low, -1);

            int time = 0;

            List<Edge> bridges = new List<Edge>();
            for (int i = 0; i < n; i++)
            {
                if(!visited[i])
                    Dfs(i, -1, graph, visited, disc, low, ref time, bridges);
            }
            return bridges;
        }

        private void Dfs(int v, int parent, Dictionary<int, List<int>> graph, bool[] visited, int[] disc, int[] low, ref int time, List<Edge> bridges)
        {
            visited[v] = true;
            disc[v] = low[v] = time++;
            foreach(int to in graph[v])
            {
                if(to == parent)
                    continue;
                if (visited[to])
                {
                    low[v] = Math.Min(low[v], disc[to]); //back edge
                }
                else
                {
                    //This edge is part of DFS tree
                    Dfs(to, v, graph, visited, disc, low, ref time, bridges);
                    low[v] = Math.Min(low[v], low[to]);
                    if (low[to] > disc[v])
                        bridges.Add(new Edge() { Source = v, Destination = to });
                }
            }
        }

    }
}
