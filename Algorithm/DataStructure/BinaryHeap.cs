using System;
using System.Linq;
using System.Collections.Generic;
using Algorithm.Extensions;
using Algorithm.Common;

namespace Algorithm.DataStructure
{
    public class BinaryHeap<T> : IBinaryHeap<T>
    {
        private List<T> _items = new List<T>();

        public int Count => _items.Count;

        public T this[int index] => _items[index];

        public BinaryHeap()
        {
            
        }

        public BinaryHeap(IEnumerable<T> collection)
        {
            _items.AddRange(collection);
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool IsEmpty()
        {
            return _items.Count == 0;
        }

        public T Peek()
        {
            return _items.First();
        }

        public T Pop()
        {
            var top = Peek();
            _items[0] = _items[_items.Count-1];
            _items.RemoveAt(_items.Count-1);
            return top;
        }

        public T[] ToArray()
        {
            return _items.ToArray();
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            _items.Swap(firstIndex, secondIndex);
        }

        public void Sink(int index, IComparer<T> comparer = null)
        {
            if(comparer == null) comparer = System.Collections.Generic.Comparer<T>.Default;

            while(index < _items.Count)
            {
                int childIndex = BinaryHeapHelper.GetLeftChildIndex(index);
                if(childIndex >= _items.Count) break;

                int rightIndex = BinaryHeapHelper.GetRightChildIndex(index);
                if(rightIndex < _items.Count && _items.Less(rightIndex, childIndex, comparer))
                {
                    childIndex = rightIndex;
                }

                if(!_items.Less(childIndex, index, comparer)) break;

                _items.Swap(index, childIndex);
                index = childIndex;
            }
        }

        public void Popup(int index, IComparer<T> comparer = null)
        {
            if(comparer == null) comparer = System.Collections.Generic.Comparer<T>.Default;

            while(index > 0)
            {
                int parentIndex = BinaryHeapHelper.GetParentIndex(index);
                if(!_items.Less(index, parentIndex, comparer)) break;
                _items.Swap(index, parentIndex);
                index = parentIndex;
            }
        }
    }
}
