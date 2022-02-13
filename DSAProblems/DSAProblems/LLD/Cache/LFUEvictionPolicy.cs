//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DSAProblems.LLD.Cache
//{
//    public class LFUEvictionPolicy<Key> : IEvictionPolicy<Key>
//    {

//        private readonly Dictionary<Key, int> _frequencyMap;

//        public LFUEvictionPolicy()
//        {

//            _frequencyMap = new Dictionary<Key, int>();
//        }

//        public Key EvictKey()
//        {
//            throw new NotImplementedException();
//        }

//        public void KeyAccessed(Key key)
//        {
//            throw new NotImplementedException();
//        }

//        private void PromoteNode(LinkedListNode<Key> node, Key key)
//        {
//            LinkedList<Key> dll = _frequencyMap[key];
//            dll.Remove(node);
//            if (dll.Count == 0)
//            {
//                _frequencyMap.Remove(key);
//                if (minFrequency == node.Frequency) _minFrequency++;
//            }
//            node.Frequency++;
//            if (!frequencyMap.ContainsKey(node.Frequency))
//            {
//                frequencyMap[node.Frequency] = new LFUDoubleLinkedList();
//            }
//            _frequencyMap[key].AddFirst(node);
//        }
//    }
//}
