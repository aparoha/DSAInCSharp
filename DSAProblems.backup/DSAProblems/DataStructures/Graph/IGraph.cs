using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAProblems.DataStructures.Graph
{
    public interface IGraph<T> where T : IComparable<T>
    {
        bool IsDirected { get; }
        bool IsWeighted { get; }
        int VerticesCount { get; }
        int EdgesCount { get; }
        IEnumerable<T> Vertices { get; }
        IEnumerable<IEdge<T>> Edges { get; }
        //Get all incoming edges from vertex
        IEnumerable<IEdge<T>> IncomingEdges(T vertex);
        // Get all outgoing edges from vertex
        IEnumerable<IEdge<T>> OutgoingEdges(T vertex);
        bool AddEdge(T firstVertex, T secondVertex);
        bool RemoveEdge(T firstVertex, T secondVertex);
        void AddVertices(IList<T> collection);
        bool AddVertex(T vertex);
        bool RemoveVertex(T vertex);
        bool HasEdge(T firstVertex, T secondVertex);
        bool HasVertex(T vertex);
        LinkedList<T> Neighbours(T vertex);
        int Degree(T vertex);
        IEnumerable<T> DepthFirstWalk();
        //A depth first search traversal of the graph, starting from a specified vertex. Prints nodes as they get visited.
        IEnumerable<T> DepthFirstWalk(T startingVertex);
        IEnumerable<T> BreadthFirstWalk();
        //A breadth first search traversal of the graph, starting from a specified vertex. Prints nodes as they get visited.
        IEnumerable<T> BreadthFirstWalk(T startingVertex);
    }
}
