using System;
using System.Collections.Generic;

namespace DSAProblems.LLD.Cache
{
    public class HashMapBasedStorage<Key, Value> : IStorage<Key, Value>
    {
        private readonly Dictionary<Key, Value> _storage;
        private int _capacity;

        public HashMapBasedStorage(int capacity)
        {
            _storage = new Dictionary<Key, Value>();
            _capacity = capacity;
        }

        public void Add(Key key, Value value)
        {
            if(IsStorageFull())
                throw new Exception("Storage is full");
            _storage[key] = value;
        }

        public Value Get(Key key)
        {
            if(!_storage.ContainsKey(key))
                throw new Exception($"{key} doesn't exist in cache");
            return _storage[key];
        }

        public void Remove(Key key)
        {
            if (!_storage.ContainsKey(key))
                throw new Exception($"{key} doesn't exist in cache");
            _storage.Remove(key);
        }

        private bool IsStorageFull()
        {
            return _storage.Count == _capacity;
        }
    }
}
