using System;
using System.Linq;
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
        public void SortingTest()
        {
            Action<int[]>[] actions = new Action<int[]>[]
            {
                BubbleSort.Sort,
                data => BucketSort.Sort(data, SortingTests.MaxValue),
                data => CountingSort.Sort(data, SortingTests.MaxValue),
                HeapSort.Sort,
                InsertionSort.Sort,
                MergeSort.Sort,
                QuickSort.Sort,
                data => RadixSort.Sort(data, SortingTests.MaxValue),
            };

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    int[] data = ArrayUtilities.CreateRandomArray(j, 0, SortingTests.MaxValue);
                    int[][] results = new int[actions.Length][];

                    for (int k = 0; k < actions.Length; k++)
                    {
                        results[k] = new int[data.Length];
                        Array.Copy(data, results[k], data.Length);

                        actions[k](results[k]);
                        Assert.IsTrue(ArrayUtilities.AreEqual(results[k], results[0]));
                    }
                }
            }
        }
    }
}
