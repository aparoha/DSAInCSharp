using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures.Heaps.Problems
{
    public class LC253_MeetingRooms
    {
        /*
            To schedule all meetings, we need to start with shortest meeting start time, then find next shortest meeting start time
            To avoid scanning list (to find shortest meeting start time) of intervals again and again to find smaller start time
            Its better to sort intervals based on start time

            There are 2 scenarios for new meeting
            - Previously assigned rooms are occupied and new meeting room needed
            - Previously assigned room is available and we can use it for new meeting

            Now we need a way to identify which meeting room is available. We'll use Priority Queue ADT and insert meeting end time
            It will help us to determine which room meeting is finished and room is available to schedule another meeting
            Answer would be the size of priority queue

                    LC253_MeetingRooms mr = new LC253_MeetingRooms();
            Console.WriteLine(mr.MinMeetingRoomsPriorityQueue(new int[][]
            {
                new int[] {1, 3},
                new int[] {8, 10},
                new int[] {7, 8},
                new int[] {9, 15},
                new int[] {2, 6}
            }));

        Answer 2
         
         
        */

        //SC - O(n) where n is no of meetings - create new room for each meeting
        //TC - O(nlogn) 
        public int MinMeetingRoomsPriorityQueue(int[][] intervals)
        {
            if(intervals.Length == 0)
                return 0;
            //Sort intervals by start time
            Array.Sort(intervals, (firstInterval, secondInterval) => firstInterval[0].CompareTo(secondInterval[0]));
            //Default is min-heap
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            foreach(int[] interval in intervals)
            {
                //If it is first meeting, enqueue end time of interval
                //No meeting is scheduled i.e. queue is empty
                if(pq.Count == 0)
                    pq.Enqueue(interval[1], interval[1]);
                else
                {
                    //Whenever we are scheduling new meeting
                    //2 cases - schedule it in new room or use previously allocated room which is free now
                    //priority queue peek will tell us which room is getting free the earliest and we can use it or not

                    //If new meeting start time is after than end time of last occupied meeting room then we can use this pre-occupied room

                    if (pq.Peek() <= interval[0])
                        pq.Dequeue(); //We can use existing room
                    pq.Enqueue(interval[1], interval[1]);//Schedule meeting in room
                }
            }
            return pq.Count;
        }

        public int MinMeetingRoomsChronologicalOrder(int[][] intervals)
        {
            if (intervals.Length == 0)
                return 0;
            int n = intervals.Length;
            int[] startTimes = new int[n];
            int[] endTimes = new int[n];
            for(int i = 0; i < n; i++)
            {
                startTimes[i] = intervals[i][0];
                endTimes[i] = intervals[i][1];
            }
            Array.Sort(startTimes);
            Array.Sort(endTimes);
            int minCount = 0;
            int startPointer = 0, endPointer = 0;
            while(startPointer < startTimes.Length)
            {
                if(startTimes[startPointer] < endTimes[endPointer])
                {
                    minCount++;
                    startPointer++;
                }
                else
                {
                    startPointer++;
                    endPointer++;
                }
            }
            return minCount;
        }
    }
}
