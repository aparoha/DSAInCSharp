using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures.Graph
{
    public class DfsTree
    {
        //Print arrival and departure time of nodes
        //Passing time as ref keyword
        public void DfsNodeTimes(Dictionary<int, List<int>> graph)
        {
            int N = graph.Keys.Count;
            int[] arrival = new int[N];
            int[] departure = new int[N];
            HashSet<int> visited = new HashSet<int>();
            int time = -1;
            foreach(int node in graph.Keys)
            {
                if(!visited.Contains(node))
                    dfsNodeTimesUtil(node, graph, visited, arrival, departure, ref time);
            }
            foreach(int node in graph.Keys)
            {
                Console.WriteLine($"node {node} arrival time {arrival[node]} departure time {departure[node]}");
            }
        }

        private void dfsNodeTimesUtil(int source, Dictionary<int, List<int>> graph, HashSet<int> visited, int[] arrival, 
            int[] departure, ref int time)
        {
            visited.Add(source);
            arrival[source] = ++time;
            foreach(var neighbor in graph[source])
            {
                if(!visited.Contains(neighbor))
                    dfsNodeTimesUtil(neighbor, graph, visited, arrival, departure, ref time);
            }
            departure[source] = ++time;
        }

        public void DfsEdgesUndirectedGraph(Dictionary<int, List<int>> graph)
        {
            int N = graph.Keys.Count;
            int[] arrival = new int[N];
            int[] departure = new int[N];
            HashSet<int> visited = new HashSet<int>();
            int time = -1;
            foreach (int node in graph.Keys)
            {
                if (!visited.Contains(node))
                    DfsEdgesUndirectedGraphUtil(node, graph, visited, arrival, departure, ref time);
            }
        }

        private void DfsEdgesUndirectedGraphUtil(int source, Dictionary<int, List<int>> graph, HashSet<int> visited, int[] arrival,
            int[] departure, ref int time)
        {
            visited.Add(source);
            arrival[source] = ++time;
            foreach (var neighbor in graph[source])
            {
                if (!visited.Contains(neighbor))
                {
                    //Tree Edge
                    Console.WriteLine($"Tree Edge : {source} -> {neighbor}");
                    DfsEdgesUndirectedGraphUtil(neighbor, graph, visited, arrival, departure, ref time);
                } 
                else
                {
                    //Back Edge
                    if(arrival[source] > arrival[neighbor] && departure[source] < departure[neighbor])
                        Console.WriteLine($"Back Edge : {source} -> {neighbor}");
                    //Forward Edge
                    else if (arrival[source] < arrival[neighbor] && departure[source] > departure[neighbor])
                        Console.WriteLine($"Forward Edge : {source} -> {neighbor}");
                    //Cross Edge
                    else if (arrival[source] > arrival[neighbor] && departure[source] > departure[neighbor])
                        Console.WriteLine($"Cross Edge : {source} -> {neighbor}");
                }
            }
            departure[source] = ++time;
        }

    }
}
