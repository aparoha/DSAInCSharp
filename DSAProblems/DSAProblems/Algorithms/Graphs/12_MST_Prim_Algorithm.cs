using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.Algorithms.Graphs
{
    //Convert a graph to a tree such that it has n nodes and n-1 edges
    //Every node should be reachable from every other node
    //There could be multiple spanning trees of any graph
    //When the sum of weights of spanning tree is minimum, then that spanning tree is called MST
    //No cycles

    //_12_MST_Prim_Algorithm sp = new _12_MST_Prim_Algorithm();
    //var mst = sp.PrimsMST(
    //    new Dictionary<int, List<(int, int)>>()
    //    {
    //                    {0 , new List<(int, int)> {(1, 2), (3, 6)} },
    //                    {1 , new List<(int, int)> {(0, 2), (2, 3), (3, 8), (4, 5) } },
    //                    {2 , new List<(int, int)> {(1, 3), (4, 7)} },
    //                    {3 , new List<(int, int)> {(0, 6), (1, 8), (4, 9) } },
    //                    {4 , new List<(int, int)> {(1, 5), (2, 7), (3, 9) } }
    //    }, 5
    //    );
    //Console.WriteLine($"Edges {string.Join(",", mst.Edges.Select(x => x.Item1 + "-" + x.Item2))} Total weight {mst.Weight}");
    public class _12_MST_Prim_Algorithm
    {
        public MST PrimsMST(Dictionary<int, List<(int, int)>> graph, int n)
        {
            int[] key = new int[n];
            int[] parent = new int[n];
            bool[] mstSet = new bool[n];

            for(int i = 0; i < n; i++)
                key[i] = int.MaxValue;

            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
            key[0] = 0;
            parent[0] = -1;
            priorityQueue.Enqueue(0, key[0]);

            while(priorityQueue.Count > 0)
            {
                int current = priorityQueue.Dequeue();
                mstSet[current] = true;
                foreach(var neighbor in graph[current])
                {
                    (int neighborVertex, int neighborWeight) = neighbor;
                    if(mstSet[neighborVertex] == false && key[neighborVertex] > neighborWeight)
                    {
                        parent[neighborVertex] = current;
                        key[neighborVertex] = neighborWeight;
                        priorityQueue.Enqueue(neighborVertex, key[neighborVertex]);
                    }
                }
            }

            MST mst = new MST { Edges = new List<Edge>() };
            //Iterating from 1st index as 0th index has entry from -1 -> 0
            for (int i = 1; i < n; i++)
            {
                mst.Weight += key[i];
                mst.Edges.Add(new Edge() { Source = parent[i], Destination = i, Weight = key[i] });
            }

            return mst;
        }

    }

    public class MST
    {
        public List<Edge> Edges;
        public int Weight;
    }

    public class Edge
    {
        public int Source, Destination, Weight;
    }
}
