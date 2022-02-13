using DSAProblems.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Graphs
{
    public class _15_Kruskal_MST
    {
        public MST KruskalMST(Dictionary<int, List<(int, int)>> graph, int n)
        {
            //Step 1 - Create edges list
            List<Edge> edges = new List<Edge>();
            MST mst = new MST() { Edges = new List<Edge>()};
            DisjointSet<int> disjointSet = new DisjointSet<int>();
            for(int i = 0; i < n; i++)
            {
                disjointSet.MakeSet(i);
                foreach(var neighbor in graph[i])
                    edges.Add(new Edge() { Source = i, Destination = neighbor.Item1, Weight = neighbor.Item2});
            }

            //Step 2 - Sort edge list by weight
            edges.Sort((edge1, edge2) => edge1.Weight.CompareTo(edge2.Weight));

            //Start iterating by shortest weight edge and check if nodes belong to same component
            foreach(Edge edge in edges)
            {
                if(disjointSet.FindSet(edge.Source) != disjointSet.FindSet(edge.Destination))
                {
                    mst.Weight += edge.Weight;
                    mst.Edges.Add(edge);
                    disjointSet.Union(edge.Source, edge.Destination);
                }
            }
            return mst;
        }
    }
}
