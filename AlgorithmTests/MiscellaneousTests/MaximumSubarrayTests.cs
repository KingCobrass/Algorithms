using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Miscellaneous;
using Utilities;

namespace AlgorithmTests.MiscellaneousTests
{
    [TestClass]
    public class MaximumSubarrayTests
    {
        [TestMethod]
        public void MaximumSubarrayTest()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    int[] data = Utilities.ArrayUtilities.CreateRandomArray(j, -20, 20);

                    int expected = MaximumSubarrayTests.CalculateMaximumSubarray(data);
                    int actual = MaximumSubarray.Run(data);

                    Assert.AreEqual(expected, actual);
                }
            }
        }

        private static int CalculateMaximumSubarray(int[] data)
        {
            int maxSum = 0;

            for (int i = 0; i < data.Length; i++)
            {
                for(int j = i; j < data.Length; j++)
                {
                    int sum = 0;

                    for (int k = i; k <= j; k++)
                        sum += data[k];

                    maxSum = Math.Max(maxSum, sum);
                }
            }

            return maxSum;
        }
    }
}
