using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace AlgorithmTests.PriorityQueueTests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void PriorityQueueTest()
        {
            Comparison<int> comparison = (x, y) => x.CompareTo(y);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    int[] data = Utilities.ArrayUtilities.CreateRandomArray(j, 0, 1000);
                    PriorityQueue<int> queue = new PriorityQueue<int>(j, (x, y) => x.CompareTo(y));

                    for(int k = 0; k < data.Length; k++)
                    {
                        queue.Insert(data[k], data[k]);
                        Assert.AreEqual(k + 1, queue.Count);
                    }

                    int previous = queue.Pop();

                    while(queue.Count > 0)
                    {
                        int current = queue.Pop();
                        Assert.IsTrue(comparison(previous, current) >= 0);
                        previous = current;
                    }

                    Assert.IsTrue(queue.IsEmpty);
                }
            }
        }
    }
}
