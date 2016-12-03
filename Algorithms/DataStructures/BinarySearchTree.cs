using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public static class BinarySearchTree
    {
        public static BinaryTreeNode<T> Find<T>(BinaryTreeNode<T> root, T value)
            where T : IComparable<T>
        {
            return BinarySearchTree.Find(root, value, (x, y) => x.CompareTo(y));
        }

        public static BinaryTreeNode<T> Find<T>(BinaryTreeNode<T> root, T data, Comparison<T> comparison)
        {
            while (root != null)
            {
                int compare = comparison(root.Data, data);

                if (compare == 0)
                    return root;
                else if (compare > 0)
                    root = root.Left;
                else
                    root = root.Right;
            }

            return null;
        }

        public static void Insert<T>(BinaryTreeNode<T> root, T value)
            where T : IComparable<T>
        {
            BinarySearchTree.Insert(root, value, (x, y) => x.CompareTo(y));
        }

        public static void Insert<T>(BinaryTreeNode<T> root, T value, Comparison<T> comparison)
        {
            BinaryTreeNode<T> previous = null;
            BinaryTreeNode<T> current = root;

            while (current != null)
            {
                previous = current;
                current = (comparison(current.Data, value) > 0) ? current.Left : current.Right;
            }

            BinaryTreeNode<T> node = new BinaryTreeNode<T>(value);
            node.Parent = previous;

            if (comparison(previous.Data, value) > 0)
                previous.Left = node;
            else
                previous.Right = node;
        }
    }
}
