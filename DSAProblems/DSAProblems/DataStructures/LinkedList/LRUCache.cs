using System;
using System.Collections.Generic;

namespace DSAProblems.DataStructures.LinkedList
{
    public class LRUCache
    {
        private Dictionary<int, LinkedListNode<(int, int)>> _cache;
        private LinkedList<(int, int)> _list;
        private int _capacity;

        public LRUCache(int capacity)
        {
            _cache = new Dictionary<int, LinkedListNode<(int, int)>>();
            _list = new LinkedList<(int, int)>();
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key))
                return -1;

            var node = _cache[key];
            _list.Remove(node);
            _list.AddFirst(node);
            return node.Value.Item2;
        }

        public void Put(int key, int value)
        {
            if (_cache.ContainsKey(key))
            {
                _cache[key].Value = (key, value);
                _list.Remove(_cache[key]);
                _list.AddFirst(_cache[key]);
            }
            else
            {
                // add a new entry to cache and list
                _cache.Add(key, new LinkedListNode<(int, int)>((key, value)));
                _list.AddFirst(_cache[key]);

                if (_cache.Count > _capacity)
                {
                    // remove the last entry from the cache and list if capacity execeeds the limit
                    // use _list.Last to get the LinkedListNode object
                    // this helps remove last entry from list in O(1)
                    LinkedListNode<(int, int)> lastCache = _list.Last;
                    _cache.Remove(lastCache.Value.Item1);
                    _list.RemoveLast();
                }
            }
        }
    }
}
