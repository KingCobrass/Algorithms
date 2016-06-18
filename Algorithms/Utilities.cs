namespace Algorithms
{
    public static class Utilities
    {
        public static void Swap<T>(T[] data, int a, int b)
        {
            T temp = data[a];
            data[a] = data[b];
            data[b] = temp;
        }
    }
}
