using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.BinarySearchTrees
{
    // EOPI 15.3
    [TestClass]
    public class LargestElements
    {
        [TestMethod]
        public void LargestElementsTest()
        {
            Func<BinaryTreeNode<int>, int, int[]>[] functions = new Func<BinaryTreeNode<int>, int, int[]>[]
            {
                LargestElements.BruteForce,
                LargestElements.ReverseOrder
            };

            for(int i = 0; i < 10; i++)
            {
                BinaryTreeNode<int> root = BinaryTreeUtilities.CreateRandomBinaryTree(10, 0, 15);
                int[][] results = new int[functions.Length][];

                for(int k = 0; k <= 10; k++)
                {
                    for (int j = 0; j < functions.Length; j++)
                    {
                        results[j] = functions[j](root, k);
                        Assert.IsTrue(ArrayUtilities.AreEqual(results[0], results[j]));
                    }
                }
            }
        }

        private static int[] BruteForce(BinaryTreeNode<int> root, int k)
        {
            int[] data = BinaryTree.InOrderTraversal(root).Select(n => n.Data).ToArray();

            int[] results = new int[k];

            for (int i = 0; i < k; i++)
                results[i] = data[data.Length - 1 - i];

            return results;
        }

        private static int[] ReverseOrder(BinaryTreeNode<int> root, int k)
        {
            List<int> list = new List<int>();
            LargestElements.ReverseOrder(root, list, k);
            return list.ToArray();
        }

        private static void ReverseOrder(BinaryTreeNode<int> root, List<int> list, int k)
        {
            if (root == null)
                return;

            LargestElements.ReverseOrder(root.Right, list, k);

            if (list.Count < k)
                list.Add(root.Data);

            if (list.Count < k)
                LargestElements.ReverseOrder(root.Left, list, k);
        }
    }
}
