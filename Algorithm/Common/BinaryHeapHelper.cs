using System;

namespace Algorithm.Common
{
    public class BinaryHeapHelper
    {
        public static int GetParentIndex(int x)
        {
            return (x - 1) >> 1;
        }

        public static int GetLeftChildIndex(int x)
        {
            return (x << 1) + 1;
        }

        public static int GetRightChildIndex(int x)
        {
            return (x << 1) + 2;
        }
    }
}
