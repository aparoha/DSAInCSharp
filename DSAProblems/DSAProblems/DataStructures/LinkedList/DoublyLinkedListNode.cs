namespace DSAProblems.DataStructures.LinkedList
{
    public sealed class DoublyLinkedListNode<T>
    {
        public T Value { get; private set; }
        public DoublyLinkedListNode<T> Next { get; internal set; }
        public DoublyLinkedListNode<T> Previous { get; internal set; }
        internal DoublyLinkedListNode(T item)
        {
            this.Value = item;
            this.Next = null;
            this.Previous = null;
        }
    }
}
