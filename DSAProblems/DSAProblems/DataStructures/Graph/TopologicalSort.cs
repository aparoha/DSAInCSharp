using System.Collections.Generic;

namespace DSAProblems.DataStructures.Graph
{
    //Liner ordering of vertices such that if there is an edge u -> v then u appears before v in ordering
    //There could be multiple topological sorting possible for given graph
    //Topological sort is possible only in Directed Acyclic Graph (DAG)
    public class TopologicalSort
    {
        public List<int> topoSort(Dictionary<int, List<int>> graph)
        {
            HashSet<int> visited = new HashSet<int>();
            Stack<int> topoSortNodes = new Stack<int>();
            foreach(int node in graph.Keys)
            {
                if(!visited.Contains(node))
                    dfs(graph, node, visited, topoSortNodes);
            }
            List<int> result = new List<int>();
            while(topoSortNodes.Count > 0)
            {
                result.Add(topoSortNodes.Pop());
            }
            return result;
        }

        private void dfs(Dictionary<int, List<int>> graph, int node, HashSet<int> visited, Stack<int> topoSortNodes)
        {
            visited.Add(node);
            foreach(int neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                    dfs(graph, neighbor, visited, topoSortNodes);
            }
            topoSortNodes.Push(node);
        }
    }
}
