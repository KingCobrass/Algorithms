using System;

namespace Algorithms.Sorting
{
    public static class CountingSort
    {
        public static void Sort(int[] data, int maxValue)
        {
            CountingSort.Sort(data, maxValue, x => x);
        }

        public static void Sort(int[] data, int maxValue, Func<int, int> getKey)
        {
            int[] counts = new int[maxValue + 1];
            for (int i = 0; i < data.Length; i++)
                counts[getKey(data[i])]++;

            for (int i = 1; i < counts.Length; i++)
                counts[i] += counts[i - 1];

            int[] temp = new int[data.Length];

            for (int i = data.Length - 1; i >= 0; i--)
            {
                int key = getKey(data[i]);
                temp[counts[key] - 1] = data[i];
                counts[key]--;
            }

            Array.Copy(temp, data, data.Length);
        }
    }
}
