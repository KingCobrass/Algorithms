using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.BitManipulation
{
    // CTCI 5.1
    [TestClass]
    public class Insertion
    {
        [TestMethod]
        public void InsertionTest()
        {
            Func<int, int, int, int, int>[] functions = new Func<int, int, int, int, int>[]
            {
                Insertion.Mask1,
                Insertion.Mask2
            };

            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                for (int j = i; j < 8; j++)
                {
                    int N = random.Next(0, 128);
                    int M = random.Next(0, 1 << (j - i + 1) - 1);

                    Tests.TestFunctions(N, M, i, j, functions);
                }
            }
        }

        private static int Mask1(int N, int M, int i, int j)
        {
            int mask = (1 << (j + 1)) - (1 << (i + 1));
            return (N & ~mask) | ((M << j) & mask);
        }

        private static int Mask2(int N, int M, int i, int j)
        {
            int mask = (~0 << (j + 1)) | ((1 << i + 1) - 1);
            return (N & mask) | ((M << j) & ~mask);
        }
    }
}
