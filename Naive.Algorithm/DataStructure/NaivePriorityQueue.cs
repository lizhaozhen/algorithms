using System;
using System.Collections;
using System.Collections.Generic;
using Algorithm.DataStructure;

namespace Naive.Algorithm.DataStructure
{
    public class NaivePriorityQueue<T> : IPriorityQueue<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly List<T> _items = new List<T>();
        public NaivePriorityQueue()
        {
            _comparer = System.Collections.Generic.Comparer<T>.Default;
        }

        public NaivePriorityQueue(IEnumerable<T> collection)
        {
            _items.AddRange(collection);
            _comparer = System.Collections.Generic.Comparer<T>.Default;
        }

        public NaivePriorityQueue(IComparer<T> comparer)
        {
            this._comparer = comparer ?? System.Collections.Generic.Comparer<T>.Default;
        }

        public int Count => _items.Count;

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        private int GetMaxValueIndex()
        {
            int index = 0;
            for(int i=1;i<_items.Count;i++)
            {
                if(_comparer.Compare(_items[i], _items[index]) < 0)
                {
                    index = i;
                }
            }
            return index;
        }

        public T Peek()
        {
            return _items[GetMaxValueIndex()];
        }

        public T Pop()
        {
            var index = GetMaxValueIndex();
            var item = _items[index];
            _items.RemoveAt(index);
            return item;
        }

        public T[] ToArray()
        {
            return _items.ToArray();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
