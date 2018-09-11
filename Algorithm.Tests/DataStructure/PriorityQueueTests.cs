using System;
using Xunit;
using Algorithm.DataStructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Algorithm.Tests.Collections
{
    public class PriorityQueueTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(50, 2)]
        [InlineData(100, 5)]
        [InlineData(1000, 7)]
        public void PriorityQueueTest(int size, int rate)
        {
            var items = GenerateRandomList(size, rate);
            var expected = new Naive.Algorithm.DataStructure.NaivePriorityQueue<int>();
            var actual = new PriorityQueue<int>();

            foreach(var item in items)
            {
                if(item > 0)
                {
                    expected.Add(item);
                    actual.Add(item);

                    Assert.Equal(expected.Count, actual.Count);
                    Assert.Equal(expected.Peek(), actual.Peek());
                }
                else
                {
                    Assert.Equal(expected.IsEmpty(), actual.IsEmpty());

                    if(expected.IsEmpty())
                    {
                        Assert.Throws<ArgumentOutOfRangeException>(() => expected.Peek());
                        Assert.Throws<ArgumentOutOfRangeException>(() => actual.Peek());

                        Assert.Throws<ArgumentOutOfRangeException>(() => expected.Pop());
                        Assert.Throws<ArgumentOutOfRangeException>(() => actual.Pop());
                    }
                    else
                    {
                        Assert.Equal(expected.Pop(), expected.Pop());

                        if(!expected.IsEmpty())
                        {
                            Assert.Equal(expected.Peek(), actual.Peek());
                        }
                    }
                }
            }
        }



        public List<int> GenerateRandomList(int size, int rate)
        {
            var list = new List<int>();
            var random = new Random();
            for(int i=0;i<size;i++)
            {
                var r = random.Next();
                list.Add(random.Next(rate + 1) > 0 ? r : -r);
            }
            return list;
        }
    }
}
