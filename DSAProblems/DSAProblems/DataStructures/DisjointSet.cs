using System;
using System.Collections;
using System.Collections.Generic;

namespace DSAProblems.DataStructures
{
    class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Parent { get; set; }
        public int Rank { get; set; }
        public int Size {  get; set;}
        public Node(T data)
        {
            Data = data;
            Parent = this;
            Rank = 0;
            Size = 1;
        }
    }

    /*  Detect cycle in undirected graph
     *  1. Create set for each vertex
     *  2. Process each edge of the graph and perform union and find operations on both vertices of each edge
     *  3. If find operation on both the vertices returns the same parentthen cyclle is detected
     * 
     * 
    */

    public class DisjointSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly Dictionary<T, Node<T>> _nodes;
        private int _numComponents;
        private int _maxSize;

        public int Components { get { return _numComponents; } }
        public int Count { get { return _nodes.Count; } }
        public int MaxSize { get { return _maxSize; } }

        public DisjointSet()
        {
            _numComponents = 0;
            _maxSize = 0;
            _nodes = new Dictionary<T, Node<T>>();
        }

        public bool MakeSet(T data)
        {
            if (_nodes.ContainsKey(data))
                return false;
            _nodes.Add(data, new Node<T>(data));
            _numComponents++;
            return true;
        }

        public void Union(T dataA, T dataB)
        {
            if (_nodes.ContainsKey(dataA) && _nodes.ContainsKey(dataB))
            {
                Node<T> parentA = FindSet(_nodes[dataA]);
                Node<T> parentB = FindSet(_nodes[dataB]);

                if (parentA == parentB) return;

                int currentSize = parentA.Size + parentB.Size;
                if (parentA.Rank >= parentB.Rank)
                {
                    if (parentA.Rank == parentB.Rank)
                        parentA.Rank++;
                    parentB.Parent = parentA;
                    parentA.Size = currentSize; ;
                }
                else
                {
                    parentA.Parent = parentB;
                    parentB.Size = currentSize;
                }
                _maxSize = Math.Max(_maxSize, currentSize);
                _numComponents--;
            }
        }

        public T FindSet(T data)
        {
            return FindSet(_nodes[data]).Data;
        }

        public bool IsConnected(T dataA, T dataB)
        {
            return FindSet(dataA).CompareTo(FindSet(dataB)) == 0;
        }

        public void Clear()
        {
            _nodes.Clear();
        }


        private Node<T> FindSet(Node<T> node)
        {
            if (node != node.Parent)
                node.Parent = FindSet(node.Parent);
            return node.Parent;
        }

        private Node<T> FindSetNonRecursive(Node<T> node)
        {
            Node<T> root = node;
            while (root != root.Parent)
                root = root.Parent;
            while (node != root)
            {
                Node<T> parent = node.Parent;
                node.Parent = root;
                node = parent;
            }
            return root;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _nodes.Keys.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _nodes.Keys.GetEnumerator();
        }

        public bool FindCycle(Dictionary<T, List<T>> graph, List<T> nodes)
        {
            foreach (var node in nodes)
                MakeSet(node);
            for (int i = 0; i < nodes.Count; i++)
            {
                T u = nodes[i];
                foreach (T v in graph[u])
                {
                    T rootU = FindSet(u);
                    T rootV = FindSet(v);
                    if (IsConnected(rootU, rootV))
                        return true;
                    else
                        Union(rootU, rootV);
                }
            }
            return false;
        }
    }
}
