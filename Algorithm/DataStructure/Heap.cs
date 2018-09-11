using System;
using System.Linq;
using System.Collections.Generic;
using Algorithm.Extensions;

namespace Algorithm.DataStructure
{
    public class Heap<T> : IHeap<T>
    {
        private List<T> _items = new List<T>();

        public T this[int index] => _items[index];

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

        public void Swap(int i, int j)
        {
            _items.Swap(i,j);
        }
    }
}
