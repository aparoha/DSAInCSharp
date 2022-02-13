using System;
using System.Threading;

namespace DSAProblems.MultiThreading
{
    public class EvenOddThreadSync
    {
        //AutoResetEvent maintains a boolean variable in memory.
        //If the boolean variable is false then it blocks the thread and if the boolean variable is true it unblocks the thread.
        private static readonly AutoResetEvent _evenEvent = new AutoResetEvent(false);
        private static readonly AutoResetEvent _oddEvent = new AutoResetEvent(false);
        private static int _maxNum = 10;

        private static void PrintEven()
        {
            for (int i = 0; i <= _maxNum; i++)
            {
                SetEvent(EventType.Even, false);
                SetEvent(EventType.Odd, true);
                if (i % 2 == 0) Console.WriteLine($"{i}");
            }
            SetEvent(EventType.Even, false);
        }

        static void PrintOdd()
        {
            for (int i = 1; i <= _maxNum; i++)
            {
                SetEvent(EventType.Odd, false);
                SetEvent(EventType.Even, true);
                if (i % 2 != 0) Console.WriteLine($"{i}");
            }
            SetEvent(EventType.Odd, false);
        }

        public void Run(int count)
        {
            _maxNum = count;
            new Thread(PrintOdd).Start();
            new Thread(PrintEven).Start();
            Console.ReadKey();
        }

        private static void SetEvent(EventType eventType, bool waitOne)
        {
            if (EventType.Even == eventType)
            {
                if (waitOne)
                    _evenEvent.WaitOne(); //Thread can enter into a wait state by calling WaitOne() 
                else
                    _evenEvent.Set();//When second thread calls the Set() method it unblocks the waiting thread
            }
            else
            {
                if (waitOne)
                    _oddEvent.WaitOne();
                else
                    _oddEvent.Set();
            }

        }
    }

    public enum EventType { Even, Odd }
}
