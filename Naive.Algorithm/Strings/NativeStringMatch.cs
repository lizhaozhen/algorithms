using System;
using System.Collections.Generic;

namespace Naive.Algorithm.Strings
{
    public class NativeStringMatch
    {
        protected static Dictionary<Tuple<int, int>, int> EditDistanceDict = new Dictionary<Tuple<int, int>, int>();

        public static int EditDistance(string first, string second)
        {
            if(string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second)) return 0;

            if(string.IsNullOrEmpty(first)) return second.Length;

            if(string.IsNullOrEmpty(second)) return first.Length;
            EditDistanceDict.Clear();
            return EditDistance(first, second, first.Length, second.Length);
        }

        private static int EditDistance(string first, string second, int firstLen, int secondLen)
        {
            if(firstLen == 0) return secondLen;
            if(secondLen == 0) return firstLen;

            var tuple = new Tuple<int, int>(firstLen, secondLen);
            if(EditDistanceDict.ContainsKey(tuple)) return EditDistanceDict[tuple];

            var dis = System.Math.Min(
                System.Math.Min(EditDistance(first, second, firstLen-1, secondLen),
                    EditDistance(first, second, firstLen, secondLen-1)) + 1,
                EditDistance(first, second, firstLen-1, secondLen-1) + 
                    (first[firstLen-1] == second[secondLen-1] ? 0 : 1)
            );
            return EditDistanceDict[tuple] = dis;
        }
    }
}
