using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

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
                    int[] data = ArrayUtilities.CreateRandomArray(j, 0, BinarySearchTreeTests.MaxValue);

                    BinaryTreeNode<int> root = null;

                    for (int k = 0; k < data.Length; k++)
                    {
                        if (k == 0)
                            root = new BinaryTreeNode<int>(data[k]);
                        else
                            BinarySearchTree.Insert(root, data[k]);

                        BinarySearchTreeTests.ValidateTree(root, data, k + 1);
                    }
                }
            }
        }

        [TestMethod]
        public void BinarySearchTreeDeleteTest()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    int[] data = Utilities.ArrayUtilities.CreateRandomArray(j, 0, BinarySearchTreeTests.MaxValue);

                    BinaryTreeNode<int> root = new BinaryTreeNode<int>(data[0]);

                    for (int k = 1; k < data.Length; k++)
                        BinarySearchTree.Insert(root, data[k]);

                    BinarySearchTreeTests.ValidateTree(root, data, data.Length);

                    List<int> list = new List<int>(data);
                    Random random = new Random();

                    while(list.Count > 0)
                    {
                        int index = random.Next(0, list.Count);
                        int x = list[index];

                        BinaryTreeNode<int> toRemove = BinarySearchTree.Find(root, x);
                        BinaryTreeNode<int> successor = BinaryTree.Delete(toRemove);

                        if (toRemove == root)
                            root = successor;

                        list.RemoveAt(index);
                        int[] remaining = list.ToArray();
                        ValidateTree(root, remaining, remaining.Length);
                    }
                }
            }
        }

        private static void ValidateTree(BinaryTreeNode<int> root, int[] data, int count)
        {
            BinarySearchTreeTests.ValidateNode(root);
            int[] sorted = new int[count];
            Array.Copy(data, sorted, count);
            Array.Sort(sorted);

            foreach (int x in sorted)
                Assert.IsNotNull(BinarySearchTree.Find(root, x));

            int l = 0;
            foreach (BinaryTreeNode<int> x in BinaryTree.InOrderTraversal(root))
            {
                Assert.AreEqual(x.Data, sorted[l]);
                l++;
            }

            Assert.AreEqual(l, count);
        }

        private static void ValidateNode(BinaryTreeNode<int> node, int min = int.MinValue, int max = int.MaxValue)
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
