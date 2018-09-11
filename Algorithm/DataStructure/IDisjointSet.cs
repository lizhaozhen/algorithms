using System;
using System.Collections.Generic;

namespace Algorithm.DataStructure
{
    public interface IDisjointSet
    {
        int GetSetSize(int x);
        int SetCount{get;}
        void Union(int x, int y);
        bool InSameSet(int x, int y);
        int[][] GetSets();
    }
}
