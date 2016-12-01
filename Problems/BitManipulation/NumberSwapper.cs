using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems.BitManipulation
{
    [TestClass]
    public class NumberSwapper
    {
        // CTCI 16.1
        [TestMethod]
        public void NumberSwapperTest()
        {
            for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    int a = i;
                    int b = j;
                    NumberSwapper.Toggle(ref a, ref b);
                    Assert.AreEqual(a, j);
                    Assert.AreEqual(b, i);
                }
            }
        }

        private static void Toggle(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
    }
}
