using System;

namespace Algorithms.DataStructures
{
    public class PriorityQueue<T>
    {
        Comparison<int> comparison;
        Node[] data;
        int heapSize;

        public PriorityQueue(int capacity, Comparison<int> comparison)
        {
            this.comparison = comparison;
            data = new Node[capacity];
        }

        public bool IsEmpty
        {
            get { return this.heapSize == 0; }
        }

        public int Count
        {
            get { return this.heapSize; }
        }

        public bool IsFull
        {
            get { return this.heapSize == this.data.Length; }
        }

        public void Insert(T item, int priority)
        {
            if (this.IsFull)
                throw new InvalidOperationException();

            int i = heapSize;
            data[i] = new Node { Priority = priority, Item = item };
            this.heapSize++;

            while(i != 0 && this.comparison(data[i].Priority, data[Heap.Parent(i)].Priority) > 0)
            {
                Utilities.Swap(data, i, Heap.Parent(i));
                i = Heap.Parent(i);
            }
        }

        public T Pop()
        {
            if (this.IsEmpty)
                throw new InvalidOperationException();

            Node node = this.data[0];
            this.heapSize--;

            this.data[0] = this.data[this.heapSize];
            this.data[this.heapSize] = null;

            Heap.Heapify(this.data, 0, this.heapSize, (x, y) => this.comparison(x.Priority, y.Priority));

            return node.Item;
        }

        private class Node
        {
            public int Priority { get; set; }
            public T Item { get; set; }
        }
    }
}
