using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public static class BinaryTree
    {
        public static IEnumerable<BinaryTreeNode<T>> InOrderTraversal<T>(BinaryTreeNode<T> root)
        {
            if (root == null)
                yield break;

            foreach (BinaryTreeNode<T> node in BinaryTree.InOrderTraversal(root.Left))
                yield return node;

            yield return root;

            foreach (BinaryTreeNode<T> node in BinaryTree.InOrderTraversal(root.Right))
                yield return node;
        }

        public static BinaryTreeNode<T> Minimum<T>(BinaryTreeNode<T> node)
        {
            while (node.Left != null)
                node = node.Left;

            return node;
        }

        public static BinaryTreeNode<T> Maximum<T>(BinaryTreeNode<T> node)
        {
            while (node.Right != null)
                node = node.Right;

            return node;
        }

        public static BinaryTreeNode<T> Predecessor<T>(BinaryTreeNode<T> node)
        {
            if (node.Left != null)
                return BinaryTree.Maximum(node.Left);

            while (node.Parent != null && node == node.Parent.Left)
                node = node.Parent;

            return node.Parent;
        }

        public static BinaryTreeNode<T> Successor<T>(BinaryTreeNode<T> node)
        {
            if (node.Right != null)
                return BinaryTree.Minimum(node.Right);

            while (node.Parent != null && node == node.Parent.Right)
                node = node.Parent;

            return node.Parent;
        }

        public static BinaryTreeNode<T> Delete<T>(BinaryTreeNode<T> node)
        {
            if (node.Left == null)
            {
                BinaryTree.Transplant(node, node.Right);
                return node.Right;
            }

            if (node.Right == null)
            {
                BinaryTree.Transplant(node, node.Left);
                return node.Left;
            }

            BinaryTreeNode<T> successor = BinaryTree.Successor(node);

            if (successor != node.Right)
            {
                BinaryTree.Transplant(successor, successor.Right);
                successor.Right = node.Right;
                successor.Right.Parent = successor;
            }

            BinaryTree.Transplant(node, successor);
            successor.Left = node.Left;
            successor.Left.Parent = successor;

            return successor;
        }

        private static void Transplant<T>(BinaryTreeNode<T> a, BinaryTreeNode<T> b)
        {
            if (a.Parent != null)
            {
                if (a == a.Parent.Left)
                    a.Parent.Left = b;
                else
                    a.Parent.Right = b;
            }

            if (b != null)
                b.Parent = a.Parent;
        }
    }
}
