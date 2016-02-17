using System;
using Algorithms.DataStructures.Heap;

namespace Algorithms.Sorting
{
    public static class HeapSort
    {
        public static void Sort(int[] data)
        {
            int heapSize = data.Length;
            Func<int, int, bool> isGreater = (x, y) => x > y;

            Heap.BuildHeap(data, isGreater);

            for (int i = data.Length - 1; i >= 0; i--)
            {
                Utilities.Swap(data, 0, i);
                heapSize--;
                Heap.Heapify(data, 0, heapSize, isGreater);
            }
        }
    }
}
