using System;

namespace Algorithm.DataStructure
{
    public interface IHeap<T>
    {
        void Add(T item);
        T this[int index] { get; }
        void Swap(int i, int j);
        void Clear();
        bool IsEmpty();
        T Peek();
        T Pop();
        T[] ToArray();
    }
}
