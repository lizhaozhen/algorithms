using System;
using Xunit;
using Algorithm.Extensions;
using System.Collections.Generic;

namespace Algorithm.Tests.Extensions
{
    public class ListExtensionTests
    {
        [Fact]
        public void SwapTest()
        {
            var list = new List<int>{1, 2};

            list.Swap(0, 1);

            Assert.Equal(2, list[0]);
            Assert.Equal(1, list[1]);
        }

        [Theory]
        [InlineData(1, 2, true)]
        [InlineData(1, 1, false)]
        [InlineData(2, 1, false)]
        public void LessTest(int first, int second, bool less)
        {
            var comparer = System.Collections.Generic.Comparer<int>.Default;
            var list = new List<int> {first, second};

            var actual = list.Less(0, 1, comparer);

            Assert.Equal(less, actual);
        }
    }
}
