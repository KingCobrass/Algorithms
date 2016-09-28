using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.PrimitiveTypes
{
    [TestClass]
    public class SwapBits
    {
        [TestMethod]
        public void SwapBitsTest()
        {
            Func<int, int, int, int>[] functions = new Func<int, int, int, int>[]
            {
                SwapBits.BruteForce,
                SwapBits.ToggleBits
            };

            for (int a = 0; a < 32; a++)
            {
                for(int b = 0; b < 32; b++)
                {
                    for(int x = 0; x < 100; x++)
                        Tests.TestFunctions(x, a, b, functions);

                    Tests.TestFunctions(int.MaxValue, a, b, functions);
                }
            }
        }

        private static void SwapBitsTest(int x, int a, int b)
        {
            Func<int, int, int, int>[] functions = new Func<int, int, int, int>[]
            {
                SwapBits.BruteForce,
                SwapBits.ToggleBits
            };

            int[] results = new int[functions.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = functions[i](x, a, b);
                Assert.AreEqual(results[0], results[i]);
            }
        }

        private static int BruteForce(int x, int a, int b)
        {
            int mask = ~((1 << a) | (1 << b));

            int bit1 = ((x >> a) & 1) << b;
            int bit2 = ((x >> b) & 1) << a;

            return x & mask | bit1 | bit2;
        }

        private static int ToggleBits(int x, int a, int b)
        {
            if (a == b || ((x >> a) & 1) == ((x >> b) & 1))
                return x;

            return x ^ ((1 << a) | (1 << b));
        }
    }
}
