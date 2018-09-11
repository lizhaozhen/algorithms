using System;
using System.Collections.Generic;
using Algorithm.DataStructure;
using Naive.Algorithm.DataStructure;
using Xunit;
using System.Linq;

namespace Algorithm.Tests.Sets
{    public class DisjointSetTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(97)]
        [InlineData(128)]
        public void Union(int size)
        {
            var pairs = GenerateRandomPairs(size);

            IDisjointSet actual = new DisjointSet(size);
            IDisjointSet expected = new NaiveDisjointSet(size);

            foreach(var pair in pairs)
            {
                expected.Union(pair.Item1, pair.Item2);
                actual.Union(pair.Item1, pair.Item2);

                var expectedSets = expected.GetSets();
                var actualSets = actual.GetSets();
                Assert.Equal(expectedSets.Length, actualSets.Length);
                foreach(var expectedSet in expectedSets)
                {
                    var actualSet = actualSets.FirstOrDefault(x => x.Contains(expectedSet[0]));
                    Assert.Equal(expectedSet.Length, actualSet.Length);
                    Assert.True(expectedSet.All(x => actualSet.Contains(x)));
                }

                Assert.Equal(expected.SetCount, actual.SetCount);
                for(int i=0;i<size;i++)
                {
                    Assert.Equal(expected.GetSetSize(i), actual.GetSetSize(i));
                    for(int j=0;j<size;j++)
                    {
                        Assert.Equal(expected.InSameSet(i,j), actual.InSameSet(i,j));
                    }
                }
            }
        }


        public IEnumerable<Tuple<int, int>> GenerateRandomPairs(int n)
        {
            var random = new Random();
            for(int i=0;i<n;i++)
            {
                yield return new Tuple<int, int>(random.Next(n), random.Next(n));
            }
        }
    }
}
