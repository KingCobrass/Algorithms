using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Arrays
{
    [TestClass]
    public class BuySellOnce
    {
        [TestMethod]
        public void BuySellOnceTest()
        {
            for (int i = 0; i < 10; i++)
            {
                int[] prices = RandomArray.Generate(30, 1, 100);
                Tests.TestFunctions(prices, BuySellOnce.BruteForce, BuySellOnce.SinglePass);
            }
        }

        private static int BruteForce(int[] prices)
        {
            int maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                for (int j = i + 1; j < prices.Length; j++)
                    maxProfit = Math.Max(maxProfit, prices[j] - prices[i]);
            }

            return maxProfit;
        }

        private static int SinglePass(int[] prices)
        {
            int maxProfit = 0;
            int minPrice = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                minPrice = Math.Min(minPrice, prices[i]);
                maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
            }

            return maxProfit;
        }
    }
}
