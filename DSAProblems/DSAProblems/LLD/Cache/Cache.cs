using System;

namespace DSAProblems.LLD.Cache
{
    public class Cache<Key, Value>
    {
        private readonly IEvictionPolicy<Key> _evictionPolicy;
        private readonly IStorage<Key, Value> _storage;

        public Cache(IEvictionPolicy<Key> evictionPolicy, IStorage<Key, Value> storage)
        {
            _evictionPolicy = evictionPolicy;
            _storage = storage;
        }

        public void Put(Key key, Value value)
        {
            try
            {
                _storage.Add(key, value);
                _evictionPolicy.KeyAccessed(key);
            }
            catch (Exception)
            {
                Console.WriteLine("Got storage full. Will try to evict");
                Key keyToEvict = _evictionPolicy.EvictKey();
                if(keyToEvict == null)
                    throw new Exception("Unexpected state. Storage full and no key to evict");
                _storage.Remove(keyToEvict);
                Console.WriteLine($"Evicting item {keyToEvict}");
                Put(key, value);
            }
        }

        public Value Get(Key key)
        {
            Value value = _storage.Get(key);
            _evictionPolicy.KeyAccessed(key);
            return value;
        }
    }
}
