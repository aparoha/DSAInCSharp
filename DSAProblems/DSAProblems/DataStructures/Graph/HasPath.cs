using System;
using System.Collections.Generic;

namespace DSAProblems.DataStructures.Graph
{
    //1. has path using BFS
    //2. has path using DFS
    //3. print path using DFS
    //4. print path using BFS
    //5. All paths between source and destination using DFS
    //6. All paths between source and destination using BFS
    public class HasPath
    {
        //Approach 1 - Use DFS with backtracking
        public void PrintPathBetweenTwoNodes(Dictionary<int, List<int>> graph, int source, int destination)
        {
            HashSet<int> visited = new HashSet<int>();
            LinkedList<int> path = new LinkedList<int>();
            var isConnected = dfs(graph, source, destination, visited, path);
            if(isConnected)
                Console.WriteLine($"Path between {source} and {destination} is {string.Join(",", path)}");
            else
                Console.WriteLine($"No path exists between {source} and {destination}");
        }

        private bool dfs(Dictionary<int, List<int>> graph, int source, int destination, HashSet<int> visited,
            LinkedList<int> path)
        {
            visited.Add(source);
            path.AddLast(source);
            Console.WriteLine($"Starting DFS of {source} path {string.Join(",", path)}");
            if (source == destination)
                return true;
            foreach (var neighbor in graph[source])
            {
                if (!visited.Contains(neighbor))
                {
                    if(dfs(graph, neighbor, destination, visited, path))
                        return true;
                }
                    
            }
            //Backtrack : Once DFS is finished of current node and destination is not reachable then remove node from path 
            path.RemoveLast();
            Console.WriteLine($"Finishing DFS of {source} path {string.Join(",", path)}");
            return false;
        }

        //Approach 2 - Use DFS with parent map
        public void PrintPathBetweenTwoNodes2(Dictionary<int, List<int>> graph, int source, int destination)
        {
            HashSet<int> visited = new HashSet<int>();
            Dictionary<int, int> parentMap = new Dictionary<int, int>();
            parentMap[source] = -1;
            var isConnected = dfs(graph, source, destination, visited, parentMap);
            if (isConnected)
            {
                var currentNode = destination;
                Console.WriteLine(currentNode);
                while (currentNode != source)
                {
                    currentNode = parentMap[currentNode];
                    Console.WriteLine(currentNode);
                }
            }
            else
            {
                Console.WriteLine($"No path exists between {source} and {destination}");
            }
        }

        private bool dfs(Dictionary<int, List<int>> graph, int source, int destination, HashSet<int> visited,
            Dictionary<int, int> parentMap)
        {
            visited.Add(source);
            if (source == destination)
                return true;
            foreach (var neighbor in graph[source])
            {
                if (!visited.Contains(neighbor))
                {
                    parentMap[neighbor] = source;
                    if (dfs(graph, neighbor, destination, visited, parentMap))
                        return true;
                }

            }
            return false;
        }

        //Approach 3 - print path between 2 nodes using BFS
        public List<int> PrintPathTwoNodesBfs(Dictionary<int, List<int>> graph, int source, int destination)
        {
            //Create a queue which stores all paths
            Queue<LinkedList<int>> allPaths = new Queue<LinkedList<int>>();
            //Create a list to store current path
            LinkedList<int> currentPath = new LinkedList<int>();
            currentPath.AddLast(source);
            allPaths.Enqueue(currentPath);

            while (allPaths.Count > 0)
            {
                currentPath = allPaths.Dequeue();
                var lastNodeOfCurrentPath = currentPath.Last.Value;
                //If the last vertex of the current path is the destination then print the path
                if (lastNodeOfCurrentPath == destination)
                {
                    Console.WriteLine(string.Join("->", currentPath));
                    return new List<int>(currentPath);
                }

                //Traverse all nodes connected to last vertex of current path and push new path to the queue
                List<int> neighbors = graph[lastNodeOfCurrentPath];
                foreach (var neighbor in neighbors)
                {
                    //if the neighbor vertex is not visited in current path
                    if (currentPath.Contains(neighbor))
                    {
                        continue;
                    }
                    var newpath = new LinkedList<int>(currentPath);
                    newpath.AddLast(neighbor);
                    allPaths.Enqueue(newpath);
                }
            }
            return null;
        }

        //Approach 1 - DFS to print all paths between 2 nodes
        public void PrintAllPathsBetweenTwoNodes(Dictionary<int, List<int>> graph, int source, int destination)
        {
            HashSet<int> visited = new HashSet<int>();
            List<List<int>> allPaths = new List<List<int>>();
            dfs(graph, source, destination, visited, new LinkedList<int>(), allPaths);
            foreach(var path in allPaths)
                Console.WriteLine($"Path between ${source} and ${destination} is {string.Join(",", path)}");
        }

        private void dfs(Dictionary<int, List<int>> graph, int source, int destination, HashSet<int> visited,
            LinkedList<int> path, List<List<int>> allPaths)
        {
            visited.Add(source);
            path.AddLast(source);
            if (source == destination)
                allPaths.Add(new List<int>(path));
            foreach (var neighbor in graph[source])
            {
                if (!visited.Contains(neighbor))
                {
                    dfs(graph, neighbor, destination, visited, path, allPaths);
                }

            }
            //Remove the current node from path and mark it as undiscovered
            //Backtrack : Once DFS is finished of current node and destination is not reachable then remove node from path 
            path.RemoveLast();
            visited.Remove(source);
        }

        //Approach 2 - BFS to print all paths between 2 nodes
        private static void allPathsBfs(Dictionary<int, List<int>> graph, int source, int destination)
        {
            //Create a queue which stores all paths
            Queue<LinkedList<int>> allPaths = new Queue<LinkedList<int>>();
            //Create a list to store current path
            LinkedList<int> currentPath = new LinkedList<int>();
            currentPath.AddLast(source);
            allPaths.Enqueue(currentPath);

            while (allPaths.Count > 0)
            {
                currentPath = allPaths.Dequeue();
                var lastNodeOfCurrentPath = currentPath.Last.Value;
                //If the last vertex of the current path is the destination then print the path
                if (lastNodeOfCurrentPath == destination)
                {
                    Console.WriteLine(string.Join("->", currentPath));
                }

                //Traverse all nodes connected to last vertex of current path and push new path to the queue
                List<int> neighbors = graph[lastNodeOfCurrentPath];
                foreach (var neighbor in neighbors)
                {
                    //if the neighbor vertex is not visited in current path
                    if (currentPath.Contains(neighbor))
                    {
                        continue;
                    }
                    var newpath = new LinkedList<int>(currentPath);
                    newpath.AddLast(neighbor);
                    allPaths.Enqueue(newpath);
                }
            }
        }
    }
}
