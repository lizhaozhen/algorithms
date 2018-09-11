using System;
using System.Collections;
using System.Collections.Generic;
using Algorithm.Extensions;

namespace Algorithm.DataStructure
{
    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly List<T> _items = new List<T>();

        public PriorityQueue() : this(System.Collections.Generic.Comparer<T>.Default)
        {
            
        }

        public PriorityQueue(IEnumerable<T> collection) : this(System.Collections.Generic.Comparer<T>.Default)
        {
        }

        public PriorityQueue(IEnumerable<T> collection, IComparer<T> comparer) : this(comparer)
        {
        }

        public PriorityQueue(IComparer<T> comparer) => this._comparer = comparer ?? System.Collections.Generic.Comparer<T>.Default;

        private void BuildHeap(IEnumerable<T> collection)
        {
            if(collection == null) return;

            foreach(var item in collection)
            {
                _items.Add(item);
            }

            for(int i = GetParentIndex(_items.Count - 1); i >= 0; i--)
            {
                Sink(i);
            }
        }

        private int GetParentIndex(int x)
        {
            return (x - 1) >> 1;
        }

        private int GetLeftChildIndex(int x)
        {
            return (x << 1) + 1;
        }

        private int GetRightChildIndex(int x)
        {
            return (x << 1) + 2;
        }

        private void Sink(int index)
        {
            while(index < _items.Count)
            {
                int childIndex = GetLeftChildIndex(index);
                if(childIndex >= _items.Count) break;

                int rightIndex = GetRightChildIndex(index);
                if(rightIndex < _items.Count && _items.Less(rightIndex, childIndex, _comparer))
                {
                    childIndex = rightIndex;
                }

                if(!_items.Less(childIndex, index, _comparer)) break;

                _items.Swap(index, childIndex);
                index = childIndex;
            }
        }

        private void Popup(int index)
        {
            while(index > 0)
            {
                int parentIndex = GetParentIndex(index);
                if(!_items.Less(index, parentIndex, _comparer)) break;
                _items.Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        public int Count => _items.Count;

        public void Add(T item)
        {
            _items.Add(item);
            Popup(_items.Count-1);
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

        public T Peek()
        {
            //if(IsEmpty()) throw new Exception("Priority queue is empty.");

            return _items[0];
        }

        public T Pop()
        {
            var top = Peek();
            _items[0] = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);
            Sink(0);
            return top;
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
