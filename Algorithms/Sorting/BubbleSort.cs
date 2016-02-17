namespace Algorithms.Sorting
{
    public static class BubbleSort
    {
        public static void Sort(int[] data)
        {
            for(int i = 0; i < data.Length; i++)
            {
                for(int j = i + 1; j < data.Length; j++)
                {
                    if (data[i] > data[j])
                        Utilities.Swap(data, i, j);
                }
            }
        }
    }
}
