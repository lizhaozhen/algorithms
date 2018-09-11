using System;
using Algorithm.Extensions;
using Xunit;

namespace Algorithm.Tests.Extensions
{
    public class ArrayExtensionTests
    {
        [Fact]
        public void SwapTest()
        {
            var arr = new int[] {1, 2};

            arr.Swap(0, 1);

            Assert.Equal(2, arr[0]);
            Assert.Equal(1, arr[1]);
        }

        [Theory]
        [InlineData(1, 2, true)]
        [InlineData(1, 1, false)]
        [InlineData(2, 1, false)]
        public void LessTest(int first, int second, bool less)
        {
            var comparer = System.Collections.Generic.Comparer<int>.Default;
            var arr = new int[] {first, second};

            var actual = arr.Less(0, 1, comparer);

            Assert.Equal(less, actual);
        }
    }
}
