using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace AlgorithmTests.DataStructureTests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void HeapTest()
        {
            Comparison<int> comparison = (x, y) => x.CompareTo(y);
            for(int i = 0; i < 100; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    int[] data = Utilities.ArrayUtilities.CreateRandomArray(j, 0, 1000);
                    Heap.BuildHeap(data, comparison);

                    for(int k = 0; k < data.Length; k++)
                    {
                        int left = Heap.Left(k);
                        int right = Heap.Right(k);
                        int parent = Heap.Parent(k);

                        Assert.IsTrue(k == 0 || comparison(data[k], data[parent]) <= 0);
                        Assert.IsTrue(left >= data.Length || comparison(data[left], data[k]) <= 0);
                        Assert.IsTrue(right >= data.Length || comparison(data[left], data[k]) <= 0);
                    }
                }
            }
        }
    }
}
