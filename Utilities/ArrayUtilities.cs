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
            System.Random random = new System.Random();
            int[] data = new int[length];
            for (int k = 0; k < data.Length; k++)
                data[k] = random.Next(minValue, maxValue);

            return data;
        }
    }
}
