using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public static class BucketSort
    {
        public static void Sort(int[] data, int maxValue)
        {
            List<int>[] buckets = new List<int>[10];

            for(int i = 0; i < buckets.Length; i++)
                buckets[i] = new List<int>();

            foreach(int n in data)
                buckets[10 * n / maxValue].Add(n);

            int count = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                int[] array = buckets[i].ToArray();
                InsertionSort.Sort(array);
                Array.Copy(array, 0, data, count, array.Length);
                count += array.Length;
            }
        }
    }
}
