using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Search;
using Utilities;

namespace AlgorithmTests.SearchTests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void BinarySearchTest()
        {
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    int[] data = ArrayUtilities.CreateRandomArray(j, -100, 100);
                    Array.Sort(data);

                    for(int n = -100; n <= 100; n++)
                    {
                        int index = BinarySearch.Find(data, n);

                        if (index < 0)
                            Assert.IsTrue(Array.BinarySearch(data, n) < 0);
                        else
                            Assert.AreEqual(n, data[index]);
                    }
                }
            }
        }
    }
}
