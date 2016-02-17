namespace Algorithms.Sorting
{
    public static class QuickSort
    {
        public static void Sort(int[] data)
        {
            QuickSort.Sort(data, 0, data.Length - 1);
        }

        private static void Sort(int[] data, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = start - 1;

            for(int i = start; i <= end; i++)
            {
                if(data[i] <= data[end])
                {
                    pivot++;
                    Utilities.Swap(data, i, pivot);
                }
            }

            QuickSort.Sort(data, start, pivot - 1);
            QuickSort.Sort(data, pivot + 1, end);
        }
    }
}
