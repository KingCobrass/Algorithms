using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures.Heap
{
    public class Heap
    {
        public static void BuildHeap(int[] data, Func<int, int, bool> isGreater)
        {
            for (int i = data.Length / 2 - 1; i >= 0; i--)
                Heap.Heapify(data, i, data.Length, isGreater);
        }

        public static void Heapify(int[] data, int i, int heapSize, Func<int, int, bool> isGreater)
        {
            int greatest = i;

            int left = Heap.Left(i);
            int right = Heap.Right(i);

            if (left < heapSize && isGreater(data[left], data[greatest]))
                greatest = left;
            if (right < heapSize && isGreater(data[right], data[greatest]))
                greatest = right;

            if(greatest != i)
            {
                Utilities.Swap(data, greatest, i);
                Heap.Heapify(data, greatest, heapSize, isGreater);
            }
        }

        public static int Left(int i)
        {
            return 2 * i + 1;
        }

        public static int Right(int i)
        {
            return Heap.Left(i) + 1;
        }

        public static int Parent(int i)
        {
            return (i - 1) / 2;
        }
    }
}
