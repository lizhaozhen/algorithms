using System;
using Algorithm.Math;
using Xunit;

namespace Algorithm.Tests.Math
{
    public class EuclideanAlgorithmTests
    {
        [Theory]
        [InlineData(15,0,15)]
        [InlineData(0,15,15)]
        [InlineData(3,15,3)]
        [InlineData(15,5,5)]
        [InlineData(15,15,15)]
        public void GreatestCommonDivisor_Int(int x, int y, int gcd)
        {
            int actual = EuclideanAlgorithm.GreatestCommonDivisor(x, y);

            Assert.Equal(gcd, actual);
        }

        [Theory]
        [InlineData(15,0,15)]
        [InlineData(0,15,15)]
        [InlineData(3,15,3)]
        [InlineData(15,5,5)]
        [InlineData(15,15,15)]
        public void GreatestCommonDivisor_Long(long x, long y, long gcd)
        {
            long actual = EuclideanAlgorithm.GreatestCommonDivisor(x, y);

            Assert.Equal(gcd, actual);
        }

        [Theory]
        [InlineData(15,0,0)]
        [InlineData(0,15,0)]
        [InlineData(3,15,15)]
        [InlineData(15,5,15)]
        [InlineData(15,15,15)]
        public void LeastCommonMultiple_Int(int x, int y, int lcm)
        {
            int actual = EuclideanAlgorithm.LeastCommonMultiple(x, y);

            Assert.Equal(lcm, actual);
        }

        [Theory]
        [InlineData(15,0,0)]
        [InlineData(0,15,0)]
        [InlineData(3,15,15)]
        [InlineData(15,5,15)]
        [InlineData(15,15,15)]
        public void LeastCommonMultiple_Long(long x, long y, long lcm)
        {
            long actual = EuclideanAlgorithm.LeastCommonMultiple(x, y);

            Assert.Equal(lcm, actual);
        }

        [Theory]
        [InlineData(47, 30, -7, 11, 1)]
        [InlineData(15, 3, 0, 1, 3)]
        [InlineData(12, 8, 1, -1, 4)]
        [InlineData(3, 5, 2, -1, 1)]
        public void ExtendedGreatestCommonDivisor(int a, int b, int x, int y, int gcd)
        {
            var res = EuclideanAlgorithm.ExtendedGreatestCommonDivisor(a, b);

            Assert.Equal(x, res.Item1);
            Assert.Equal(y, res.Item2);
            Assert.Equal(gcd, res.Item3);
        }
    }
}
