using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.BinarySearchTrees
{
    // EOPI 15.2
    [TestClass]
    public class FirstGreater
    {
        [TestMethod]
        public void FirstGreaterTest()
        {
            Func<BinaryTreeNode<int>, int, int>[] functions = new Func<BinaryTreeNode<int>, int, int>[]
            {
                FirstGreater.BruteForce,
                FirstGreater.Search
            };

            for(int i = 0; i < 10; i++)
            {
                BinaryTreeNode<int> root = BinarySearchTreeUtilities.CreateRandomBinarySearchTree(10, 0, 15);
                for (int j = 0; j <= 16; j++)
                    Tests.TestFunctions(root, j, functions);
            }
        }

        private static int BruteForce(BinaryTreeNode<int> root, int value)
        {
            foreach(BinaryTreeNode<int> i in BinaryTree.InOrderTraversal(root))
            {
                if (i.Data > value)
                    return i.Data;
            }

            return -1;
        }

        private static int Search(BinaryTreeNode<int> root, int value)
        {
            int candidate = -1;

            while(root != null)
            {
                if (root.Data > value)
                {
                    candidate = root.Data;
                    root = root.Left;
                }
                else
                    root = root.Right;
            }

            return candidate;
        }
    }
}
