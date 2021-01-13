using System;

namespace DSAProblems.DataStructures.Graph
{
    public class UnweightedEdge<TVertex> : IEdge<TVertex> where TVertex : IComparable<TVertex>
    {
        public TVertex Source { get; set; }
        public TVertex Destination { get; set; }

        /// <summary>
        /// [PRIVATE MEMBER] Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public Int64 Weight
        {
            get => throw new NotImplementedException("Unweighted edges don't have weights.");
            set => throw new NotImplementedException("Unweighted edges can't have weights.");
        }

        /// <summary>
        /// Gets a value indicating whether this edge is weighted.
        /// </summary>
        public bool IsWeighted => false;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public UnweightedEdge(TVertex src, TVertex dst)
        {
            Source = src;
            Destination = dst;
        }


        #region IComparable implementation
        public int CompareTo(IEdge<TVertex> other)
        {
            if (other == null)
                return -1;

            bool areNodesEqual = Source.IsEqualTo(other.Source) && Destination.IsEqualTo(other.Destination);

            if (!areNodesEqual)
                return -1;
            return 0;
        }
        #endregion
    }
}
