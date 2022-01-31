using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DSAProblems.LLD.ProducerConsumer
{
    class AbstractQueueConsumer<T>
    {
        SynchronizedQueue<T> sq;
        Thread t;

        /// <summary>
        /// Create a new user object for a SynchronizedQueue
        /// </summary>
        /// <param name="synchronizedQueue">The queue for which the user is created</param>
        public AbstractQueueConsumer(SynchronizedQueue<T> synchronizedQueue)
        {
            sq = synchronizedQueue;
            t = new Thread(threadMethod);
            t.Start();
            sq.AddWorker(t, QueueUserType.CONSUMER);
        }

        void threadMethod()
        {
            while (true)
            {
                T task;

                // Wait for and retrieve next task
                lock (sq)
                {
                    while (sq.Count == 0 && sq.RunConsumers)
                        Monitor.Wait(sq);

                    // Abort this thread if the RunConsumers flag isn't set anymore
                    if (!sq.RunConsumers)
                        break;

                    task = sq.Dequeue();
                }

                // If there's an actual task, consume it
                if (task != null)
                    consume(task);
            }
        }

        /// <summary>
        /// Method "stub" that must be overridden in the actual implementation. Every time a task is taken off the queue, this method is invoked.
        /// </summary>
        /// <param name="task">The task that just got dequeued from the queue and shall be consumed now</param>
        protected virtual void consume(T task)
        {
            throw new NotImplementedException("Please override this method in your implementation!");
        }
    }
}
