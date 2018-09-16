using System;
using Algorithm.DataStructure;
using Xunit;

namespace Algorithm.Tests.DataStructure
{
    public class BinayIndexTree2DTests
    {
        [Fact]
        public void BinayIndexTree2DTest()
        {
            var random = new Random();
            for(int r=1; r <= 50; r++)
            {
                for(int c = 1; c <= 50; c++)
                {
                    var tree = new BinayIndexTree2D<int>(r, c);
                    var nums = new int[r+1][];
                    for(int i=0;i<=r;i++)
                    {
                        nums[i] = new int[c+1];
                    }
                    for(int i=1;i<=r;i++)
                    {
                        for(int j=1;j<=c;j++)
                        {
                            nums[i][j] = random.Next(r*c);
                            tree.AddTo(i, j, nums[i][j]);
                        }
                    }

                    for(int i=1;i<=r;i++)
                    {
                        for(int j=1;j<=c;j++)
                        {
                            Assert.Equal(nums[i][j], tree.Get(i,j));
                        }
                    }
                }
            }
        }
    }
}
