using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures.PriorityQueue
{



//    { symbol: "amzn", currentPrice: 3000.15, timeStamp: 1638253787, priceChange: -25.91 }
//For one stock symbol, there can be multiple entries in the input. priceChange reflects the change compared to the previous day. timeStamp is in epoch format.
//Find:
//Get the current price for a given symbol
//top 10 winners
//top 10 losers

    /*
     * 1. Implements an array-backed, quaternary min-heap. 
     * 2. Each element is enqueued with an associated priority that determines the dequeue order. 
     * 3. Elements with the lowest priority are dequeued first. 
     * 4. Note that the type does not guarantee first-in-first-out semantics for elements of equal priority.
     * 
     */
    public class PriorityQueueProblems
    {
        string result = string.Empty;
        public void RunUsage()
        {
            //Create empty min heap
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            //Create empty max heap
            PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            //Construct heap with initial elements
            PriorityQueue<int, int> heapWithValues = new PriorityQueue<int, int>(new List<(int, int)>
            {
                (1, 1), (2, 2), (3,3)
            });

            Console.WriteLine("******Default behavior********");
            PriorityQueue<string, int> queue = new PriorityQueue<string, int>();
            queue.Enqueue("Item A", 0);
            queue.Enqueue("Item B", 60);
            queue.Enqueue("Item C", 2);
            queue.Enqueue("Item D", 1);

            while (queue.TryDequeue(out string item, out int priority))
            {
                Console.WriteLine($"Popped Item : {item}. Priority Was : {priority}");
            }

            Console.WriteLine("******Reverse order - Using Comparer.Create********");
            //Comparer<int>.Create((a, b) => b.CompareTo(a))
            //Comparer<int>.Create((a, b) => b - a)
            queue = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            queue.Enqueue("Item A", 0);
            queue.Enqueue("Item B", 60);
            queue.Enqueue("Item C", 2);
            queue.Enqueue("Item D", 1);
            while (queue.TryDequeue(out string item, out int priority))
            {
                Console.WriteLine($"Popped Item : {item}. Priority Was : {priority}");
            }

            Console.WriteLine("******Using custom IComparer********");
            PriorityQueue<string, string> bankQueue = new PriorityQueue<string, string>(new TitleComparer());
            bankQueue.Enqueue("John Jones", "Sir");
            bankQueue.Enqueue("Jim Smith", "Mr");
            bankQueue.Enqueue("Sam Poll", "Mr");
            bankQueue.Enqueue("Edward Jones", "Sir");

            Console.WriteLine("Clearing Customers Now");
            while (bankQueue.TryDequeue(out string item, out string priority))
            {
                Console.WriteLine($"Popped Item : {item}. Priority Was : {priority}");
            }

            //Console.WriteLine(string.Join(",", FindKthLargestElements(new int[] {2, 10, 5, 17, 7, 18, 6, 4}, 3)));
            //Console.WriteLine(string.Join(",", FindKthLargestElements2(new int[] { 2, 10, 5, 17, 7, 18, 6, 4 }, 3)));

        }


        public string ReorganizeString(string s)
        {
            HashSet<int> visited = new HashSet<int>();
            string temp = string.Empty;
            dfs(s, temp, visited);
            return result;
        }

        void dfs(string s, string temp, HashSet<int> visited)
        {
            if (temp.Length == s.Length)
            {
                result = temp;
                return;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (visited.Contains(i) || (temp.Length != 0 && s[i] == temp[temp.Length - 1]))
                    continue;
                visited.Add(i);
                dfs(s, temp + s[i], visited);
                visited.Remove(i);
            }
        }

        public List<int> FindKthLargestElementsMinHeap(int[] input, int k)
        {
            var result = new List<int>();
            var minHeap = new PriorityQueue<int, int>();
            for (int i = 0 ; i < input.Length; i++)
            {
                var current = input[i];
                if(i < k)
                    minHeap.Enqueue(current, current);
                else
                {
                    if(current > minHeap.Peek())
                    {
                        minHeap.Dequeue();
                        minHeap.Enqueue(current, current);
                    }
                }
            }
            while(minHeap.Count > 0)
                result.Add(minHeap.Dequeue());
            return result;
        }

        public List<int> FindKthLargestElementsMaxHeap(int[] input, int k)
        {
            var result = new List<int>();
            var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a,b) => b - a));
            foreach(int num in input)
                maxHeap.Enqueue(num, num);
            while(k-- > 0)
                result.Add(maxHeap.Dequeue());
            return result;
        }
    }

    class TitleComparer : IComparer<string>
    {
        public int Compare(string titleA, string titleB)
        {
            Console.WriteLine($"Comparing {titleA} and {titleB}");
            var titleAIsFancy = titleA.Equals("sir", StringComparison.InvariantCultureIgnoreCase);
            var titleBIsFancy = titleB.Equals("sir", StringComparison.InvariantCultureIgnoreCase);


            if (titleAIsFancy == titleBIsFancy) //If both are fancy (Or both are not fancy, return 0 as they are equal)
            {
                return 0;
            }
            else if (titleAIsFancy) //Otherwise if A is fancy (And therefore B is not), then return -1
            {
                return -1;
            }
            else //Otherwise it must be that B is fancy (And A is not), so return 1
            {
                return 1;
            }
        }
    }
}
