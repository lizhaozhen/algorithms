using System;

namespace Algorithm.Strings
{
    public class StringMatch
    {
        public static int EditDistance(string first, string second)
        {
            if(string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second)) return 0;

            if(string.IsNullOrEmpty(first)) return second.Length;

            if(string.IsNullOrEmpty(second)) return first.Length;

            var cur = new int[second.Length + 1];
            for(int i=0; i<=second.Length; i++) cur[i] = i;

            for(int i=0; i<first.Length; i++)
            {
                var next = new int[second.Length + 1];
                next[0] = cur[0] + 1;
                for(int j=1; j<=second.Length; j++)
                {
                    next[j] = System.Math.Min(
                        System.Math.Min(cur[j] + 1, next[j-1] + 1), 
                        cur[j-1] + (first[i] == second[j-1] ? 0 : 1));
                }
                cur = next;
            }

            return cur[second.Length];
        }
    }
}
