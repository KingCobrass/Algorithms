using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.DynamicProgrammimg
{
    // EOPI 17.1
    [TestClass]
    public class ScoreCombinations
    {
        [TestMethod]
        public void ScoreCombinationTest()
        {
            Func<int, int>[] functions = new Func<int, int>[]
            {
                ScoreCombinations.BruteForce,
                ScoreCombinations.DynamicProgramming
            };

            for(int i = 0; i < 40; i++)
                Tests.TestFunctions(i, functions);
        }

        private static int BruteForce(int score)
        {
            int count = 0;

            for (int i = 0; i <= score; i += 2)
            {
                for(int j = i; j <= score; j += 3)
                {
                    for(int k = j; k <= score; k += 7)
                    {
                        if (k == score)
                            count++;
                    }
                }
            }

            return count;
        }

        private static int DynamicProgramming(int score)
        {
            int[] data = new int[] { 2, 3, 7 };
            int[,] counts = new int[data.Length, score + 1];

            counts[0, 0] = 1;

            for(int i = 0; i < data.Length; i++)
            {
                for(int j = 0; j <= score; j++)
                {
                    if (i > 0)
                        counts[i, j] += counts[i - 1, j];
                    if (j >= data[i])
                        counts[i, j] += counts[i, j - data[i]];
                }
            }

            return counts[data.Length - 1, score];
        }
    }
}
