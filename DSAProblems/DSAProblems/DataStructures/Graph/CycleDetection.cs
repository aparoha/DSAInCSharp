using System.Collections.Generic;

namespace DSAProblems.DataStructures.Graph
{
    class GraphNode
    {
        public int value { get;}
        public int parent { get;}
        public GraphNode(int value, int parent)
        {
            this.value = value;
            this.parent = parent;
        }
    }
    public class CycleDetection
    {
        //var cd = new CycleDetection();
        //Console.WriteLine(cd.IsCycleUndirectedBfs(new Dictionary<int, List<int>>{
        //        { 1, new List<int> {2}},
        //        { 2, new List<int> { 1, 4 } },
        //        { 3, new List<int> { 5 } },
        //        { 4, new List<int> { 2 } },
        //        { 5, new List<int> { 3, 10, 6 } },
        //        { 6, new List<int> { 5, 7 } },
        //        { 7, new List<int> { 6, 8 } },
        //        { 8, new List<int> { 7, 9, 11 } },
        //        { 9, new List<int> { 10, 8 } },
        //        { 10, new List<int> { 5, 9 } },
        //        { 11, new List<int> { 8 } }
        //        }));
        public bool IsCycleUndirectedBfs(Dictionary<int, List<int>> graph)
        {
            HashSet<int> visited = new HashSet<int>();
            foreach(int node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    if (CheckForCycleUndirectedBfs(graph, node, visited))
                        return true;
                }
            }
            return false;
        }
        private bool CheckForCycleUndirectedBfs(Dictionary<int, List<int>> graph, int source, HashSet<int> visited)
        {
            Queue<GraphNode> queue = new Queue<GraphNode>();
            queue.Enqueue(new GraphNode(source, -1));

            while(queue.Count > 0)
            {
                GraphNode current = queue.Dequeue();
                if (!visited.Contains(current.value))
                    visited.Add(current.value);
                foreach (int neighbor in graph[current.value])
                {
                    if(!visited.Contains(neighbor))
                        queue.Enqueue(new GraphNode(neighbor, current.value));
                    else if (neighbor != current.parent) //If neighbor is visited and its not parent
                        return true;
                }
            }
            return false;
        }
    }
}
