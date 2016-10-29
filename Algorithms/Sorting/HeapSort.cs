using System;
using Algorithms.DataStructures;

namespace Algorithms.Sorting
{
    public static class HeapSort
    {
        public static void Sort(int[] data)
        {
            int heapSize = data.Length;
            Comparison<int> comparison = (x, y) => x.CompareTo(y);

            Heap.BuildHeap(data, comparison);

            for (int i = data.Length - 1; i >= 0; i--)
            {
                Utilities.Swap(data, 0, i);
                heapSize--;
                Heap.Heapify(j => data[j], (j, item) => { data[j] = item; }, 0, heapSize, comparison);
            }
        }
    }
}
