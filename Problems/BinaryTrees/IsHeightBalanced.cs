using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.LinkedLists
{
    [TestClass]
    public class IsHeightBalanced
    {
        [TestMethod]
        public void IsHeightBalancedTest()
        {
            Func<BinaryTreeNode<int>, bool>[] functions = new Func<BinaryTreeNode<int>, bool>[]
            {
                IsHeightBalanced.BruteForce,
                IsHeightBalanced.Recursive,
            };

            for (int i = 0; i < 10; i++)
            {
                BinaryTreeNode<int> root = new BinaryTreeNode<int>();

                for(int j = 0; j < 20; j++)
                {
                    IsHeightBalanced.AddRandomNode(root);
                    Tests.TestFunctions(root, functions);
                }
            }
        }

        private static bool BruteForce(BinaryTreeNode<int> root)
        {
            return IsHeightBalanced.BalancedHeightBruteForce(root);
        }

        private static bool BalancedHeightBruteForce(BinaryTreeNode<int> node)
        {
            if (node == null)
                return true;

            if (!IsHeightBalanced.BalancedHeightBruteForce(node.Left))
                return false;

            if (!IsHeightBalanced.BalancedHeightBruteForce(node.Right))
                return false;

            int leftHeight = node.Left == null ? -1 : node.Left.Data;
            int rightHeight = node.Right == null ? -1 : node.Right.Data;

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return false;

            node.Data = Math.Max(leftHeight, rightHeight) + 1;

            return true;
        }

        private static bool Recursive(BinaryTreeNode<int> root)
        {
            return IsHeightBalanced.BalancedHeightRecursive(root) != null;
        }

        private static Nullable<int> BalancedHeightRecursive(BinaryTreeNode<int> node)
        {
            if (node == null)
                return -1;

            Nullable<int> leftHeight = IsHeightBalanced.BalancedHeightRecursive(node.Left);
            if (leftHeight == null)
                return null;

            Nullable<int> rightHeight = IsHeightBalanced.BalancedHeightRecursive(node.Right);
            if (rightHeight == null)
                return null;

            if (Math.Abs(rightHeight.Value - leftHeight.Value) > 1)
                return null;

            return Math.Max(rightHeight.Value, leftHeight.Value) + 1;
        }

        private static void AddRandomNode(BinaryTreeNode<int> node)
        {
            Random random = new Random();

            while(true)
            {
                if (random.Next(2) == 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new BinaryTreeNode<int>();
                        return;
                    }
                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new BinaryTreeNode<int>();
                        return;
                    }
                    node = node.Right;
                }

            }
        }
    }
}
