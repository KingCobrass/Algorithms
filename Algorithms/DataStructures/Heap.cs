using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class Heap
    {
        public static void BuildHeap<T>(T[] data, Comparison<T> comparison)
        {
            for (int i = data.Length / 2 - 1; i >= 0; i--)
                Heap.Heapify(j => data[j], (j, item) => { data[j] = item; }, i, data.Length, comparison);
        }

        public static void Heapify<T>(Func<int, T> get, Action<int, T> set, int i, int count, Comparison<T> comparison)
        {
            int highest = i;

            while(true)
            {
                int left = Heap.Left(i);

                if (left < count && comparison(get(left), get(highest)) > 0)
                    highest = left;

                int right = Heap.Right(i);

                if (right < count && comparison(get(right), get(highest)) > 0)
                    highest = right;

                if (i == highest)
                    return;

                T temp = get(highest);
                set(highest, get(i));
                set(i, temp);

                i = highest;
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
