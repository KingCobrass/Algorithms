using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DynamicProgramming;
using Utilities;

namespace AlgorithmTests.DynamicProgrammingTests
{
    [TestClass]
    public class RodCuttingTests
    {
        [TestMethod]
        public void RodCuttingTest()
        {
            RodCuttingTests.RodCuttingTest(new int[] { 0, 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 });

            for(int i = 0; i < 10; i++)
            {
                for(int j = 1; j < 10; j++)
                {
                    int[] data = Utilities.RandomArray.Generate(j, 1, 10);
                    int[] prices = new int[data.Length + 1];
                    for (int k = 0; k < data.Length; k++)
                        prices[k + 1] = prices[k] + data[k];

                    RodCuttingTests.RodCuttingTest(prices);
                }
            }
        }

        private static void RodCuttingTest(int[] prices)
        {
            int[] expected = RodCuttingTests.MaximumRevenues(prices);
            int[] actual = RodCutting.MaximumRevenues(prices);

            Assert.AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);

            return;
        }

        private static int[] MaximumRevenues(int[] prices)
        {
            int[] revenues = new int[prices.Length];

            for (int i = 1; i < prices.Length; i++)
                revenues[i] = RodCuttingTests.MaximumRevenue(i, prices);

            return revenues;
        }

        private static int MaximumRevenue(int length, int[] prices)
        {
            int revenue = prices[length];
            for (int i = 1; i < length; i++)
                revenue = Math.Max(revenue, prices[i] + RodCuttingTests.MaximumRevenue(length - i, prices));

            return revenue;
        }
    }
}
