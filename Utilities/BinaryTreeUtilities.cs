using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.DataStructures;

namespace Utilities
{
    public static class BinaryTreeUtilities
    {
        public static BinaryTreeNode<int> CreateRandomBinaryTree(int count, int min, int max)
        {
            if (count == 0)
                return null;

            int[] data = ArrayUtilities.CreateRandomArray(count, min, max);

            Random random = new Random();

            BinaryTreeNode<int> root = new BinaryTreeNode<int> { Data = data[0] };

            for(int i = 1; i < count; i++)
                BinaryTreeUtilities.AddRandomNode(root, data[i]);

            return root;
        }

        public static void AddRandomNode<T>(BinaryTreeNode<T> root, T value)
        {
            Random random = new Random();
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(value);

            while (true)
            {
                if (random.Next(2) == 0)
                {
                    if (root.Left == null)
                    {
                        root.Left = node;
                        return;
                    }
                    root = root.Left;
                }
                else
                {
                    if (root.Right == null)
                    {
                        root.Right = node;
                        return;
                    }
                    root = root.Right;
                }
            }
        }
    }
}
