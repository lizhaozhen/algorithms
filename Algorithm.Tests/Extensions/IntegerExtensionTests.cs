using System;
using Xunit;
using Algorithm.Extensions;

namespace Algorithm.Tests.Extensions
{
    public class IntegerExtensionTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(24, 8)]
        [InlineData(int.MaxValue, 1)]
        public void GetLastBit(int x, int lastBit)
        {
            int actual = x.GetLastBit();

            Assert.Equal(actual, lastBit);
        }
    }
}
