using System.Collections.Generic;

namespace DSAProblems.Algorithms.Graphs
{
    // Works on weighted DAG, negative edge weights allowed, no cycle reachable from start vertex
    public class _09_Shortest_Path_DAG
    {
            /*
                 _09_Shortest_Path_DAG sp = new _09_Shortest_Path_DAG();
        Console.WriteLine(
            string.Join(",", sp.LongestPathDAG(
                new Dictionary<int, List<(int, int)>>()
                {
                    {0 , new List<(int, int)> {(1, 5), (2, 3)} },
                    {1 , new List<(int, int)> {(3, 6), (2, 2)} },
                    {2 , new List<(int, int)> {(4, 4), (5, 2), (3, 7)} },
                    {3 , new List<(int, int)> {(5, 1), (4, -1)} },
                    {4 , new List<(int, int)> {(5, -2) } },
                    {5 , new List<(int, int)>() }
                }, 6, 1
                ))
            ); 
    Following are longest distances from source vertex 1
    INF 0 2 6 5 3
    */
        public int[] ShortestPathDAG(Dictionary<int, List<(int, int)>> graph, int n, int source)
        {
            int[] distance = new int[n];
            Stack<int> topoSort = TopoSortDfs(n, graph);
            for (int i = 0; i < n; i++)
                distance[i] = int.MaxValue;
            distance[source] = 0;
            while(topoSort.Count > 0)
            {
                int current = topoSort.Pop();
                if(distance[current] != int.MaxValue)
                {
                    foreach(var neighbor in graph[current])
                    {
                        (int vertex, int weight) = neighbor;
                        if (distance[vertex] > distance[current] + weight)
                            distance[vertex] = distance[current] + weight;
                    }
                }
            }
            return distance;
        }

        /*
                     _09_Shortest_Path_DAG sp = new _09_Shortest_Path_DAG();
            Console.WriteLine(
                string.Join(",", sp.LongestPathDAG(
                    new Dictionary<int, List<(int, int)>>()
                    {
                        {0 , new List<(int, int)> {(1, 5), (2, 3)} },
                        {1 , new List<(int, int)> {(3, 6), (2, 2)} },
                        {2 , new List<(int, int)> {(4, 4), (5, 2), (3, 7)} },
                        {3 , new List<(int, int)> {(5, 1), (4, -1)} },
                        {4 , new List<(int, int)> {(5, -2) } },
                        {5 , new List<(int, int)>() }
                    }, 6, 1
                    ))
                ); 
        Following are longest distances from source vertex 1
        INF 0 2 9 8 10
        */
        public int[] LongestPathDAG(Dictionary<int, List<(int, int)>> graph, int n, int source)
        {
            int[] distance = new int[n];
            Stack<int> topoSort = TopoSortDfs(n, graph);
            for (int i = 0; i < n; i++)
                distance[i] = int.MinValue;
            distance[source] = 0;
            while (topoSort.Count > 0)
            {
                int current = topoSort.Pop();
                if (distance[current] != int.MinValue)
                {
                    foreach ((int, int) neighbor in graph[current])
                    {
                        (int vertex, int weight) = neighbor;
                        if (distance[vertex] < distance[current] + weight)
                            distance[vertex] = distance[current] + weight;
                    }
                }
            }
            return distance;
        }

        public Stack<int> TopoSortDfs(int n, Dictionary<int, List<(int, int)>> graph)
        {
            bool[] visited = new bool[n];
            Stack<int> dfsStack = new Stack<int>(n);
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    TopoSortDfs(i, graph, visited, dfsStack);
                }
            }
            return dfsStack;
        }

        private void TopoSortDfs(int current, Dictionary<int, List<(int, int)>> graph, bool[] visited, Stack<int> dfsStack)
        {
            visited[current] = true;
            foreach ((int, int) neighbor in graph[current])
            {
                if (!visited[neighbor.Item1])
                    TopoSortDfs(neighbor.Item1, graph, visited, dfsStack);
            }
            dfsStack.Push(current);
        }

    }
}
