using System;

namespace Algorithm.Extensions
{
    public static class IntegerExtension
    {
        public static int GetLastBit(this int x)
        {
            return x & (-x);
        }
    }
}
