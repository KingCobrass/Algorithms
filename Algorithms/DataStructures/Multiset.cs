using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class Multiset<T>
        where T : IComparable<T>
    {
        BinaryTreeNode<T> Root { get; set; }

        public IEnumerable<T> Values
        {
            get
            {
                return BinaryTree.InOrderTraversal(this.Root).Select(s => s.Data);
            }
        }

        public void Add(T data)
        {
            if (this.Root == null)
            {
                this.Root = new BinaryTreeNode<T>(data);
                return;
            }

            BinarySearchTree.Insert(this.Root, data);
        }

        public bool Contains(T data)
        {
            return BinarySearchTree.Find(this.Root, data) != null;
        }

        public void Delete(T data)
        {
            BinaryTreeNode<T> node = BinarySearchTree.Find(this.Root, data);

            if (node == null)
                return;

            BinaryTreeNode<T> successor = BinaryTree.Delete(node);

            if (node.Parent == null)
                this.Root = successor;
        }
    }
}
