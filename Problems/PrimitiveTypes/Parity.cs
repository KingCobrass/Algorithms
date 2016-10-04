using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.PrimitiveTypes
{
    [TestClass]
    public class Parity
    {
        [TestMethod]
        public void ParityTest()
        {
            Func<int, bool>[] functions = new Func<int, bool>[]
            {
                Parity.BruteForce,
                Parity.Bits,
                Parity.Cache,
                Parity.Shift
            };

            for (int i = 0; i < 10000; i++)
                Tests.TestFunctions(i, functions);

            Tests.TestFunctions(int.MaxValue, functions);

            System.Random random = new System.Random();
            for (int i = 0; i < 100; i++)
                Tests.TestFunctions(random.Next(0, int.MaxValue), functions);
        }

        private static bool BruteForce(int x)
        {
            bool parity = true;

            while (x != 0)
            {
                parity ^= ((x & 1) == 1);
                x >>= 1;
            }

            return parity;
        }

        private static bool Bits(int x)
        {
            bool parity = true;

            while (x != 0)
            {
                parity = !parity;
                x &= (x - 1);
            }

            return parity;
        }

        private static bool Cache(int x)
        {
            bool[] cache = new bool[] { false, true, true, false };
            bool parity = true;

            for (int i = 0; i < 16; i++)
            {
                parity ^= cache[x & 3];
                x >>= 2;
            }

            return parity;
        }

        private static bool Shift(int x)
        {
            int shift = 16;

            while (shift > 0)
            {
                x ^= (x >> shift);
                shift /= 2;
            }

            return (x & 1) == 0;
        }
    }
}
