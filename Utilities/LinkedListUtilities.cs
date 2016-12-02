using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.DataStructures;

namespace Utilities
{
    public static class LinkedListUtilities
    {
        public static ListNode<T> Initialize<T>(T[] data)
        {
            ListNode<T> sentinel = new ListNode<T>();
            ListNode<T> current = sentinel;

            foreach(T item in data)
            {
                current.Next = new ListNode<T>();
                current.Next.Value = item;
                current.Next.Previous = current;
                current = current.Next;
            }

            return sentinel.Next;
        }

        public static void Append<T>(ListNode<T> a, ListNode<T> b)
        {
            ListNode<T> tail = LinkedListUtilities.Tail(a);
            tail.Next = b;
        }

        public static ListNode<T> Tail<T>(ListNode<T> node)
        {
            ListNode<T> tail = node;
            while (tail.Next != null)
                tail = tail.Next;

            return tail;
        }

        public static IEnumerable<ListNode<T>> Enumerate<T>(ListNode<T> head)
        {
            while(head != null)
            {
                yield return head;
                head = head.Next;
            }
        }

        public static ListNode<T> Sort<T>(ListNode<T> head)
        {
            ListNode<T>[] sorted = LinkedListUtilities.Enumerate(head).OrderBy(o => o.Value).ToArray();
            ListNode<T> sentinel = new ListNode<T>();
            ListNode<T> tail = sentinel;

            foreach(ListNode<T> current in sorted)
            {
                tail.Next = current;
                current.Previous = tail;
                tail = current;
            }

            sentinel.Next.Previous = null;
            return sentinel.Next;
        }

        public static T[] ToArray<T>(ListNode<T> head)
        {
            return LinkedListUtilities.Enumerate(head).Select(o => o.Value).ToArray();
        }

        public static bool AreEqual<T>(ListNode<T> a, ListNode<T> b)
        {
            while(a != null && b != null)
            {
                if (!a.Value.Equals(b.Value))
                    return false;

                a = a.Next;
                b = b.Next;
            }

            return (a == null && b == null);
        }
    }
}
