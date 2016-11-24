using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class Stack<T>
    {
        private ListNode<T> top;

        public bool IsEmpty
        {
            get
            {
                return this.top == null;
            }
        }

        public T Peek()
        {
            this.ThrowIfEmpty();
            return this.top.Value;
        }

        public void Push(T item)
        {
            ListNode<T> node = new ListNode<T>(item);
            node.Next = this.top;
            this.top = node;
        }

        public T Pop()
        {
            this.ThrowIfEmpty();
            ListNode<T> node = this.top;
            this.top = node.Next;
            return node.Value;
        }

        public IEnumerable<T> Items()
        {
            ListNode<T> node = this.top;
            while(node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        private void ThrowIfEmpty()
        {
            if (this.IsEmpty)
                throw new InvalidOperationException();
        }
    }
}
