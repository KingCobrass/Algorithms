namespace Algorithms.Sorting
{
    public static class SortingUtilities
    {
        public static void Swap(int[] data, int a, int b)
        {
            int temp = data[a];
            data[a] = data[b];
            data[b] = temp;
        }
    }
}
