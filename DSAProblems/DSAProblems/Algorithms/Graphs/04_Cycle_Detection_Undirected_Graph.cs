using System.Collections.Generic;

namespace DSAProblems.Algorithms.Graphs
{
    /*
        1. For every unvisited node, call BFS
        2. This will use modified Bfs - enqueue node and its parent
        3. We do a BFS traversal of the given graph. 
            For every visited vertex ‘v’, if there is an adjacent ‘u’ such that u is already visited and u is not a parent of v, 
            then there is a cycle in the graph. If we don’t find such an adjacent for any vertex, we say that there is no cycle. 
        4. If there is a visited node which is not parent
    
    
    
    
    
    
    */
    public class _04_Cycle_Detection_Undirected_Graph
    {
        public bool IsCycleBfs(int n, Dictionary<int, List<int>> graph)
        {
            bool[] visited = new bool[n];
            for(int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    if(IsCycleBfs(i, graph, visited))
                        return true;
                }
            }
            return false;
        }

        private bool IsCycleBfs(int node, Dictionary<int, List<int>> graph, bool[] visited)
        {
            Queue<(int, int)> queue = new Queue<(int, int)>();
            visited[node] = true;
            queue.Enqueue((node, -1));
            while(queue.Count > 0)
            {
                (int current, int parent) = queue.Dequeue();
                foreach (int neighbor in graph[current])
                {
                    if (!visited[neighbor]){
                        visited[neighbor] = true;
                        queue.Enqueue((neighbor, current)); //Add recently popped node as parent
                    }
                    //Found a cross edge, neighbor is visited and its not parent
                    else if (neighbor != parent)
                        return true;
                }
            }
            return false;
        }

        public bool IsCycleDfs(int n, Dictionary<int, List<int>> graph)
        {
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    if (IsCycleDfs(i, graph, visited, -1))
                        return true;
                }
            }
            return false;
        }

        private bool IsCycleDfs(int current, Dictionary<int, List<int>> graph, bool[] visited, int parent)
        {
            visited[current] = true;
            foreach (int neighbor in graph[current])
            {
                if (!visited[neighbor])
                {
                    if(IsCycleDfs(neighbor, graph, visited, current))
                        return true;
                }
                //if neighbor is discovered and its not parent
                //found a back edge
                else if (neighbor != parent)
                    return true;
                    
            }
            return false;
        }
    }
}
