using System;
using Xunit;
using Algorithm.Common;

namespace Algorithm.Tests
{
    public class UtilityTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(int.MaxValue, int.MinValue)]
        public void Swap_Struct(int a, int b)
        {
            int ta = a;
            int tb = b;

            Utility.Swap(ref a, ref b);

            Assert.Equal(ta, b);
            Assert.Equal(tb, a);
        }

        [Fact]
        public void Swap_Object()
        {
            var a = new object();
            var b = new object();

            var x = a;
            var y = b;
            Utility.Swap(ref a, ref b);

            Assert.Equal(a, y);
            Assert.NotEqual(a, x);
            Assert.Equal(b, x);
            Assert.NotEqual(b, y);
        }
    }
}
