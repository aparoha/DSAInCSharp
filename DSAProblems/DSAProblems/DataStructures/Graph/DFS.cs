using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures.Graph
{
    public static class Color
    {
        public const int WHITE = 0; //UNDISCOVERED
        public const int GRAY = 1; //DISCOVERED but not finished processing
        public const int BLACK = 2; //FINISHED processing
    }
    class DFS
    {
        //Graph is G = (V,E). he algorithm works in discrete time steps. Each vertex v is given a "discovery" time discovery[v]
        //when its first processed and a "finish" time, finish[v] when all of its descendents are finished

        //The output is a collection of trees. As well as discovery[v] and finish[v], each node points to parent[v], its parent
        //in the forest

        //1. DFS constructs a forest (a collection of rooted trees) together with set of source vertices (roots)
        //2. Output 2 arrays, discovery[v] / finish[v], the two time units
        //3. Forest is stored in parent[] array with parent[v] pointing to parent of v in the forest
        //4. parent[] of a root node is NULL

        //Idea of DFS
        //1. In DFS, edges are explored out of the most recently discovered vertex v
        //2. When all of v’s edges have been explored, the search “backtracks” to explore edges leaving the vertex from which v
        //   was discovered
        //3. The process continues until we have discovered all the vertices that are reachable from the original source vertex.
        //4. If any undiscovered vertices remain, then one of them is selected as a new source vertex, and the search is repeated
        //   from that source vertex
        //5. This process is repeated until all vertices are discovered.


        //Articulation Point
        //Three observations
        //      a. The root of the DFS tree is an articulation if it has two or more children.
        //      b. A leaf of a DFS tree is not an articulation point
        //      c. Any other internal vertex v in the DFS tree, if it has one or more subtrees rooted at a child of v
        //         that does NOT have an edge which climbs higher than v, then v is an articulation point

        //How to climb up?
        //1. Observe that for an undirected graph, the DFS tree can only has tree edges or back edges.
        //2. A subtree can only climb to the upper part of the tree by a back edge
        //3. A vertex can only climb up to its ancestor.

        public void PrintDfs(Dictionary<int, List<int>> graph)
        {
            int time = 0;
            int N = graph.Keys.Count;
            int[] color = new int[N+1];
            int[] disovery = new int[N+1];
            int[] finish = new int[N+1];
            int[] parent = new int[N+1];
            foreach (var u in graph.Keys)
            {
                if(color[u] == Color.WHITE)
                    dfs(graph, u, color, disovery, finish, parent, ref time);
            }
            for(int i = 1; i <= N; i++)
            {
                Console.WriteLine($"Node {i} : Parent {parent[i]} Discovery time {disovery[i]} Finish time {finish[i]}");
            }
        }

        private void dfs(Dictionary<int, List<int>> graph, int u, int[] color, int[] disovery, int[] finish, int[] parent, 
            ref int time)
        {
            color[u] = Color.GRAY;
            Console.WriteLine(u);
            disovery[u] = ++time;
            foreach(int v in graph[u])
            {
                if(color[v] == Color.WHITE)
                {
                    parent[v] = u;
                    dfs(graph, v, color, disovery, finish, parent, ref time);
                }
            }
            color[u] = Color.BLACK;
            finish[u] = ++time;
        }
    }
}
