using System;
using System.Collections.Generic;

namespace Algorithm.DataStructure
{
    public interface IMatrix<T>
    {
        int RowCount {get;}
        int ColumnCount {get;}
        T Get(int i, int j);
        IEnumerable<T> GetRow(int i);
        IEnumerable<T> GetColumn(int j);
        IEnumerable<IEnumerable<T>> GetRows();
        void Set(int i, int j, T value);
        IMatrix<T> Times(IMatrix<T> other, Func<IEnumerable<T>, IEnumerable<T>, T> func);
    }
}
