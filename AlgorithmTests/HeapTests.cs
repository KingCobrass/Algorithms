using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures.Heap;

namespace AlgorithmTests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void HeapTest()
        {
            Func<int, int, bool> isGreater = (x, y) => x > y;
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    int[] data = TestUtilities.GenerateRandomArray(j, 0, 1000);
                    Heap.BuildHeap(data, isGreater);

                    for(int k = 0; k < data.Length; k++)
                    {
                        int left = Heap.Left(k);
                        int right = Heap.Right(k);
                        int parent = Heap.Parent(k);

                        Assert.IsTrue(parent < 0 || !isGreater(data[k], data[parent]));
                        Assert.IsTrue(left >= data.Length || !isGreater(data[left], data[k]));
                        Assert.IsTrue(right >= data.Length || !isGreater(data[left], data[k]));
                    }
                }
            }
        }
    }
}
