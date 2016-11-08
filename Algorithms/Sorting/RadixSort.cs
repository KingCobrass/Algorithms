namespace Algorithms.Sorting
{
    public static class RadixSort
    {
        public static void Sort(int[] data, int maxValue)
        {
            int p = 1;

            while(p <= maxValue)
            {
                CountingSort.Sort(data, 10, n => (n / p) % 10);
                p *= 10;
            }
        }
    }
}
