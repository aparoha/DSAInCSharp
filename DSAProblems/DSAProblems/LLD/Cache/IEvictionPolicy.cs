using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.LLD.Cache
{
    public interface IEvictionPolicy<Key>
    {
        void KeyAccessed(Key key);
        Key EvictKey();
    }
}
