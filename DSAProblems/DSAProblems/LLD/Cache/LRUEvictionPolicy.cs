using System.Collections.Generic;

namespace DSAProblems.LLD.Cache
{
    public class LRUEvictionPolicy<Key> : IEvictionPolicy<Key>
    {
        private readonly Dictionary<Key, LinkedListNode<Key>> _mapper;
        private readonly LinkedList<Key> _list;

        public LRUEvictionPolicy()
        {
            _mapper = new Dictionary<Key, LinkedListNode<Key>>();
            _list = new LinkedList<Key>();
        }

        public Key EvictKey()
        {
            LinkedListNode<Key> first = _list.Last;
            if (first == null)
            {
                return default(Key);
            }
            _list.Remove(first);
            return first.Value;
        }

        public void KeyAccessed(Key key)
        {
            if (_mapper.ContainsKey(key))
            {
                LinkedListNode<Key> node = _mapper[key];
                _list.Remove(node);
                _list.AddFirst(node);
            }
            else
            {
                _list.AddFirst(key);
                _mapper[key] = _list.First;
            }
        }
    }
}
