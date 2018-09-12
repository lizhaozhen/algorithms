using System;
using System.Collections;
using System.Collections.Generic;
using Algorithm.Extensions;

namespace Algorithm.DataStructure
{
    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        private readonly IComparer<T> _comparer;

        private BinaryHeap<T> _heap;

        public PriorityQueue() : this(System.Collections.Generic.Comparer<T>.Default)
        {
            
        }

        public PriorityQueue(IEnumerable<T> collection) : this(System.Collections.Generic.Comparer<T>.Default)
        {
        }

        public PriorityQueue(IEnumerable<T> collection, IComparer<T> comparer) : this(comparer)
        {
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            _comparer = comparer ?? System.Collections.Generic.Comparer<T>.Default;
            _heap = new BinaryHeap<T>();
        }

        public int Count => _heap.Count;

        public void Add(T item)
        {
            _heap.Add(item);
            _heap.Popup(_heap.Count-1, _comparer);
        }

        public void Clear()
        {
            _heap.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return null;
        }

        public bool IsEmpty()
        {
            return _heap.IsEmpty();
        }

        public T Peek()
        {
            return _heap.Peek();
        }

        public T Pop()
        {
            var top = _heap.Pop();

            _heap.Sink(0, _comparer);

            return top;
        }

        public T[] ToArray()
        {
            return _heap.ToArray();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
}
