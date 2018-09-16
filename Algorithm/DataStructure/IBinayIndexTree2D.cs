using System;

namespace Algorithm.DataStructure
{
    public interface IBinayIndexTree2D<T>
    {
        int Row {get;}
        int Column {get;}
        void AddTo(int x, int y, T value);
        T Get(int x, int y);
        T GetSum(int x, int y);
        T GetRangeSum(int fromX, int fromY, int toX, int toY);
    }
}
