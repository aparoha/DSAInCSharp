using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DSAProblems.LLD.ProducerConsumer
{
    class AbstractQueueProducer<T>
    {
        SynchronizedQueue<T> sq;
        Thread t;

        /// <summary>
        /// Create a new user object for a SynchronizedQueue
        /// </summary>
        /// <param name="synchronizedQueue">The queue for which the user is created</param>
        public AbstractQueueProducer(SynchronizedQueue<T> synchronizedQueue)
        {
            sq = synchronizedQueue;
            t = new Thread(threadMethod);
            t.Start();
            sq.AddWorker(t, QueueUserType.PRODUCER);
        }

        void threadMethod()
        {
            while (true)
            {
                // Abort this thread if the RunProucers flag isn't set anymore
                if (!sq.RunProducers)
                    break;

                // Produce the next task object and enqueue it
                sq.Enqueue(produce());
            }
        }

        /// <summary>
        /// Method "stub" that must be overridden in the actual implementation. This method creates the tasks that shall go into the queue.
        /// </summary>
        /// <returns>The next task that has to go into the queue</returns>
        protected virtual T produce()
        {
            throw new NotImplementedException("Please override this method in your implementation!");
        }
    }
}
