using System;
using Xunit;
using Algorithm.Common;

namespace Algorithm.Tests.Common
{
    public class BinaryHeapHelperTests
    {
        [Theory]
        [InlineData(1,0)]
        [InlineData(2,0)]
        [InlineData(3,1)]
        [InlineData(4,1)]
        [InlineData(5,2)]
        [InlineData(6,2)]
        public void GetParentIndexTest(int index, int parentIndex)
        {
            var actual = BinaryHeapHelper.GetParentIndex(index);

            Assert.Equal(parentIndex, actual);
        }

        [Theory]
        [InlineData(0,1)]
        [InlineData(1,3)]
        [InlineData(2,5)]
        public void GetLeftChildIndexTest(int index, int leftChildIndex)
        {
            var actual = BinaryHeapHelper.GetLeftChildIndex(index);

            Assert.Equal(leftChildIndex, actual);
        }

        [Theory]
        [InlineData(0,2)]
        [InlineData(1,4)]
        [InlineData(2,6)]
        public void GetRightChildIndexTest(int index, int rightChildIndex)
        {
            var actual = BinaryHeapHelper.GetRightChildIndex(index);

            Assert.Equal(rightChildIndex, actual);
        }
    }
}
