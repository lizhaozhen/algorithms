using System;
using System.Linq;
using Xunit;

namespace Algorithm.Tests.Math
{
    public class PrimeTests
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(97, true)]
        public void IsPrimeTest(int num, bool isPrime)
        {
            var actual = Algorithm.Math.Prime.IsPrime(num);

            Assert.Equal(isPrime, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(10000)]
        [InlineData(100000)]
        public void ArePrimesTest(int num)
        {
            var arePrimes = Algorithm.Math.Prime.ArePrimes(num);

            for(int i=0;i<=num;i++)
            {
                Assert.Equal(Algorithm.Math.Prime.IsPrime(i), arePrimes[i]);
            }
        }

        [Fact]
        public void GetPrimesTest()
        {
            int num = 100;
            var primes = Algorithm.Math.Prime.GetPrimes(num).ToList();

            for(int i=0;i<=num;i++)
            {
                Assert.Equal(Algorithm.Math.Prime.IsPrime(i), primes.Contains(i));
            }
        }
    }
}
