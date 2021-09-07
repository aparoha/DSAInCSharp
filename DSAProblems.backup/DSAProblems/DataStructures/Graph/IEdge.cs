using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures.Graph
{
    public interface IEdge<TVertex> : IComparable<IEdge<TVertex>> where TVertex : IComparable<TVertex>
    {

        bool IsWeighted { get; }
        TVertex Source { get; set; }
        TVertex Destination { get; set; }
        Int64 Weight { get; set; }
    }
}
