using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTests
{
    public static class TestUtilities
    {
        public static int[] GenerateRandomArray(int length, int minValue, int maxValue)
        {
            Random random = new Random();
            int[] data = new int[length];
            for (int k = 0; k < data.Length; k++)
                data[k] = random.Next(minValue, maxValue);

            return data;
        }

        public static void SetRandomEdge(bool[,] graph, int n)
        {
            bool found = false;
            int i = 0;
            int j = 0;

            int count = 0;
            Random random = new Random();

            for (int k = 0; k < n; k++)
            {
                for (int l = 0; l < n; l++)
                {
                    if (graph[k, l])
                        continue;

                    count++;

                    if (random.Next(0, count) == 0)
                    {
                        found = true;
                        i = k;
                        j = l;
                    }
                }
            }

            if (found)
                graph[i, j] = true;
        }
    }
}
