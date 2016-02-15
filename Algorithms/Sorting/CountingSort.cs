namespace Algorithms.Sorting
{
    public static class CountingSort
    {
        public static void Sort(int[] data, int maxValue)
        {
            int[] counts = new int[maxValue + 1];
            for (int i = 0; i < data.Length; i++)
                counts[data[i]]++;

            int j = 0;

            for(int i = 0; i < data.Length; i++)
            {
                while (counts[j] == 0)
                    j++;

                data[i] = j;
                counts[j]--;
            }
        }
    }
}
