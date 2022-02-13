using System.Collections.Generic;

namespace DSAProblems.Algorithms.Graphs
{
    public class _11_Dijkstra_Algorithm
    {
        //TC - O((N + E) logN) = NlogN
        //SC = O(N)

        /*
                Console.WriteLine(
    string.Join(",", sp.SingleSourceShortestPathNonNegativeWeights(
        new Dictionary<int, List<(int, int)>>()
        {
                        {0 , new List<(int, int)> {(1, 10), (4, 3)} },
                        {1 , new List<(int, int)> {(2, 2), (4, 4)} },
                        {2 , new List<(int, int)> {(3, 9)} },
                        {3 , new List<(int, int)> {(2, 7)} },
                        {4 , new List<(int, int)> {(1, 1), (2, 8), (3, 2) } }
        }, 5, i
        ))
        */
        public int[] SingleSourceShortestPathNonNegativeWeights(Dictionary<int, List<(int, int)>> graph, int n, int source)
        {
            int[] distance = new int[n];
            for(int i = 0; i < n; i++)
                distance[i] = int.MaxValue;
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
            distance[source] = 0;
            priorityQueue.Enqueue(source, 0);
            while(priorityQueue.Count > 0)
            {
                int current = priorityQueue.Dequeue();
                foreach((int, int) neighbor in graph[current])
                {
                    (int neighborVertex, int neighborWeight) = neighbor;
                    if(distance[neighborVertex] > distance[current] + neighborWeight)
                    {
                        distance[neighborVertex] = distance[current] + neighborWeight;
                        priorityQueue.Enqueue(neighborVertex, distance[neighborVertex]);
                    }
                }
            }
            return distance;
        }
    }
}
