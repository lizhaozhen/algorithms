using System;
using System.Collections.Generic;
using System.Linq;
using Algorithm.DataStructure;

namespace Naive.Algorithm.DataStructure
{
    public class NaiveDisjointSet : IDisjointSet
    {
        private int[] root;
        public NaiveDisjointSet(int size)
        {
            root = new int[size];
            for(int i=0;i<size;i++)
            {
                root[i] = i;
            }
        }

        public int SetCount => root.Select((v, i) => v == i).Count(x => x);

        private int GetRoot(int x)
        {
            if(root[x] == x) return x;
            return GetRoot(root[x]);
        }

        public int GetSetSize(int x)
        {
            int cnt = 0;
            x = GetRoot(x);
            for(int i=0;i<root.Length;i++)
            {
                if(GetRoot(i) == x)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public bool InSameSet(int x, int y)
        {
            return GetRoot(x) == GetRoot(y);
        }

        public void Union(int x, int y)
        {
            x = GetRoot(x);
            y = GetRoot(y);
            if(x != y)
            {
                for(int i=0;i<root.Length;i++)
                {
                    if(root[i] == x)
                    {
                        root[i] = y;
                    }
                }
            }
        }

        public int[][] GetSets()
        {
            var results = new List<int[]>();
            for(int i=0;i<root.Length;i++)
            {
                if(i == GetRoot(i))
                {
                    var result = new List<int>();
                    for(int j=0;j<root.Length;j++)
                    {
                        if(GetRoot(j) == i)
                        {
                            result.Add(j);
                        }
                    }
                    results.Add(result.ToArray());
                }
            }
            return results.ToArray();
        }
    }
}
