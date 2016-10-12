using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class Stack<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public T Peek()
        {
            return this.tail.Value;
        }

        public void Push(T item)
        {
            ListNode<T> node = new ListNode<T>(item);
            if(this.tail == null)
            {
                this.head = this.tail = node;
            }
            else
            {
                this.tail.Next = node;
                node.Previous = this.tail;
                this.tail = node;
            }

            this.Count++;
        }

        public T Pop()
        {
            ListNode<T> node = this.tail;
            if(this.tail.Previous == null)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;
            }

            this.Count--;

            return node.Value;
        }

        public IEnumerable<T> Items()
        {
            ListNode<T> node = this.head;
            while(node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }
    }
}
