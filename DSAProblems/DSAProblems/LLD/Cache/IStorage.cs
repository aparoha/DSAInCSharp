namespace DSAProblems.LLD.Cache
{
    public interface IStorage<Key, Value>
    {
        public void Add(Key key, Value value);
        void Remove(Key key);
        Value Get(Key key);
    }
}
