using System;
using Algorithm.DataStructure;
using Xunit;
using System.Collections.Generic;

namespace Algorithm.Tests.DataStructure
{
    public class MatrixTests
    {
        [Fact]
        public void GetSet()
        {
            var matrix = GenerateMatrix();

            var value = 123;
            matrix.Set(1,1,value);

            Assert.Equal(value, matrix.Get(1,1));
        }

        [Fact]
        public void Times()
        {
            var first = new Matrix<int>(1, 2);
            first.Set(0, 0, 3);
            first.Set(0, 1, 5);
            var second = GenerateMatrix();

            var result = first.Times(second);

            Assert.Equal(1, result.RowCount);
            Assert.Equal(2, result.ColumnCount);
            Assert.Equal(5, result.Get(0, 0));
            Assert.Equal(8, result.Get(0, 1));
        }

        [Fact]
        public void Times_Double()
        {
            var first = new Matrix<Double>(1, 2);
            first.Set(0, 0, 3);
            first.Set(0, 1, 5);
            var second = GenerateMatrix_Double();

            var result = first.Times(second);

            Assert.Equal(1, result.RowCount);
            Assert.Equal(2, result.ColumnCount);
            Assert.Equal(5, result.Get(0, 0));
            Assert.Equal(8, result.Get(0, 1));
        }

        public static Matrix<int> GenerateMatrix()
        {
            return new Matrix<int>(2, 2, new List<IEnumerable<int>>{
                new List<int>{0, 1},
                new List<int>{1, 1}
            });
        }

        public static Matrix<Double> GenerateMatrix_Double()
        {
            return new Matrix<Double>(2, 2, new List<IEnumerable<Double>>{
                new List<Double>{0, 1},
                new List<Double>{1, 1}
            });
        }
    }
}
