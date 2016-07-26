using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Mathematical;

namespace AlgorithmTests.MathematicalTests
{
    [TestClass]
    public class EuclidGCDTests
    {
        [TestMethod]
        public void TestGCD()
        {
            for(int a = 0; a < 100; a++)
            {
                for(int b = 0; b < 100; b++)
                {
                    int expected = EuclidGCDTests.CalculateGCD(a, b);
                    int actual = EuclidGCD.Run(a, b);

                    Assert.AreEqual(expected, actual);
                }
            }
        }

        private static int CalculateGCD(int a, int b)
        {
            for(int i = Math.Max(a, b); i > 0; i--)
            {
                if (a % i == 0 && b % i == 0)
                    return i;
            }

            return 0;
        }
    }
}
