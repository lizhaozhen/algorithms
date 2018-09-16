using System;

namespace Algorithm.DataStructure
{
    public interface IBinaryIndexTree<T>
    {
        int Size {get;}
        void AddTo(int index, T value);
        T Get(int index);
        T GetSum(int index);
        T GetRangeSum(int from, int to);
    }
}
