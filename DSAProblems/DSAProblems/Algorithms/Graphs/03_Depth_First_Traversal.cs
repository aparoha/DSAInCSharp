using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Graphs
{
    public class _03_Depth_First_Traversal
    {
        public List<int> Traverse(int n, Dictionary<int, List<int>> graph)
        {
            List<int> result = new List<int>();
            bool[] visited = new bool[n];
            for(int i = 0; i < n; i++)
            {
                if(!visited[i])
                    Dfs(i, visited, graph, result);
            }
            return result;
        }

        private void Dfs(int node, bool[] visited, Dictionary<int, List<int>> graph, List<int> result)
        {
            visited[node] = true;
            result.Add(node);//Add node to result
            foreach(int neighbor in graph[node])
            {
                if(!visited[neighbor])
                    Dfs(neighbor, visited, graph, result);
            }
        }
    }
}
