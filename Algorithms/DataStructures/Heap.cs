using System;

namespace Algorithms.DataStructures
{
    public class Heap
    {
        public static void BuildHeap<T>(T[] data, Comparison<T> comparison)
        {
            for (int i = data.Length / 2 - 1; i >= 0; i--)
                Heap.Heapify(data, i, data.Length, comparison);
        }

        public static void Heapify<T>(T[] data, int i, int heapSize, Comparison<T> comparison)
        {
            int greatest = i;

            int left = Heap.Left(i);
            int right = Heap.Right(i);

            if (left < heapSize && comparison(data[left], data[greatest]) >= 0)
                greatest = left;
            if (right < heapSize && comparison(data[right], data[greatest]) >= 0)
                greatest = right;

            if(greatest != i)
            {
                Utilities.Swap(data, greatest, i);
                Heap.Heapify(data, greatest, heapSize, comparison);
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
