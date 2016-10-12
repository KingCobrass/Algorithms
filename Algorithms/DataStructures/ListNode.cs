using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class ListNode<T>
    {
        public ListNode<T> Next { get; set; }
        public ListNode<T> Previous { get; set; }
        public T Value { get; set; }

        public ListNode(T item = default(T))
        {
            this.Value = item;
        }
    }
}
