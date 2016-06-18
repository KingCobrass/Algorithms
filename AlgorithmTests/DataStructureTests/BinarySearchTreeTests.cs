using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace AlgorithmTests.DataStructureTests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        private const int MaxValue = 1000;

        [TestMethod]
        public void BinarySearchTreeAddTest()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    BinarySearchTree tree = new BinarySearchTree();
                    int[] data = TestUtilities.GenerateRandomArray(j, 0, BinarySearchTreeTests.MaxValue);

                    for (int k = 0; k < data.Length; k++)
                    {
                        tree.Add(data[k]);
                        BinarySearchTreeTests.ValidateTree(tree, data, k + 1);
                    }
                }
            }
        }

        [TestMethod]
        public void BinarySearchTreeDeleteTest()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    BinarySearchTree tree = new BinarySearchTree();
                    int[] data = TestUtilities.GenerateRandomArray(j, 0, BinarySearchTreeTests.MaxValue);

                    for (int k = 0; k < data.Length; k++)
                        tree.Add(data[k]);

                    BinarySearchTreeTests.ValidateTree(tree, data, data.Length);

                    List<int> list = new List<int>(data);
                    Random random = new Random();
                    List<int> removed = new List<int>();

                    while(list.Count > 0)
                    {
                        int index = random.Next(0, list.Count);
                        int x = list[index];
                        tree.Delete(x);
                        list.RemoveAt(index);
                        removed.Add(x);
                        int[] remaining = list.ToArray();
                        ValidateTree(tree, remaining, remaining.Length);
                    }
                }
            }
        }

        private static void ValidateTree(BinarySearchTree tree, int[] data, int count)
        {
            BinarySearchTreeTests.ValidateNode(tree.Root);
            int[] sorted = new int[count];
            Array.Copy(data, sorted, count);
            Array.Sort(sorted);

            foreach (int x in sorted)
                Assert.IsTrue(tree.Contains(x));

            int l = 0;
            foreach (int x in tree.Values)
            {
                Assert.AreEqual(x, sorted[l]);
                l++;
            }

            Assert.AreEqual(l, count);
        }

        private static void ValidateNode(Node node, int min = int.MinValue, int max = int.MaxValue)
        {
            if (node == null)
                return;

            Assert.IsTrue(node.Data >= min);
            Assert.IsTrue(node.Data <= max);

            BinarySearchTreeTests.ValidateNode(node.Left, min, node.Data);
            BinarySearchTreeTests.ValidateNode(node.Right, node.Data, max);
        }
    }
}
