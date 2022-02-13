using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures.Heaps.Problems
{
    public class LC973_KClosestPoints
    {
        //O(klogn)
        public int[][] KClosestMinHeap(int[][] points, int k)
        {
            PriorityQueue<(int, int), int> minHeap = new PriorityQueue<(int, int), int>();
            foreach (int[] point in points)
            {
                int distance = point[0] * point[0] + point[1] * point[1];
                minHeap.Enqueue((point[0], point[1]), distance);
            }
            int[][] result = new int[k][];
            for (int i = 0; i < k; i++)
            {
                (int x, int y) = minHeap.Dequeue();
                result[i] = new int[2] { x, y };
            }
            return result;
        }

        //O(nlogk)
        public int[][] KClosestMaxHeap(int[][] points, int k)
        {
            PriorityQueue<(int, int), int> maxHeap = new PriorityQueue<(int, int), int>(Comparer<int>.Create((distance1, distance2) => distance2.CompareTo(distance1)));
            foreach (int[] point in points)
            {
                int distance = point[0] * point[0] + point[1] * point[1];
                if (maxHeap.Count < k)
                    maxHeap.Enqueue((point[0], point[1]), distance);
                else
                {
                    if (maxHeap.TryPeek(out (int, int) coordinates, out int peekDistance))
                    {
                        if (distance < peekDistance)
                        {
                            maxHeap.Dequeue();
                            maxHeap.Enqueue((point[0], point[1]), distance);
                        }
                    }
                }
            }
            int[][] result = new int[k][];
            for (int i = 0; i < k; i++)
            {
                (int x, int y) = maxHeap.Dequeue();
                result[i] = new int[2] { x, y };
            }
            return result;
        }
    }
}
