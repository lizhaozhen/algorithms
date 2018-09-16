using System;
using Algorithm.Extensions;

namespace Algorithm.DataStructure
{
    // Index starts from 1
    public class BinaryIndexTree<T> : IBinaryIndexTree<T>
    {
        private T[] _sums;

        public BinaryIndexTree(int size)
        {
            _sums = new T[size+1];
        }

        public int Size => _sums.Length - 1;

        public void AddTo(int index, T value)
        {
            while(index <= Size)
            {
                _sums[index] = (dynamic)_sums[index] + (dynamic) value;
                index += index.GetLastBit();
            }
        }

        public T Get(int index)
        {
            return GetRangeSum(index, index);
        }

        public T GetRangeSum(int from, int to)
        {
            return (dynamic)GetSum(to) - (dynamic)GetSum(from-1);
        }

        public T GetSum(int index)
        {
            dynamic sum = 0;
            while(index > 0){
                sum += _sums[index];
                index -= index.GetLastBit();
            }
            return sum;
        }
    }
}
