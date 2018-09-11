using System;
using System.Linq;
using Algorithm.Common;
using System.Collections.Generic;

namespace Algorithm.DataStructure
{
    public class DisjointSet : IDisjointSet
    {
        private int _setCount;
        private int[] _root;

        public DisjointSet(int size)
        {
            if(size <= 0) throw new Exception("Size should be positive.");

            _setCount = size;
            this._root = new int[size];
            for(int i=0;i<size;i++)
            {
                _root[i] = -1;
            }
        }
        
        private int GetRoot(int x)
        {
            while(_root[x] >= 0)
            {
                _root[x] = _root[_root[x]] < 0 ? _root[x] : _root[_root[x]];
                x = _root[x];
            }
            return x;
        }

        public int GetSetSize(int x)
        {
            x = GetRoot(x);
            return -_root[x];
        }

        public int SetCount {get{return _setCount;}}

        public void Union(int x, int y)
        {
            x = GetRoot(x);
            y = GetRoot(y);

            if(x == y) return;
            
            if(_root[x] > _root[y])
            {
                Utility.Swap(ref x, ref y);
            }

            _root[x] += _root[y];
            _root[y] = x;

            _setCount--;
        }

        public bool InSameSet(int x, int y)
        {
            return GetRoot(x) == GetRoot(y);
        }

        public int[][] GetSets()
        {
            return _root.Select((value, index) => new {root = GetRoot(index), index})
            .GroupBy(x => x.root, (k, g) => g.Select(x => x.index).ToArray())
            .ToArray();
        }
    }
}
