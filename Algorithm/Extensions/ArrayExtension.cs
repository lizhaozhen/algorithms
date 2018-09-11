using System;
using Algorithm.Common;
using System.Collections.Generic;

namespace Algorithm.Extensions
{
    public static class ArrayExtension
    {
        public static void Swap<T>(this T[] arr, int i, int j)
        {
            Utility.Swap(ref arr[i], ref arr[j]);
        }

        public static bool Less<T>(this T[] arr, int i, int j, IComparer<T> comparer)
        {
            return comparer.Compare(arr[i], arr[j]) < 0;
        }
    }
}
