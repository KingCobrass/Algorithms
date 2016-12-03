using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.DataStructures;

namespace Utilities
{
    public static class BinarySearchTreeUtilities
    {
        public static BinaryTreeNode<int> CreateRandomBinarySearchTree(int count, int minValue, int maxValue)
        {
            Random random = new Random();
            BinaryTreeNode<int> root = null;
            for(int i = 0; i < count; i++)
            {
                int value = random.Next(0, maxValue + 1);
                if (root == null)
                    root = new BinaryTreeNode<int>(value);
                else
                    BinarySearchTree.Insert(root, value);
            }

            return root;
        }

        public static BinaryTreeNode<int> FromArray(int[] data)
        {
            BinaryTreeNode<int> root = null;
            for (int i = 0; i < data.Length; i++)
            {
                if (root == null)
                    root = new BinaryTreeNode<int>(data[i]);
                else
                    BinarySearchTree.Insert(root, data[i]);
            }

            return root;
        }
    }
}
