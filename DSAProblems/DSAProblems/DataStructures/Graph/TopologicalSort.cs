using System.Collections.Generic;

namespace DSAProblems.DataStructures.Graph
{
    //Liner ordering of vertices such that if there is an edge u -> v then u appears before v in ordering
    //There could be multiple topological sorting possible for given graph
    //Topological sort is possible only in Directed Acyclic Graph (DAG)

    //1. Using DFS
    //2. Using BFS
    //3. Shortest Path in DAG
    //4. Longest Path in DAG
    //5. Cycle Detection
    public class TopologicalSort
    {
        public List<int> topoSortUsingDfs(Dictionary<int, List<int>> graph)
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

        //1. Create indegree array or map - indegree is no of edges coming to node
        //2. Traverse through indegree and whatever node has indegree as 0, add to the queue
        //3. Run BFS from queue, whenever dequeuing node from queue, add it to topological sort result
        public List<int> topoSortUsingBfs(Dictionary<int, List<int>> graph)
        {
            //Step 1 - Get indegrees of all vertices
            Dictionary<int, int> inDegree = new Dictionary<int, int>();
            //All in-degrees are 0
            foreach(var node in graph.Keys)
                inDegree[node] = 0;
            //Increment indegree by 1
            foreach (var node in graph.Keys)
            {
                foreach(var neighbor in graph[node])
                    inDegree[neighbor] = inDegree[neighbor] + 1;
            }

            //Step 2 - Add all nodes to queue with indegree 0
            Queue<int> queue = new Queue<int>();
            foreach(var node in inDegree.Keys)
            {
                if(inDegree[node] == 0)
                    queue.Enqueue(node);
            }

            //Step 3 - Run BFS algorithm
            var topoSort = new List<int>();
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                topoSort.Add(current);
                foreach(var neighbor in graph[current])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                        queue.Enqueue(neighbor);
                }
            }
            return topoSort;
        }
    }
}
