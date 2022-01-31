using System;
using System.Collections.Generic;
using System.Threading;

namespace DSAProblems.LLD.ProducerConsumer
{
    public enum QueueUserType { PRODUCER, CONSUMER }

    class SynchronizedQueue<T> : IDisposable
    {
        bool runConsumers;
        bool runProducers;
        bool abortConsumersOnEnd;
        List<Thread> consumerThreads;
        List<Thread> producerThreads;
        Queue<T> queue;

        /// <summary>
        /// Creates a new QueueSynchronizer object
        /// </summary>
        /// <param name="abort">Set to true if the consumers should stop working immediately when this QueueSynchronizer is disposed. Set to false if the consumers should continue until the queue is empty.</param>
        public SynchronizedQueue(bool abort)
        {
            // Create data containers
            consumerThreads = new List<Thread>();
            producerThreads = new List<Thread>();
            queue = new Queue<T>();

            // Set all flags to their inital values
            runConsumers = true;
            runProducers = true;
            abortConsumersOnEnd = abort;
        }

        public bool RunConsumers
        {
            get { lock (this) return runConsumers; }
        }

        public bool RunProducers
        {
            get { lock (this) return runProducers; }
        }

        /// <summary>
        /// Adds a thread to the list of workers so the queue can wait for its completion on dispose
        /// </summary>
        /// <param name="consumer">The thread to be added to the list</param>
        public void AddWorker(Thread worker, QueueUserType type)
        {
            lock (this)
                if (type == QueueUserType.CONSUMER)
                    consumerThreads.Add(worker);
                else
                    producerThreads.Add(worker);
        }

        /// <summary>
        /// Represents the amount of tasks in the queue
        /// </summary>
        /// <returns>The amount of tasks in the queue as int</returns>
        public int Count
        {
            get { lock (this) return queue.Count; }
        }

        /// <summary>
        /// Enqueues a task in the task queue
        /// </summary>
        /// <param name="task">The task to add to the queue</param>
        public void Enqueue(T task)
        {
            lock (this)
            {
                queue.Enqueue(task);
                Monitor.PulseAll(this);
            }
        }

        /// <summary>
        /// Retrieves and removes a task from the task queue
        /// </summary>
        /// <returns>The requested task</returns>
        public T Dequeue()
        {
            lock (this)
            {
                while (queue.Count == 0)
                    Monitor.Wait(this);
                Monitor.PulseAll(this);
                return queue.Dequeue();
            }
        }

        void IDisposable.Dispose()
        {
            // Signal producer threads to stop
            lock (this)
            {
                runProducers = false;
                Monitor.PulseAll(this);
            }

            foreach (Thread t in producerThreads)
                t.Join();

            // If we should wait for the consumers to empty the queue
            if (!abortConsumersOnEnd)
            {
                lock (this)
                {
                    while (Count != 0)
                        Monitor.Wait(this);
                }
            }

            // Now signal the consumers to quit, too
            lock (this)
            {
                runConsumers = false;
                Monitor.PulseAll(this);
            }

            // Now wait for all threads to end
            foreach (Thread t in consumerThreads)
                t.Join();

            Console.WriteLine("All workers have stopped. Remaining tasks in queue: {0}", queue.Count);
        }

    }
}

