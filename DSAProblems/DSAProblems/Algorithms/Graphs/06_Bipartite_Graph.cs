using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Graphs
{
    //A graph with odd no of cycle is not bipartite
    //If a graph doesn't has odd nof of cycle then its bipartite
    public class _06_Bipartite_Graph
    {
        public bool IsBipartitieBfs(int n, Dictionary<int, List<int>> graph)
        {
            int[] colors = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (colors[i] == 0)
                {
                    if (!IsBipartitieBfs(i, graph, colors, i))
                        return false;
                }
            }
            return true;
        }

        private bool IsBipartitieBfs(int node, Dictionary<int, List<int>> graph, int[] colors, int color)
        {
            Queue<int> queue = new Queue<int>();
            colors[node] = color;
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                foreach (int neighbor in graph[current])
                {
                    if (colors[neighbor] == 0)
                    {
                        colors[neighbor] = colors[current] ^ 1; //color with opposite color of parent
                        queue.Enqueue(neighbor);
                    }
                    else if (colors[neighbor] == colors[current])
                        return false;
                }
            }
            return true;
        }

        public bool IsBipartiteDfs(int n, Dictionary<int, List<int>> graph)
        {
            int[] colors = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (colors[i] == 0 && !IsBipartiteDfs(i, graph, colors, i))
                    return false;
            }
            return true;
        }

        private bool IsBipartiteDfs(int node, Dictionary<int, List<int>> graph, int[] colors, int color)
        {
            colors[node] = color;
            foreach(int neighbor in graph[node])
            {
                if(colors[neighbor] == 0)
                {
                    if(!IsBipartiteDfs(neighbor, graph, colors, color ^ 1))
                        return false;
                }
                else if(colors[neighbor] == colors[node])
                    return false;
            }
            return true;
        }
    }
}
