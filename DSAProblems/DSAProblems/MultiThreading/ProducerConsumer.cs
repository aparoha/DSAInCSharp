using System;
using System.Collections.Generic;
using System.Threading;

namespace DSAProblems.MultiThreading
{
    /*
            1. One or more producers producing items - items will be placed in some storage area
            2. One or more consumers consuming items - out of storage area and process
            3. If there is no item in storage area, consumers have to wait for item to be added. Whenever proucer adds an item then concumer is ready to consume
            4. If producer is trying to add an item and storage is full, producer waits for consumer to consume an item out of storage. Whenever space is available producer can add item
            5. What we need?
                A Queue with fixed capacity
                Multiple Producer threads - block/wait state if queue is full
                Multiple Consumer threads - block/wait state if queue is empty
                Consumer threads will send signal to producer threads - "queue is not full anymore"
                Producer threads will send signal to consumer threads - "queue is not empty anymore"

            ProducerConsumer q = new ProducerConsumer(2);
            Console.WriteLine("Enqueuing 10 items...");
            for (int i = 0; i < 10; i++)
            {
                int itemNumber = i;      // To avoid the captured variable trap
                q.EnqueueItem(() =>
                {
                    Thread.Sleep(1000);          // Simulate time-consuming work
                    Console.Write(" Task" + itemNumber);
                });
            }
            q.Shutdown(true);
            Console.WriteLine();
            Console.WriteLine("Workers complete!");
        http://www.albahari.com/threading/part4.aspx#_Wait_Pulse_Producer_Consumer_Queue
     */
    public class ProducerConsumer
    {
        readonly object _locker = new object();
        //Allow an arbitrary number of workers, each with its own thread. We’ll keep track of the threads in an array
        //This gives us the option of Joining those threads later when we shut down the queue
        Thread[] _workers;
        Queue<Action> _itemQ = new Queue<Action>();

        //Each worker thread will execute a method called Consume. We can create the threads and start them in a single loop
        public ProducerConsumer(int workerCount)
        {
            _workers = new Thread[workerCount];

            // Create and start a separate thread for each worker
            for (int i = 0; i < workerCount; i++)
                (_workers[i] = new Thread(Consume)).Start();
        }

        public void Shutdown(bool waitForWorkers)
        {
            // Enqueue one null item per worker to make each exit.
            foreach (Thread worker in _workers)
                EnqueueItem(null);

            // Wait for workers to finish
            if (waitForWorkers)
                foreach (Thread worker in _workers)
                    worker.Join();
        }

        public void EnqueueItem(Action item)
        {
            lock (_locker)
            {
                _itemQ.Enqueue(item);           // We must pulse because we're
                Monitor.Pulse(_locker);         // changing a blocking condition.
            }
        }

        void Consume()
        {
            while (true)                        // Keep consuming until
            {                                   // told otherwise.
                Action item;
                lock (_locker)
                {
                    while (_itemQ.Count == 0) 
                        Monitor.Wait(_locker);
                    item = _itemQ.Dequeue();
                }
                if (item == null) return;         // This signals our exit.
                item();                           // Execute item.
            }
        }
    }
}
