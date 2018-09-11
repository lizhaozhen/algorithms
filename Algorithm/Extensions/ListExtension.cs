using System;
using System.Collections.Generic;

namespace Algorithm.Extensions
{
    public static class ListExtension
    {
        public static void Swap<T>(this List<T> list, int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public static bool Less<T>(this List<T> list, int i, int j, IComparer<T> comparer)
        {
            return comparer.Compare(list[i], list[j]) < 0;
        }
    }
}
