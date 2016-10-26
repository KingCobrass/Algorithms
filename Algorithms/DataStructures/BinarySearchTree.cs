using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class BinarySearchTree
    {
        public BinaryTreeNode<int> Root { get; private set; }

        public IEnumerable<int> Values
        {
            get
            {
                foreach (int x in BinarySearchTree.InOrderTraversal(this.Root))
                    yield return x;
            }
        }

        public void Add(int data)
        {
            BinaryTreeNode<int> node = new BinaryTreeNode<int> { Data = data };

            BinaryTreeNode<int> previous = null;
            BinaryTreeNode<int> current = this.Root;

            while (current != null)
            {
                previous = current;
                current = (current.Data > node.Data) ? current.Left : current.Right;
            }

            if (previous == null)
            {
                this.Root = node;
                return;
            }

            node.Parent = previous;
            if (previous.Data > node.Data)
                previous.Left = node;
            else
                previous.Right = node;
        }

        public bool Contains(int data)
        {
            return BinarySearchTree.Find(data, this.Root) != null;
        }

        public void Delete(int data)
        {
            BinaryTreeNode<int> node = BinarySearchTree.Find(data, this.Root);

            if (node == null)
                return;

            if (node.Left == null)
                this.Transplant(node, node.Right);
            else if (node.Right == null)
                this.Transplant(node, node.Left);
            else
            {
                BinaryTreeNode<int> successor = BinarySearchTree.Successor(node);

                if (successor != node.Right)
                {
                    this.Transplant(successor, successor.Right);
                    successor.Right = node.Right;
                    successor.Right.Parent = successor;
                }

                this.Transplant(node, successor);
                successor.Left = node.Left;
                successor.Left.Parent = successor;
            }
        }

        private static BinaryTreeNode<int> Find(int data, BinaryTreeNode<int> node)
        {
            while (node != null)
            {
                if (node.Data == data)
                    return node;

                node = node.Data > data ? node.Left : node.Right;
            }

            return null;
        }

        private static IEnumerable<int> InOrderTraversal(BinaryTreeNode<int> node)
        {
            if (node == null)
                yield break;

            foreach (int x in BinarySearchTree.InOrderTraversal(node.Left))
                yield return x;

            yield return node.Data;

            foreach (int x in BinarySearchTree.InOrderTraversal(node.Right))
                yield return x;
        }

        private void Transplant(BinaryTreeNode<int> a, BinaryTreeNode<int> b)
        {
            if (a.Parent == null)
                this.Root = b;
            else if (a == a.Parent.Left)
                a.Parent.Left = b;
            else
                a.Parent.Right = b;

            if(b != null)
                b.Parent = a.Parent;
        }

        private static BinaryTreeNode<int> Predecessor(BinaryTreeNode<int> node)
        {
            if (node.Left != null)
                return BinarySearchTree.Maximum(node.Left);

            while (node.Parent != null && node == node.Parent.Left)
                node = node.Parent;

            return node.Parent;
        }

        private static BinaryTreeNode<int> Successor(BinaryTreeNode<int> node)
        {
            if (node.Right != null)
                return BinarySearchTree.Minimum(node.Right);

            while (node.Parent != null && node == node.Parent.Right)
                node = node.Parent;

            return node.Parent;
        }

        private static BinaryTreeNode<int> Minimum(BinaryTreeNode<int> node)
        {
            while (node.Left != null)
                node = node.Left;

            return node;
        }

        private static BinaryTreeNode<int> Maximum(BinaryTreeNode<int> node)
        {
            while (node.Right != null)
                node = node.Right;

            return node;
        }
    }
}
