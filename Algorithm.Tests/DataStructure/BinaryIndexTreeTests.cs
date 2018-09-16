using System;
using Xunit;
using Algorithm.DataStructure;

namespace Algorithm.Tests.DataStructure
{
    public class BinaryIndexTreeTests
    {
        [Fact]
        public void BinaryIndexTreeTest()
        {
            var random = new Random();
            for(int i=1; i<= 64; i++)
            {
                var binaryIndexTree = new BinaryIndexTree<int>(i);

                var nums = new int[i+1];
                for(int j=1;j<=i;j++)
                {
                    var num = random.Next(i);
                    nums[j] = num;
                    binaryIndexTree.AddTo(j, num);
                }

                for(int j=1;j<=i;j++)
                {
                    Assert.Equal(nums[j], binaryIndexTree.Get(j));
                    var sum = 0;
                    for(int k=j;k<=i;k++)
                    {
                        sum += nums[k];
                        Assert.Equal(sum, binaryIndexTree.GetRangeSum(j, k));
                    }
                }
            }
        }
    }
}
