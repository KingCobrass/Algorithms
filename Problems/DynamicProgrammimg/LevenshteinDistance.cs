using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.DynamicProgrammimg
{
    // EOPI 17.2
    [TestClass]
    public class LevenshteinDistance
    {
        [TestMethod]
        public void LevenshteinDistanceTest()
        {
            Func<string, string, int>[] functions = new Func<string, string, int>[]
            {
                (a, b) => 8,
                LevenshteinDistance.BottomUp,
                LevenshteinDistance.TopDown
            };

            Tests.TestFunctions("carthorse", "orchestra", functions);
        }

        private static int BottomUp(string a, string b)
        {
            int[,] distances = new int[a.Length + 1, b.Length + 1];

            for(int i = 0; i <= a.Length; i++)
            {
                for(int j = 0; j <= b.Length; j++)
                {
                    if (i == 0)
                        distances[i, j] = j;
                    else if (j == 0)
                        distances[i, j] = i;
                    else if (a[i - 1] == b[j - 1])
                        distances[i, j] = distances[i - 1, j - 1];
                    else
                    {
                        int distance = Math.Min(distances[i - 1, j], distances[i, j - 1]);
                        distance = Math.Min(distance, distances[i - 1, j - 1]);
                        distances[i, j] = distance + 1;
                    }
                }
            }

            return distances[a.Length, b.Length];
        }

        private static int TopDown(string a, string b)
        {
            int[,] distances = new int[a.Length + 1, b.Length + 1];
            return LevenshteinDistance.TopDown(a, b, distances, a.Length, b.Length);
        }

        private static int TopDown(string a, string b, int[,] distances, int i, int j)
        {
            if (i == 0)
                return j;
            if (j == 0)
                return i;

            if(distances[i, j] != -1)
            {
                if (a[i - 1] == b[j - 1])
                    distances[i, j] = LevenshteinDistance.TopDown(a, b, distances, i - 1, j - 1);
                else
                {
                    int distance = LevenshteinDistance.TopDown(a, b, distances, i - 1, j);
                    distance = Math.Min(distance, LevenshteinDistance.TopDown(a, b, distances, i, j - 1));
                    distance = Math.Min(distance, LevenshteinDistance.TopDown(a, b, distances, i - 1, j - 1));

                    distances[i, j] = distance + 1;
                }
            }

            return distances[i, j];
        }
    }
}
