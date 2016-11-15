using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.PrimitiveTypes
{
    // EOPI 5.3
    [TestClass]
    public class ReverseBits
    {
        [TestMethod]
        public void ReverseBitsTest()
        {
            Func<int, int>[] functions = new Func<int, int>[]
            {
                ReverseBits.Swap,
                ReverseBits.Cache
            };

            for (int i = 0; i < 1000; i++)
                Tests.TestFunctions(i, functions);

            Tests.TestFunctions(int.MaxValue, functions);
        }

        private static int Swap(int x)
        {
            for(int i = 0; i < 16; i++)
            {
                int j = 31 - i;
                if (((x >> i) & 1) != ((x >> j) & 1))
                    x ^= (1 << i) | (1 << j);
            }

            return x;
        }

        private static int Cache(int x)
        {
            int[] cache = new int[] { 0, 2, 1, 3 };

            int result = 0;

            for(int i = 0; i < 16; i++)
            {
                result <<= 2;
                result |= cache[x & 3];
                x >>= 2;
            }

            return result;
        }
    }
}
