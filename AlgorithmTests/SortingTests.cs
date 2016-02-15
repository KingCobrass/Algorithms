using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting;

namespace AlgorithmTests
{
    [TestClass]
    public class SortingTests
    {
        private const int MaxValue = 1000;

        [TestMethod]
        public void BubbleSortTest()
        {
            SortingTests.TestSortingAlgorithm(BubbleSort.Sort);
        }

        [TestMethod]
        public void CountingSortTest()
        {
            SortingTests.TestSortingAlgorithm(data => CountingSort.Sort(data, SortingTests.MaxValue));
        }

        [TestMethod]
        public void InsertionSortTest()
        {
            SortingTests.TestSortingAlgorithm(InsertionSort.Sort);
        }

        [TestMethod]
        public void MergeSortTest()
        {
            SortingTests.TestSortingAlgorithm(MergeSort.Sort);
        }

        [TestMethod]
        public void QuickSortTest()
        {
            SortingTests.TestSortingAlgorithm(QuickSort.Sort);
        }

        private static void TestSortingAlgorithm(Action<int[]> sortingAlgorithm)
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    int[] data = new int[j];
                    for (int k = 0; k < data.Length; k++)
                        data[k] = random.Next(0, SortingTests.MaxValue);

                    SortingTests.TestSortingAlgorithm(sortingAlgorithm, data);
                }
            }
        }

        private static void TestSortingAlgorithm(Action<int[]> sortingAlgorithm, int[] data)
        {
            int[] copy = new int[data.Length];
            Array.Copy(data, copy, data.Length);

            sortingAlgorithm(data);
            Array.Sort(copy);

            Assert.AreEqual(data.Length, copy.Length);
            for (int i = 0; i < data.Length; i++)
                Assert.AreEqual(data[i], copy[i]);
        }
    }
}
