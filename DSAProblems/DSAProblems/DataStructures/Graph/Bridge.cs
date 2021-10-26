using System.Collections.Generic;

namespace DSAProblems.DataStructures.Graph
{
    //A bridge is an edge removing which increases the no. of components in the graph

    //Approach 1
    // Repeat below steps for each edge
    // 1. Remove the edge from the graph
    // 2. Perform DFS and see if there is only one connected component then removed edge is not a bridge
    //    else removed edge is bridge
    // 3. Put back edge into the graph
    // TC - O((V+E)*E)) - nof of edges * DFS TC

    //How to optimize it?
    //Condition for bridge
    //If low of adjacent > time of insertion of node
    public class Bridge
    {
        //Create 2 arrays or map to keep track of id / time and lowLink
        
        public List<List<int>> AllBridges(Dictionary<int, List<int>> graph)
        {
            int timer = 0;
            int N = graph.Keys.Count;
            int[] time = new int[N];
            int[] lowLink = new int[N];
            return null;
        }
    }
}
