using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public class PriorityQueue<T>
    {
        Comparison<T> comparison;
        List<T> data = new List<T>();

        public PriorityQueue(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        public bool IsEmpty
        {
            get { return this.data.Count == 0; }
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public T Peek()
        {
            if (this.data.Count == 0)
                throw new InvalidOperationException();

            return this.data[0];
        }

        public void Insert(T item)
        {
            this.data.Add(item);
            int i = this.Count - 1;

            while (i != 0 && this.comparison(data[i], data[Heap.Parent(i)]) > 0)
            {
                Utilities.Swap(data, i, Heap.Parent(i));
                i = Heap.Parent(i);
            }
        }

        public T Pop()
        {
            if (this.IsEmpty)
                throw new InvalidOperationException();

            T item = this.data[0];

            this.data[0] = this.data[this.Count - 1];
            this.data.RemoveAt(this.Count - 1);

            Heap.Heapify(j => data[j], (j, k) => { data[j] = k; }, 0, this.Count, this.comparison);

            return item;
        }
    }

    public class MaxPriorityQueue<T> : PriorityQueue<T>
        where T : IComparable
    {
        public MaxPriorityQueue() : base((x, y) => x.CompareTo(y))
        {
        }
    }

    public class MinPriorityQueue<T> : PriorityQueue<T>
        where T : IComparable<T>
    {
        public MinPriorityQueue() : base((x, y) => y.CompareTo(x))
        {
        }
    }
}
