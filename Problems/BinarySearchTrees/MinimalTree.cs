using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.BinarySearchTrees
{
    // CTCI 4.2
    [TestClass]
    public class MinimalTree
    {
        [TestMethod]
        public void MinimalTreeTest()
        {
            for(int i = 0; i < 10; i++)
            {
                int minHeight = 0;
                for (int j = 0; j <= 20; j++)
                {
                    if (j == 1 << minHeight)
                        minHeight++;

                    int[] data = ArrayUtilities.CreateRandomArray(j, 0, 10);
                    BinaryTreeNode<int> root = MinimalTree.Recursive(data);
                    Assert.AreEqual(BinaryTreeUtilities.Height(root), minHeight);
                }
            }
        }

        private static BinaryTreeNode<int> Recursive(int[] data)
        {
            return MinimalTree.Recursive(data, 0, data.Length - 1);
        }

        private static BinaryTreeNode<int> Recursive(int[] data, int start, int end)
        {
            if (start > end)
                return null;

            int mid = start + (end - start) / 2;

            BinaryTreeNode<int> root = new BinaryTreeNode<int>(mid);
            root.Left = MinimalTree.Recursive(data, start, mid - 1);
            root.Right = MinimalTree.Recursive(data, mid + 1, end);

            return root;
        }
    }
}
