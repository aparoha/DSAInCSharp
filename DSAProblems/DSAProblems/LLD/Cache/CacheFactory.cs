namespace DSAProblems.LLD.Cache
{
    public class CacheFactory<Key, Value>
    {
        public Cache<Key, Value> DefaultCache(int capacity)
        {
            return new Cache<Key, Value>(new LRUEvictionPolicy<Key>(),
                    new HashMapBasedStorage<Key, Value>(capacity));
        }
    }
}
