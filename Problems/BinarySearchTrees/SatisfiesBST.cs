using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.BinarySearchTrees
{
    // EOPI 15.1
    [TestClass]
    public class SatisfiesBST
    {
        [TestMethod]
        public void SatisfiesBSTTest()
        {
            Func<BinaryTreeNode<int>, bool>[] functions = new Func<BinaryTreeNode<int>, bool>[]
            {
                SatisfiesBST.BruteForce,
                SatisfiesBST.Recursive,
                SatisfiesBST.InOrderTraversal,
                SatisfiesBST.Queue
            };

            for (int i = 0; i < 10; i++)
            {
                int[] data = ArrayUtilities.CreateRandomArray(10, 0, 20);

                BinaryTreeNode<int> root = new BinaryTreeNode<int>(data[0]);

                for(int j = 1; j < data.Length; j++)
                {
                    BinarySearchTree.Insert(root, data[j]);
                    Tests.TestFunctions(root, functions);
                }

                root = new BinaryTreeNode<int>(data[0]);

                for (int j = 1; j < data.Length; j++)
                {
                    BinaryTreeUtilities.AddRandomNode(root, data[j]);
                    Tests.TestFunctions(root, functions);
                }
            }
        }

        private static bool BruteForce(BinaryTreeNode<int> root)
        {
            if (root == null)
                return true;

            BinaryTreeNode<int> min = BinaryTree.Minimum(root);
            if (min.Data > root.Data)
                return false;

            BinaryTreeNode<int> max = BinaryTree.Maximum(root);
            if (max.Data < root.Data)
                return false;

            return SatisfiesBST.BruteForce(root.Left) && SatisfiesBST.BruteForce(root.Right);
        }

        private static bool Recursive(BinaryTreeNode<int> root)
        {
            return SatisfiesBST.Recursive(root, int.MinValue, int.MaxValue);
        }

        private static bool Recursive(BinaryTreeNode<int> root, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            if (root == null)
                return true;

            if (root.Data < minValue || root.Data > maxValue)
                return false;

            return SatisfiesBST.Recursive(root.Left, minValue, root.Data) && SatisfiesBST.Recursive(root.Right, root.Data, maxValue);
        }

        private static bool InOrderTraversal(BinaryTreeNode<int> root)
        {
            int previous = int.MinValue;

            foreach(BinaryTreeNode<int> node in BinaryTree.InOrderTraversal(root))
            {
                if (node.Data < previous)
                    return false;

                previous = node.Data;
            }

            return true;
        }

        private static bool Queue(BinaryTreeNode<int> root)
        {
            Queue<Range> queue = new Queue<Range>();
            queue.Enqueue(new Range { Node = root, Min = int.MinValue, Max = int.MaxValue });

            while(queue.Count != 0)
            {
                Range range = queue.Dequeue();
                int data = range.Node.Data;

                if (data > range.Max || data < range.Min)
                    return false;

                if (range.Node.Left != null)
                    queue.Enqueue(new Range { Node = range.Node.Left, Min = range.Min, Max = data });

                if (range.Node.Right != null)
                    queue.Enqueue(new Range { Node = range.Node.Right, Min = data, Max = range.Max });
            }

            return true;
        }

        private class Range
        {
            public BinaryTreeNode<int> Node { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }
        }
    }
}
