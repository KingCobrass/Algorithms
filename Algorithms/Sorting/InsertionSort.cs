namespace Algorithms.Sorting
{
    public static class InsertionSort
    {
        public static void Sort(int[] data)
        {
            for(int i = 0; i < data.Length; i++)
            {
                int current = data[i];
                int j = i - 1;

                while (j >= 0 && data[j] > current)
                {
                    data[j + 1] = data[j];
                    j--;
                }

                data[j + 1] = current;
            }
        }
    }
}
