using System;
using System.Collections.Generic;

namespace Utilities
{
    public static class ArrayUtilities
    {
        public static void Swap<T>(T[] data, int a, int b)
        {
            T temp = data[a];
            data[a] = data[b];
            data[b] = temp;
        }

        public static int[] CreateRandomArray(int length, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] data = new int[length];
            for (int k = 0; k < data.Length; k++)
                data[k] = random.Next(minValue, maxValue);

            return data;
        }

        public static bool AreEqual<T>(T[] a, T[] b)
        {
            if (a.Length != b.Length)
                return false;

            for(int i = 0; i < a.Length; i++)
            {
                if (!a[i].Equals(b[i]))
                    return false;
            }

            return true;
        }

        public static int[] CreateRandomPermutation(int n)
        {
            List<int> list = new List<int>();
            Random random = new Random();
            while (n > 0)
            {
                n--;
                list.Insert(random.Next(0, list.Count + 1), n);
            }

            return list.ToArray();
        }
    }
}
