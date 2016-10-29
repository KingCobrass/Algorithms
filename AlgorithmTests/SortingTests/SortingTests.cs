using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Algorithms.Sorting;
using Utilities;

namespace AlgorithmTests.SortingTests
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
        public void BucketSortTest()
        {
            SortingTests.TestSortingAlgorithm(data => BucketSort.Sort(data, SortingTests.MaxValue));
        }

        [TestMethod]
        public void CountingSortTest()
        {
            SortingTests.TestSortingAlgorithm(data => CountingSort.Sort(data, SortingTests.MaxValue));
        }

        [TestMethod]
        public void HeapSortTest()
        {
            SortingTests.TestSortingAlgorithm(HeapSort.Sort);
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

        [TestMethod]
        public void RadixSortTest()
        {
            SortingTests.TestSortingAlgorithm(data => RadixSort.Sort(data, SortingTests.MaxValue));
        }

        [TestMethod]
        public void BinaryTreeSortTest()
        {
            SortingTests.TestSortingAlgorithm(
                data =>
                {
                    BinarySearchTree tree = new BinarySearchTree();
                    foreach (int x in data)
                        tree.Add(x);

                    int i = 0;
                    foreach (int x in tree.Values)
                    {
                        data[i] = x;
                        i++;
                    }
                });
        }

        private static void TestSortingAlgorithm(Action<int[]> sortingAlgorithm)
        {
            System.Random random = new System.Random();

            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    int[] data = ArrayUtilities.CreateRandomArray(j, 0, SortingTests.MaxValue);
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
