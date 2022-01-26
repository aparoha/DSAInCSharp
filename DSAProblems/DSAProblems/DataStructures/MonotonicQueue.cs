using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures
{
    public class MonotonicQueue
    {
        private LinkedList<int> _doubleEndedQueue;
        private int _previous;

        public MonotonicQueue()
        {
            _doubleEndedQueue = new LinkedList<int>();
            _previous = int.MinValue;
        }

        public bool Enqueue(int current)
        {
            if(_previous > current)
                return true;
            while(_doubleEndedQueue.Count > 0 && _doubleEndedQueue.Last.Value < current)
            {
                _previous = _doubleEndedQueue.Last.Value;
                _doubleEndedQueue.RemoveLast();
            }
            _doubleEndedQueue.AddLast(current);
            return false;
        }
    }
}
