using System;
using System.Collections.Generic;

namespace Algorithm.DataStructure
{
    public interface IBinaryHeap<T>
    {
        void Add(T item);
        void Clear();
        bool IsEmpty();
        T this[int index] { get; }
        int Count {get;}
        void Sink(int index, IComparer<T> comparer = null);
        void Popup(int index, IComparer<T> comparer = null);
        void Swap(int firstIndex, int secondIndex);
        T Peek();
        T Pop();
        T[] ToArray();
    }
}
