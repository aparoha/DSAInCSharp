using System;
using System.Collections.Generic;
using System.Linq;

namespace DSAProblems.DataStructures.Graph.Undirected.Unweighted
{
    public class SparseGraph<T>: IGraph<T> where T : IComparable<T>
    {
        protected virtual int _edgesCount { get; set; }
        protected virtual T _firstInsertedNode { get; set; }
        protected virtual Dictionary<T, LinkedList<T>> _adjacencyList { get; set; }
        public virtual bool IsDirected => false;
        public bool IsWeighted => false;
        public int VerticesCount => _adjacencyList.Count;
        public int EdgesCount => _edgesCount;

        public IEnumerable<T> Vertices => _adjacencyList.Keys.ToList();

        IEnumerable<IEdge<T>> IGraph<T>.Edges => Edges;

        public virtual IEnumerable<UnweightedEdge<T>> Edges
        {
            get
            {
                var seen = new HashSet<KeyValuePair<T, T>>();

                var edges = new List<UnweightedEdge<T>>();
                foreach (KeyValuePair<T, LinkedList<T>> vertex in _adjacencyList)
                {
                    foreach (T adjacent in vertex.Value)
                    {
                        var incomingEdge = new KeyValuePair<T, T>(adjacent, vertex.Key);
                        var outgoingEdge = new KeyValuePair<T, T>(vertex.Key, adjacent);

                        if (!seen.Contains(incomingEdge) && !seen.Contains(outgoingEdge))
                        {
                            seen.Add(outgoingEdge);

                            edges.Add((new UnweightedEdge<T>(outgoingEdge.Key, outgoingEdge.Value)));
                        }
                    }
                }
                return edges;
            }
        }

        IEnumerable<IEdge<T>> IGraph<T>.IncomingEdges(T vertex)
        {
            return IncomingEdges(vertex);
        }

        public virtual IEnumerable<UnweightedEdge<T>> IncomingEdges(T vertex)
        {
            if (!HasVertex(vertex))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            var edges = new List<UnweightedEdge<T>>();
            foreach(var adjacent in _adjacencyList[vertex])
                edges.Add((new UnweightedEdge<T>(adjacent, vertex)));
            return edges;
        }

        IEnumerable<IEdge<T>> IGraph<T>.OutgoingEdges(T vertex)
        {
            return OutgoingEdges(vertex);
        }

        public virtual IEnumerable<UnweightedEdge<T>> OutgoingEdges(T vertex)
        {
            if (!HasVertex(vertex))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            var edges = new List<UnweightedEdge<T>>();
            foreach(var adjacent in _adjacencyList[vertex])
                edges.Add((new UnweightedEdge<T>(vertex, adjacent)));
            return edges;
        }

        protected virtual bool _doesEdgeExist(T vertex1, T vertex2)
        {
            return (_adjacencyList[vertex1].Contains(vertex2) || 
                _adjacencyList[vertex2].Contains(vertex1));
        }

        public bool AddEdge(T firstVertex, T secondVertex)
        {
            if (!_adjacencyList.ContainsKey(firstVertex) || !_adjacencyList.ContainsKey(secondVertex))
                return false;
            if (_doesEdgeExist(firstVertex, secondVertex))
                return false;

            _adjacencyList[firstVertex].AddLast(secondVertex);
            _adjacencyList[secondVertex].AddLast(firstVertex);

            // Increment the edges count
            ++_edgesCount;

            return true;
        }

        public bool RemoveEdge(T firstVertex, T secondVertex)
        {
            if (!_adjacencyList.ContainsKey(firstVertex) || !_adjacencyList.ContainsKey(secondVertex))
                return false;
            if (!_doesEdgeExist(firstVertex, secondVertex))
                return false;

            _adjacencyList[firstVertex].Remove(secondVertex);
            _adjacencyList[secondVertex].Remove(firstVertex);

            // Decrement the edges count
            --_edgesCount;

            return true;
        }

        public void AddVertices(IList<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();

            foreach (var item in collection)
                AddVertex(item);
        }

        public bool AddVertex(T vertex)
        {
            // Check existence of vertex
            if (_adjacencyList.ContainsKey(vertex))
                return false;

            if (_adjacencyList.Count == 0)
                _firstInsertedNode = vertex;

            _adjacencyList.Add(vertex, new LinkedList<T>());

            return true;
        }

        public bool RemoveVertex(T vertex)
        {
            // Check existence of vertex
            if (!_adjacencyList.ContainsKey(vertex))
                return false;

            _adjacencyList.Remove(vertex);

            foreach (KeyValuePair<T, LinkedList<T>> adjacent in _adjacencyList)
            {
                if (adjacent.Value.Contains(vertex))
                {
                    adjacent.Value.Remove(vertex);

                    // Decrement the edges count.
                    --_edgesCount;
                }
            }

            return true;
        }

        public bool HasEdge(T firstVertex, T secondVertex)
        {
            // Check existence of vertices
            if (!_adjacencyList.ContainsKey(firstVertex) || !_adjacencyList.ContainsKey(secondVertex))
                return false;

            return (_adjacencyList[firstVertex].Contains(secondVertex) || _adjacencyList[secondVertex].Contains(firstVertex));
        }

        public bool HasVertex(T vertex)
        {
            return _adjacencyList.ContainsKey(vertex);
        }

        public LinkedList<T> Neighbours(T vertex)
        {
            if (!HasVertex(vertex))
                return null;

            return _adjacencyList[vertex];
        }

        public int Degree(T vertex)
        {
            if (!HasVertex(vertex))
                throw new KeyNotFoundException();

            return _adjacencyList[vertex].Count;
        }

        public IEnumerable<T> DepthFirstWalk()
        {
            return DepthFirstWalk(_firstInsertedNode);
        }

        public IEnumerable<T> DepthFirstWalk(T source)
        {
            if (VerticesCount == 0)
                return new List<T>();
            if (!HasVertex(source))
                throw new Exception("The specified starting vertex doesn't exist.");

            var visited = new HashSet<T>();
            var stack = new Stack<T>(VerticesCount);
            var listOfNodes = new List<T>(VerticesCount);

            stack.Push(source);

            while (stack.Any())
            {
                var current = stack.Pop();
                if (!visited.Contains(current))
                {
                    listOfNodes.Add(current);
                    visited.Add(current);

                    foreach (var adjacent in Neighbours(current))
                        if (!visited.Contains(adjacent))
                            stack.Push(adjacent);
                }
            }

            return listOfNodes;
        }

        public IEnumerable<T> BreadthFirstWalk()
        {
            return BreadthFirstWalk(_firstInsertedNode);
        }

        public IEnumerable<T> BreadthFirstWalk(T source)
        {
            if (VerticesCount == 0)
                return new List<T>();
            if (!HasVertex(source))
                throw new Exception("The specified starting vertex doesn't exist.");


            var visited = new HashSet<T>();
            var queue = new Queue<T>(VerticesCount);
            var listOfNodes = new List<T>(VerticesCount);

            listOfNodes.Add(source);
            visited.Add(source);

            queue.Enqueue(source);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                var neighbors = Neighbours(current);

                foreach (var adjacent in neighbors)
                {
                    if (!visited.Contains(adjacent))
                    {
                        listOfNodes.Add(adjacent);
                        visited.Add(adjacent);
                        queue.Enqueue(adjacent);
                    }
                }
            }

            return listOfNodes;
        }
    }
}
