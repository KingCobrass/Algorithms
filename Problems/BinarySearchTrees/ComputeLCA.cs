using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.BinarySearchTrees
{
    [TestClass]
    public class ComputeLCA
    {
        [TestMethod]
        public void ComputeLCATest()
        {
            Func<BinaryTreeNode<int>, int, int, BinaryTreeNode<int>>[] functions = new Func<BinaryTreeNode<int>, int, int, BinaryTreeNode<int>>[]
            {
                ComputeLCA.BruteForce,
                ComputeLCA.UseBSTProperty
            };

            for(int i = 0; i < 10; i++)
            {
                int[] data = ArrayUtilities.CreateRandomPermutation(16);
                BinaryTreeNode<int> root = BinarySearchTreeUtilities.FromArray(data);

                for(int j = 0; j < 16; j++)
                {
                    for(int k = j; k < 16; k++)
                    {
                        Tests.TestFunctions(root, j, k, functions);
                    }
                }
            }
        }

        private static BinaryTreeNode<int> BruteForce(BinaryTreeNode<int> root, int a, int b)
        {
            BinaryTreeNode<int> n1 = BinarySearchTree.Find(root, a);
            BinaryTreeNode<int> n2 = BinarySearchTree.Find(root, b);

            int d1 = ComputeLCA.Depth(n1);
            int d2 = ComputeLCA.Depth(n2);

            while (d1 > d2)
            {
                n1 = n1.Parent;
                d1--;
            }

            while (d2 > d1)
            {
                n2 = n2.Parent;
                d2--;
            }

            while (!object.Equals(n1, n2))
            {
                n1 = n1.Parent;
                n2 = n2.Parent;
            }

            return n1;
        }

        private static int Depth(BinaryTreeNode<int> node)
        {
            int count = 0;
            while(node != null)
            {
                node = node.Parent;
                count++;
            }

            return count;
        }

        private static BinaryTreeNode<int> UseBSTProperty(BinaryTreeNode<int> root, int a, int b)
        {
            while(root.Data < a || root.Data > b)
            {
                while (root.Data > b)
                    root = root.Left;

                while (root.Data < a)
                    root = root.Right;
            }

            return root;
        }
    }
}
