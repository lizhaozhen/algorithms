using System;
using Xunit;
using Algorithm.DataStructure;
using System.Collections.Generic;

namespace Algorithm.Tests.DataStructure
{
    public class BinaryHeapTests
    {
        [Fact]
        public void AddTest()
        {
            var heap = new BinaryHeap<int>(new List<int>{1,2,3});

            Assert.Equal(3, heap.Count);
            Assert.Equal(1, heap[0]);
            Assert.Equal(2, heap[1]);
            Assert.Equal(3, heap[2]);
        }

        [Fact]
        public void ClearTest()
        {
            var heap = new BinaryHeap<int>(new List<int>{1, 2, 3});

            heap.Clear();

            Assert.Equal(0, heap.Count);
        }

        [Fact]
        public void IsEmptyTest()
        {
            var heap = new BinaryHeap<int>();
            Assert.True(heap.IsEmpty());

            heap.Add(1);
            Assert.False(heap.IsEmpty());
        }

        [Fact]
        public void Sink_Left()
        {
            var heap = new BinaryHeap<int>(new List<int>{3,1,2});

            heap.Sink(0);

            Assert.Equal(1, heap[0]);
            Assert.Equal(3, heap[1]);
            Assert.Equal(2, heap[2]);
        }

        [Fact]
        public void Sink_Right()
        {
            var heap = new BinaryHeap<int>(new List<int>{3,2,1});

            heap.Sink(0);

            Assert.Equal(1, heap[0]);
            Assert.Equal(2, heap[1]);
            Assert.Equal(3, heap[2]);
        }

        [Fact]
        public void Sink_TwoLevels()
        {
            var heap = new BinaryHeap<int>(new List<int>{5, 3, 2, 1, 2, 1, 3});

            heap.Sink(0);

            Assert.Equal(2, heap[0]);
            Assert.Equal(3, heap[1]);
            Assert.Equal(1, heap[2]);
            Assert.Equal(5, heap[5]);
        }

        [Fact]
        public void Popup()
        {
            var heap = new BinaryHeap<int>(new List<int>{3,2,1});
            
            heap.Popup(2);

            Assert.Equal(1, heap[0]);
            Assert.Equal(2, heap[1]);
            Assert.Equal(3, heap[2]);
        }

        [Fact]
        public void Popup_TwoLevels()
        {
            var heap = new BinaryHeap<int>(new List<int>{5, 3, 2, 1, 2, 1, 3});

            heap.Popup(5);

            Assert.Equal(1, heap[0]);
            Assert.Equal(3, heap[1]);
            Assert.Equal(5, heap[2]);
            Assert.Equal(2, heap[5]);
        }

        [Fact]
        public void PeekTest()
        {
            var heap = new BinaryHeap<int>(new List<int>{3,2,1});

            var top = heap.Peek();

            Assert.Equal(3, top);
        }

        [Fact]
        public void PopTest()
        {
            var heap = new BinaryHeap<int>(new List<int>{3,2,1});

            var top = heap.Pop();

            Assert.Equal(3, top);
            Assert.Equal(1, heap.Pop());
        }
    }
}
