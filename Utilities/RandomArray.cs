namespace Utilities
{
    public static class RandomArray
    {
        public static int[] Generate(int length, int minValue, int maxValue)
        {
            System.Random random = new System.Random();
            int[] data = new int[length];
            for (int k = 0; k < data.Length; k++)
                data[k] = random.Next(minValue, maxValue);

            return data;
        }
    }
}
