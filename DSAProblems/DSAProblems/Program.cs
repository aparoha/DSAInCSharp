using System;
using System.Collections.Generic;
using DSAProblems.DataStructures.Graph;
using DSAProblems.LeetCode.BFS;

namespace DSAProblems
{
    public class GrpahNode
    {
        public char value { get; set;}
        public int distance {  get; set;}
        public GrpahNode parent {  get; set;}
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class SNode
    {
        public TreeNode current;
        public TreeNode parent;
        public char dir;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var edges = new int[][]
            //            {
            //  new int[] { 1, 3},
            //  new int[] { 1, 2},
            //  new int[] { 3, 4},
            //  new int[] { 5, 6},
            //  new int[] { 6, 3},
            //  new int[] { 3, 8},
            //  new int[] { 8, 11},
            //            };
            //Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            //for (int i = 0; i < edges.Length; i++)
            //{
            //    if (!graph.ContainsKey(edges[i][0]))
            //    {
            //        graph[edges[i][0]] = new List<int>();
            //    }
            //    graph[edges[i][0]].Add(edges[i][1]);
            //    if (!graph.ContainsKey(edges[i][1]))
            //    {
            //        graph[edges[i][1]] = new List<int>();
            //    }
            //}
            //var result = topologicalSort(graph);

            //var graph = new Dictionary<char, List<char>>
            //{
            //    { '0', new List<char> { '1', '2'} },
            //    { '1', new List<char> { '3' } },
            //    { '2', new List<char> { '1', '6'} },
            //    { '3', new List<char> { '2', '4'} },
            //    { '4', new List<char> { '5'} },
            //    { '5', new List<char> { '7' } },
            //    { '6', new List<char> { '4' } },
            //    { '7', new List<char> { '6' } }
            //};
            //allPathsBfs(graph, '0', '6');

            var hp = new HasPath();
            hp.PrintPathTwoNodesBfs(new Dictionary<int, List<int>>
        {
            {0, new List<int> {3} },
            {1, new List<int> {0, 2, 4} },
            {2, new List<int> {7} },
            {3, new List<int> {4, 5} },
            {4, new List<int> {3, 6} },
            {5, new List<int> {6} },
            {6, new List<int> {7} },
            {7, new List<int>() }
        }, 0, 7);
        }

        private static bool isCycleDfsDG(Dictionary<int, List<int>> graph)
        {
            HashSet<int> whiteSet = new HashSet<int>();
            HashSet<int> graySet = new HashSet<int>();
            HashSet<int> blackSet = new HashSet<int>();

            //Add all vertices to white set
            foreach(var node in graph.Keys)
                whiteSet.Add(node);

            while(whiteSet.Count > 0)
            {
                var enumerator = whiteSet.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (dfs(enumerator.Current, whiteSet, graySet, blackSet, graph))
                        return true;
                }
            }

            return false;
        }

        private static bool dfs(int current, HashSet<int> whiteSet, HashSet<int> graySet, HashSet<int> blackSet, Dictionary<int, List<int>> graph)
        {
            //Move node from white set to gray set and then explore it
            moveVertex(current, whiteSet, graySet);
            foreach(var neighbor in graph[current])
            {
                //if in black set means already explored, so continue
                if (blackSet.Contains(neighbor))
                {
                    continue;
                }
                //if in gray set means cycle found
                if (graySet.Contains(neighbor))
                    return true;
                if (dfs(neighbor, whiteSet, graySet, blackSet, graph))
                    return true;
            }
            //Move node from grey set to black set when vertex and its children are visited
            moveVertex(current, graySet, blackSet);
            return false;
        }

        private static void moveVertex(int vertex, HashSet<int> source, HashSet<int> destination)
        {
            source.Remove(vertex);
            destination.Add(vertex);
        }

        private static bool isCycleDfsUG(Dictionary<int, List<int>> graph)
        {
            HashSet<int> visited = new HashSet<int>();
            LinkedList<int> cyclePath = new LinkedList<int>();
            foreach(int node in graph.Keys)
            {
                if(!visited.Contains(node))
                    if(isCycleDfsUGUtil(node, -1, visited, graph, cyclePath))
                    {
                        var lastNode = cyclePath.Last;
                        while(lastNode.Previous != null && lastNode.Previous.Value != lastNode.Value)
                        {
                            Console.Write(lastNode.Value + " ");
                            lastNode = lastNode.Previous;
                        }
                        return true;
                    }
            }
            return false;
        } 

        private static bool isCycleDfsUGUtil(int node, int parent, HashSet<int> visited, Dictionary<int, List<int>> graph,
            LinkedList<int> cyclePath)
        {
            visited.Add(node);
            cyclePath.AddLast(node);
            foreach(int neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    if(isCycleDfsUGUtil(neighbor, node, visited, graph, cyclePath) == true)
                    {
                        return true;
                    }
                } else if (neighbor != parent)
                {
                    cyclePath.AddLast(neighbor);
                    return true;
                }
            }
            cyclePath.RemoveLast();
            return false;
        }

        private static void iterativeDfsAllVertex(Dictionary<int, List<int>> graph)
        {
            HashSet<int> visited = new HashSet<int>();
            foreach(int node in graph.Keys)
            {
                if(!visited.Contains(node))
                    DfsUtil(graph, node, visited);
            }
        }

        private static void iterativeDfsFromSource(Dictionary<int, List<int>> graph, int source)
        {
            HashSet<int> visited = new HashSet<int>();
            Stack<int> stack = new Stack<int>();
            stack.Push(source);
            while(stack.Count > 0)
            {
                //Pop a vertex from stack
                int current = stack.Pop();
                //Stack may contain same vertex twice, print popped item only if it is not visited
                if (!visited.Contains(current))
                {
                    Console.WriteLine(current + " "); //Visit the node
                    visited.Add(current); // Mark it as visited
                }
                //Get neighbors of current vertex and push it to stack if not visited yet
                foreach(int neighbor in graph[current])
                {
                    if(!visited.Contains(neighbor))
                        stack.Push(neighbor);
                }
            }
        }

        //https://iq.opengenus.org/print-all-the-paths-between-two-vertices/

        private static List<List<char>> printAllPaths(Dictionary<char, List<char>> graph, char source, char destination)
        {
            var allPaths = new List<List<char>>();
            var currentPath = new List<char>();
            var visited = new HashSet<char>();
            currentPath.Add(source);
            dfs(graph, source, destination, allPaths, currentPath, visited);
            return allPaths;
        }

        private static void dfs(Dictionary<char, List<char>> graph, char source, char destination,
            List<List<char>> allPaths, List<char> currentPath, HashSet<char> visited)
        {
            visited.Add(source);
            if(source == destination)
            {
                allPaths.Add(new List<char>(currentPath));
                Console.WriteLine(string.Join("->", currentPath));
            }
            foreach(var neighbor in graph[source])
            {
                if (!visited.Contains(neighbor))
                {
                    currentPath.Add(neighbor);
                    dfs(graph, neighbor, destination, allPaths, currentPath, visited);
                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
            visited.Remove(source);
        }

        private static void allPathsBfs(Dictionary<char, List<char>> graph, char source, char destination)
        { 
            //Create a queue which stores all paths
            Queue<LinkedList<char>> allPaths = new Queue<LinkedList<char>>();
            //Create a list to store current path
            LinkedList<char> currentPath = new LinkedList<char>();
            currentPath.AddLast(source);
            allPaths.Enqueue(currentPath);

            while(allPaths.Count > 0)
            {
                currentPath = allPaths.Dequeue();
                var lastNodeOfCurrentPath = currentPath.Last.Value;
                //If the last vertex of the current path is the destination then print the path
                if(lastNodeOfCurrentPath == destination)
                {
                    Console.WriteLine(string.Join("->", currentPath));
                }

                //Traverse all nodes connected to last vertex of current path and push new path to the queue
                List<char> neighbors = graph[lastNodeOfCurrentPath];
                foreach(var neighbor in neighbors)
                {
                    //if the neighbor vertex is not visited in current path
                    if (currentPath.Contains(neighbor))
                    {
                        continue;
                    }
                    var newpath = new LinkedList<char>(currentPath);
                    newpath.AddLast(neighbor);
                    allPaths.Enqueue(newpath);
                }
            }
        }


        private static void bfs(Dictionary<int, List<int>> graph, int source)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);
            while(queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (!visited.Contains(current))
                {
                    Console.Write(current + "->"); //visit the vertex
                    visited.Add(current);
                }
                foreach(int v in graph[current]) {
                    if(!visited.Contains(v))
                        queue.Enqueue(v);
                }
            }
        }

        private static void shortestDistanceFromSourceToAllUsingBfs(Dictionary<int, List<int>> graph, int source)
        {
            var nodes = graph.Keys.Count;
            HashSet<int> visited = new HashSet<int>();
            //List to keep shortest distance from source to each vertex
            int[] distance = new int[nodes];
            //Parent list
            int[] parents = new int[nodes];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);
            distance[source] = 0;
            parents[source] = -1;

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                if(!visited.Contains(current))
                    visited.Add(current);
                foreach(var neighbor in graph[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        distance[neighbor] = distance[current] + 1;
                        parents[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            //Shortest distance of all nodes from source
            for(int i = 0; i < nodes; i++)
            {
                Console.WriteLine(distance[i] + " ");
            }
            //Print all paths
            int destination = 4;
            if (!visited.Contains(destination))
            {
                Console.Write("No path");
            } 
            else
            {
                var path = new List<int>();
                int x = destination;
                while(x != -1)
                {
                    path.Add(x);
                    x = parents[x];
                }
                path.Reverse();
                Console.WriteLine("Path is " + string.Join(",", path));
            }
        }

        private void dfsFromAllVertex(Dictionary<int, List<int>> graph)
        {
            HashSet<int> visited = new HashSet<int>();
            foreach(var node in graph.Keys)
            {
                if(!visited.Contains(node))
                    dfsUtilRecursiveFromGivenVertex(graph, node, visited);
            }
        }

        private void dfsUtilRecursiveFromGivenVertex(Dictionary<int, List<int>> graph, int source, HashSet<int> visited)
        {
            visited.Add(source);
            Console.WriteLine(source + " ");
            foreach (int neighbor in graph[source])
            {
                if (!visited.Contains(neighbor))
                    dfsUtilRecursiveFromGivenVertex(graph, neighbor, visited);
            }
        }

        private static void iterativeDfsFromOneNode(Dictionary<int, List<int>> graph, int source)
        {
            //Create a hashset to mark node as visited
            HashSet<int> visited = new HashSet<int>();
            //Create a stack to run DFS
            Stack<int> stack = new Stack<int>();
            //Push current source node
            stack.Push(source);

            while(stack.Count > 0)
            {
                int current = stack.Pop();
                if (!visited.Contains(current))
                {
                    Console.WriteLine(current + " ");
                    visited.Add(current);
                }
                foreach(int v in graph[current])
                {
                    if(!visited.Contains(v))
                        stack.Push(v);
                }
            }

        }

        private static void iterativeDfsAllNodes(Dictionary<int, List<int>> graph)
        {
            //Create a hashset to mark node as visited
            HashSet<int> visited = new HashSet<int>();
            foreach(int v in graph.Keys)
            {
                if (!visited.Contains(v))
                    DfsUtil(graph, v, visited);
            }
        }

        private static void DfsUtil(Dictionary<int, List<int>> graph, int source, HashSet<int> visited)
        {
            //Create a stack to run DFS
            Stack<int> stack = new Stack<int>();
            //Push current source node
            stack.Push(source);

            while (stack.Count > 0)
            {
                int current = stack.Pop();
                if (!visited.Contains(current))
                {
                    Console.WriteLine(current + " ");
                    visited.Add(current);
                }
                foreach (int v in graph[current])
                {
                    if (!visited.Contains(v))
                        stack.Push(v);
                }
            }

        }

        //1. DFS using stack
        // Always print / visit after poppint the node
        //a,c,e,b,d,f
        private static void depthFirstPrintIterative(Dictionary<char, List<char>> graph, char source)
        {
            Stack<char> stack = new Stack<char>();
            stack.Push(source);
            while(stack.Count > 0)
            {
                var current = stack.Pop();
                Console.WriteLine(current);
                foreach(var neighbor in graph[current])
                    stack.Push(neighbor);
            }
        }

        //2. DFS using recursion
        //a,b,d,f,c,e
        private static void depthFirstPrintRecursion(Dictionary<char, List<char>> graph, char source)
        {
            Console.WriteLine(source);
            foreach(var neighbor in graph[source])
                depthFirstPrintRecursion(graph, neighbor);
        }

        //3. BFS
        //a,b,c,d,e,f
        private static void breadthFirstPrint(Dictionary<char, List<char>> graph, char source)
        {
            var queue = new Queue<char>();
            queue.Enqueue(source);
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current);
                foreach(var neighbor in graph[current])
                    queue.Enqueue(neighbor);
            }
        }

        private static bool hasPathInDAGDfs(Dictionary<char, List<char>> graph, char source, char destination)
        {
            if(source == destination) return true;
            foreach(var neighbor in graph[source])
            {
                if(hasPathInDAGDfs(graph, neighbor, destination))
                    return true;
            }
            return false;
        }

        private static bool hasPathInDAGBfs(Dictionary<char, List<char>> graph, char source, char destination)
        {
            var queue = new Queue<char>();
            queue.Enqueue(source);
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                if(current == destination) return true;
                foreach(var neighbor in graph[current])
                    queue.Enqueue(neighbor);
            }
            return false;
        }

        private static bool hasPathUndirectedGraph(char[][] edges, char source, char destination)
        {
            /*edges: [
             *  [i, j],
             *  [k, i],
             *  [m, k],
             *  [k, l],
             *  [o, n]
             * ] 
             */
            //Create adjacency list from edge list
            //If graph is undirected graph then each entry in edges we can move from i -> j or j -> i
            //While converting to adjacency list, we need to add both edges
            //Always keep in mind, need to handle cycle for undirected graphs
            var graph = new Dictionary<char, List<char>>();
            //Create adjacency list
            foreach (char[] v in edges)
            {
                if (!graph.ContainsKey(v[0])) graph[v[0]] = new List<char>();
                if (!graph.ContainsKey(v[1])) graph[v[1]] = new List<char>();
                graph[v[0]].Add(v[1]);
                graph[v[1]].Add(v[0]);
            }
            return hasPathUndirectedGraphInternal(graph, source, destination, new HashSet<char>());
        }

        private static bool hasPathUndirectedGraphInternal(Dictionary<char, List<char>> graph, char source, char destination, HashSet<char> visited)
        {
            if(source == destination) return true;
            if (visited.Contains(source)) return true;
            visited.Add(source);
            foreach (var neighbor in graph[source])
            {
                if(hasPathUndirectedGraphInternal(graph, neighbor, destination, visited))
                    return true;
            }
            return false;
        }



        private static List<int> topologicalSort(Dictionary<int, List<int>> graph)
        {
            var result = new List<int>();
            Stack<int> stack = new Stack<int>();
            HashSet<int> visited = new HashSet<int>();
            foreach(var node in graph.Keys)
            {
                if(visited.Contains(node))
                    continue;
                topologicalSortInternal(graph, node, visited, stack);
            }
            while(stack.Count > 0)
                result.Add(stack.Pop());

            return result;
        }

        private static void topologicalSortInternal(Dictionary<int, List<int>> graph, int node, HashSet<int> visited, Stack<int> stack)
        {
            visited.Add(node);
            foreach(var neighbour in graph[node])
            {
                if(visited.Contains(neighbour))
                    continue;
                topologicalSortInternal(graph, neighbour, visited, stack);
            }
            stack.Push(node);
        }

        private List<List<int>> createAdjacencyList(int noOfNodes, int[][] edges)
        {
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < noOfNodes; i++)
            {
                graph.Add(new List<int>());
            }
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            return graph;
        }

        private Dictionary<int, List<int>> createAdjacencyList2(int noOfNodes, int[][] edges)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < edges.Length; i++)
            {
                if (!graph.ContainsKey(edges[i][0]))
                {
                    graph[edges[i][0]] = new List<int>();
                }
                graph[edges[i][0]].Add(edges[i][1]);
                if (!graph.ContainsKey(edges[i][1]))
                {
                    graph[edges[i][1]] = new List<int>();
                }
                graph[edges[i][1]].Add(edges[i][0]);
            }
            return graph;
        }

        private List<int>[] createAdjacencyList3(int noOfNodes, int[][] edges)
        {
            var graph = new List<int>[noOfNodes];

            // Initialize graph
            for (int i = 0; i < noOfNodes; i++)
            {
                graph[i] = new List<int>();
            }

            // build graph
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            return graph;
        }


        //Print all paths of n-ary tree
        public static List<List<int>> getPermutations(int[] input)
        {
            List<List<int>> result = new List<List<int>>();
            LinkedList<int> ans = new LinkedList<int>();
            permute(input, result, ans);
            return result;
        }

        static void permute(int[] input, List<List<int>> result, LinkedList<int> ans)
        {
            Console.WriteLine($"Answer step -> result {string.Join(',', ans)}");
            if(ans.Count == input.Length)
            {
                result.Add(new List<int>(ans));
                return;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (ans.Contains(input[i]))
                    continue;
                ans.AddFirst(input[i]);
                permute(input, result, ans);
                ans.RemoveLast();
            }
        }

        //preorder traversal of n-ary tree
        public static List<List<int>> getSubsets(int[] input)
        {
            List<List<int>> powerSet = new List<List<int>>();
            List<int> subset = new List<int>();
            backtrack(input, powerSet, subset, 0);
            return powerSet;
        }

        static void backtrack(int[] input, List<List<int>> powerSet, List<int> subset, int start)
        {
            Console.WriteLine($"Answer step -> subset {string.Join(',', subset)}");
            powerSet.Add(new List<int>(subset));
            for(int i = start; i < input.Length; i++)
            {
                subset.Add(input[i]);
                backtrack(input, powerSet, subset, i + 1);
                Console.WriteLine($"After backtrack -> start {start} subset {string.Join(',', subset)}");
                subset.RemoveAt(subset.Count - 1);
            }
        }
    }

}
