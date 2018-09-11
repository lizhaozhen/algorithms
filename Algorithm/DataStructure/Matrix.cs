using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm.DataStructure
{
    public class Matrix<T> : IMatrix<T>
    {
        private T[][] _data;
        private int _rowCount;
        public int RowCount {get{return _rowCount;}}
        private int _columnCount;
        public int ColumnCount {get{return _columnCount;}}
        public Matrix(int rowCount, int columnCount)
        {
            _rowCount = rowCount;
            _columnCount = columnCount;
            _data = new T[rowCount][];
            for(int i=0;i<rowCount;i++)
            {
                _data[i] = new T[columnCount];
            }
        }

        public Matrix(int rowCount, int columnCount, IEnumerable<IEnumerable<T>> data) : this(rowCount, columnCount)
        {
            int i = 0;
            foreach(var row in data)
            {
                int j=0;
                foreach(var item in row)
                {
                    Set(i, j++, item);
                }
                i++;
            }
        }

        public T Get(int i, int j)
        {
            return _data[i][j];
        }

        public IEnumerable<T> GetRow(int i)
        {
            return _data[i];
        }

        public IEnumerable<T> GetColumn(int j)
        {
            for(int i=0;i<RowCount;i++)
            {
                yield return _data[i][j];
            }
        }

        public IEnumerable<IEnumerable<T>> GetRows()
        {
            for(int i=0;i<RowCount;i++)
            {
                yield return _data[i];
            }
        }

        public void Set(int i, int j, T value)
        {
            _data[i][j] = value;
        }

        public IMatrix<T> Times(IMatrix<T> other, Func<IEnumerable<T>, IEnumerable<T>, T> matrixCalculator = null)
        {
            return Times(this, other, matrixCalculator);
        }

        public static IMatrix<T> Times(IMatrix<T> a, IMatrix<T> b, Func<IEnumerable<T>, IEnumerable<T>, T> matrixCalculator = null)
        {
            if(a.ColumnCount != b.RowCount) 
            {
                throw new Exception("Column count of first matrix should equal with row count of second matrix.");
            }

            matrixCalculator = matrixCalculator ?? DefaultMatrixCalculator;
            
            var result = new Matrix<T>(a.RowCount, b.ColumnCount);

            for(int i=0;i<a.RowCount;i++){
                for(int j=0;j<b.ColumnCount;j++){
                    result.Set(i, j, matrixCalculator(a.GetRow(i), b.GetColumn(j)));
                }
            }

            return result;
        }

        public static readonly Func<IEnumerable<T>, IEnumerable<T>, T>DefaultMatrixCalculator = 
            new Func<IEnumerable<T>, IEnumerable<T>, T>((first, second) => {
                var firstIterator = first.GetEnumerator();
                var secondIterator = second.GetEnumerator();
                dynamic sum = 0;
                while(firstIterator.MoveNext() && secondIterator.MoveNext())
                {
                    dynamic firstNum = firstIterator.Current;
                    dynamic secondNum = secondIterator.Current;
                    sum += firstNum * secondNum;
                }
                return sum;
            });
    }
}
