using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Graphs
{
    //Linear ordering of vertices such that if there is an edge u -> v, it appears before v in topological ordering
    public class _07_Topological_Sort
    {
        public List<int> TopoSortDfs(int n, Dictionary<int, List<int>> graph)
        {
            bool[] visited = new bool[n];
            Stack<int> dfsStack = new Stack<int>(n);
            List<int> result = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    TopoSortDfs(i, graph, visited, dfsStack);
                }
            }
            while(dfsStack.Count > 0)
                result.Add(dfsStack.Pop());
            return result;
        }

        private void TopoSortDfs(int current, Dictionary<int, List<int>> graph, bool[] visited, Stack<int> dfsStack)
        {
            visited[current] = true;
            foreach(int neighbor in graph[current])
            {
                if(!visited[neighbor])
                    TopoSortDfs(neighbor, graph, visited, dfsStack);
            }
            dfsStack.Push(current);
        }

        //Kahn's Algorithm
        /*
         1. Calculate in degree of each vertex 
         2. Create a queue
         3. Enqueue all nodes to queue with indegree 0
         4. Iterate queue until it gets empty
                Dequeue node
                Iterate its neighbors
                Reduce in degree of neighbor
                If indegree becomes 0, then enqueue to queue
         * 
        */
        public List<int> TopoSortBfs(int n, Dictionary<int, List<int>> graph)
        {
            List<int> result = new List<int>();
            int[] inDegrees = new int[n];
            for(int i = 0; i < n; i++)
            {
                foreach(int node in graph[i])
                    inDegrees[node]++;
            }
            Queue<int> queue = new Queue<int>();
            for(int i = 0; i < n; i++)
            {
                if(inDegrees[i] == 0)
                    queue.Enqueue(i);
            }
            while(queue.Count > 0)
            {
                int current = queue.Dequeue();
                result.Add(current);
                foreach(int neighbor in graph[current])
                {
                    inDegrees[neighbor]--;
                    if(inDegrees[neighbor] == 0)
                        queue.Enqueue(neighbor);
                }
            }
            return result;
        }
    }
}
