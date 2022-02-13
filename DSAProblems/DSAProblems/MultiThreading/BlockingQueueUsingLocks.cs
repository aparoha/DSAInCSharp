using System.Collections.Generic;
using System.Threading;

namespace DSAProblems.MultiThreading
{
    //https://deepakvadgama.com/blog/lfu-cache-in-O%281%29/
    //https://stackoverflow.com/questions/530211/creating-a-blocking-queuet-in-net/530228#530228
    //https://makolyte.com/event-driven-dotnet-concurrent-producer-consumer-using-blockingcollection/
    public class BlockingQueueUsingLocks<T>
    {
        private readonly Queue<T> _queue;
        private readonly int _max = 16;

        public BlockingQueueUsingLocks(int size)
        {
            _queue = new Queue<T>();
            _max = size;
        }

        public void Put(T data)
        {
            lock (_queue)
            {
                while (_queue.Count == _max)
                {
                    //Block the thread
                    //Block until queue has atleast 1 empty slot to add item
                    Monitor.Wait(_queue);
                }
                _queue.Enqueue(data);
                // wake up any blocked dequeue
                Monitor.PulseAll(_queue);
            }
        }

        public T Take()
        {
            lock (_queue)
            {
                while (_queue.Count == 0)
                {
                    //Block the thread
                    //Block until queue has atleast 1 item to take
                    Monitor.Wait(_queue);
                }
                T item = _queue.Dequeue();
                // wake up any blocked enqueue
                Monitor.PulseAll(_queue);
                return item;
            }
        }
    }
}
