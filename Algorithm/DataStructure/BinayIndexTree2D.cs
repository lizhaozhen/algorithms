using System;
using Algorithm.Extensions;

namespace Algorithm.DataStructure
{
    // Index starts from 1
    // All operations log(m) * log(n)
    public class BinayIndexTree2D<T> : IBinayIndexTree2D<T>
    {
        private T[][] _data;
        public BinayIndexTree2D(int row, int column)
        {
            _data = new T[row+1][];
            for(int i=0;i<=row;i++)
            {
                _data[i] = new T[column+1];
            }
        }

        public int Row => _data.Length-1;

        public int Column => _data[0].Length-1;

        public void AddTo(int x, int y, T value)
        {
            while(x <= Row)
            {
                int ty = y;
                while(ty <= Column)
                {
                    _data[x][ty] += (dynamic)value;
                    ty += ty.GetLastBit();
                }
                x += x.GetLastBit();
            }
        }

        public T Get(int x, int y)
        {
            return GetRangeSum(x, y, x, y);
        }

        public T GetRangeSum(int fromX, int fromY, int toX, int toY)
        {
            return (dynamic)GetSum(toX, toY) + (dynamic)GetSum(toX-1, toY-1) - (dynamic)GetSum(toX, toY-1) - (dynamic)GetSum(toX-1, toY);
        }

        public T GetSum(int x, int y)
        {
            dynamic sum = 0;
            while(x > 0){
                int ty = y;
                while(ty > 0){
                    sum += _data[x][ty];
                    ty -= ty.GetLastBit();
                }
                x-=x.GetLastBit();
            }
            return sum;
        }
    }
}
