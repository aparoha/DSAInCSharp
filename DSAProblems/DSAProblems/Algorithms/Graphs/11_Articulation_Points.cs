using System;
using System.Collections.Generic;

namespace DSAProblems.Algorithms.Graphs
{
    public class _11_Articulation_Points
    {
        public List<int> FindAPs(Dictionary<int, List<int>> graph, int n)
        {
            bool[] visited = new bool[n];
            int[] disc = new int[n];
            int[] low = new int[n];

            Array.Fill(disc, -1);
            Array.Fill(low, -1);

            int time = 0;

            List<int> aps = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                    Dfs(i, -1, graph, visited, disc, low, ref time, aps);
            }
            return aps;
        }

        private void Dfs(int v, int parent, Dictionary<int, List<int>> graph, bool[] visited, int[] disc, int[] low, ref int time, List<int> aps)
        {
            visited[v] = true;
            disc[v] = low[v] = time++;
            int children = 0;
            foreach (int to in graph[v])
            {
                if (to == parent)
                    continue;
                if (visited[to])
                {
                    low[v] = Math.Min(low[v], disc[to]); //back edge
                }
                else
                {
                    //This edge is part of DFS tree
                    Dfs(to, v, graph, visited, disc, low, ref time, aps);
                    low[v] = Math.Min(low[v], low[to]);
                    if (low[to] >= disc[v] && parent != -1)
                        aps.Add(v);
                    children++;
                }
            }
            if(parent == -1 && children > 1)
                aps.Add(v);
        }
    }
}
