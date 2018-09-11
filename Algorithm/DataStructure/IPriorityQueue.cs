using System;
using System.Collections.Generic;

namespace Algorithm.DataStructure
{
    public interface IPriorityQueue<T> : IReadOnlyCollection<T>
    {
        void Add(T item);
        void Clear();
        bool IsEmpty();
        T Peek();
        T Pop();
        T[] ToArray();
    }
}
