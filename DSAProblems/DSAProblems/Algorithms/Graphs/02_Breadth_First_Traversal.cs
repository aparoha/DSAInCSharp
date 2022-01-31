using System.Collections.Generic;

namespace DSAProblems.Algorithms.Graphs
{
    //TC - O(V + E) - V time is taken for visiting V nodes and E is for travelling through adjacent nodes overall
    //SC - O(V + E) + O(N) + O(N) - space fo adjacency list + visited array + queue
    public class _02_Breadth_First_Traversal
    {
        public List<int> Traverse(int n, Dictionary<int, List<int>> graph)
        {
            List<int> result = new List<int>();
            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            for(int i = 0; i < n; i++)
            {
                if (!visited[i])
                    Bfs(i, visited, graph, result, queue);
            }
            return result;
        }

        private void Bfs(int node, bool[] visited, Dictionary<int, List<int>> graph, List<int> result, Queue<int> queue)
        {
            visited[node] = true;
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                result.Add(current); //add current node to result
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
    }
}
