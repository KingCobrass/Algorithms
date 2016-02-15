using System;

namespace Algorithms.Sorting
{
    public static class MergeSort
    {
        public static void Sort(int[] data)
        {
            MergeSort.Sort(data, 0, data.Length - 1);
        }

        private static void Sort(int[] data, int start, int end)
        {
            if (start >= end)
                return;

            int middle = (end - start) / 2 + start;

            MergeSort.Sort(data, start, middle);
            MergeSort.Sort(data, middle + 1, end);

            int[] left = new int[middle - start + 1];
            Array.Copy(data, start, left, 0, left.Length);

            int[] right = new int[end - middle];
            Array.Copy(data, middle + 1, right, 0, right.Length);

            int leftIndex = 0;
            int rightIndex = 0;

            for(int i = start; i <= end; i++)
            {
                if(leftIndex == left.Length || (rightIndex != right.Length && right[rightIndex] < left[leftIndex]))
                {
                    data[i] = right[rightIndex];
                    rightIndex++;
                }
                else
                {
                    data[i] = left[leftIndex];
                    leftIndex++;
                }
            }
        }
    }
}
