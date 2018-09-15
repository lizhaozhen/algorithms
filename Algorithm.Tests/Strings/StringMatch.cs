using System;
using System.Text;
using Xunit;

namespace Algorithm.Tests.Strings
{
    public class StringMatch
    {
        [Fact]
        public void EditDistanceTest()
        {
            int maxLen = 100;
            for(int i=0;i<=maxLen;i+=13){
                for(int j=0;j<=maxLen;j+=13)
                {
                    var first = GenerateRandomString(i);
                    var second = GenerateRandomString(j);

                    var expected = Naive.Algorithm.Strings.NativeStringMatch.EditDistance(first, second);
                    var actual = Algorithm.Strings.StringMatch.EditDistance(first, second);
                    
                    Assert.Equal(expected, actual);
                }
            }
        }

        [Theory]
        [InlineData("a", "bab", 2)]
        [InlineData("aaaa", "aabaa", 1)]
        [InlineData("aaaa", "aaaa", 0)]
        [InlineData("aa", "aab", 1)]
        [InlineData("aa", "baa", 1)]
        public void EditDistance_ManualCase(string first, string second, int dis)
        {
            var actual = Algorithm.Strings.StringMatch.EditDistance(first, second);

            Assert.Equal(dis, actual);
        }

        public static string GenerateRandomString(int length)
        {
            var sb = new StringBuilder();
            var random = new Random();
            for(int i=0;i<length;i++)
            {
                sb.Append((char)('a' + random.Next(26)));
            }
            return sb.ToString();
        }
    }
}
