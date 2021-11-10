using System;
using System.Collections.Generic;

namespace DSAProblems.Algorithms.Sorting
{
    public interface IGenericSortingAlgorithm<T> where T : IComparable
    {
        void Sort(IList<T> list);
    }
}
