using System;

namespace Algorithms.Sorting
{
    public static class MergeSort
    {
        public static void Sort(int[] data)
        {
            int[] copy = new int[data.Length];
            MergeSort.Sort(data, copy, 0, data.Length - 1);
        }

        private static void Sort(int[] data, int[] copy, int start, int end)
        {
            if (start >= end)
                return;

            int middle = (end - start) / 2 + start;

            MergeSort.Sort(data, copy, start, middle);
            MergeSort.Sort(data, copy, middle + 1, end);

            Array.Copy(data, start, copy, start, middle - start + 1);
            Array.Copy(data, middle + 1, copy, middle + 1, end - middle);

            int left = start;
            int right = middle + 1;
            int i = start;

            while(left <= middle && right <= end)
            {
                if(copy[right] < copy[left])
                {
                    data[i] = copy[right];
                    right++;
                }
                else
                {
                    data[i] = copy[left];
                    left++;
                }
                i++;
            }

            while(left <= middle)
            {
                data[i] = copy[left];
                left++;
                i++;
            }
        }
    }
}
