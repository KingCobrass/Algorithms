using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.LinkedLists
{
    [TestClass]
    public class MergeTwoSortedLists
    {
        [TestMethod]
        public void MergeTwoSortedListsTest()
        {
            Func<ListNode<int>, ListNode<int>, ListNode<int>>[] functions = new Func<ListNode<int>, ListNode<int>, ListNode<int>>[]
            {
                MergeTwoSortedLists.AppendAndSort,
                MergeTwoSortedLists.SinglePass
            };

            for(int i = 0; i < 10; i++)
            {
                int[] data1 = ArrayUtilities.CreateRandomArray(10, 0, 25);
                int[] data2 = ArrayUtilities.CreateRandomArray(10, 0, 25);
                Array.Sort(data1);
                Array.Sort(data2);

                int[] expected = new int[data1.Length + data2.Length];
                Array.Copy(data1, expected, data1.Length);
                Array.Copy(data2, 0, expected, data1.Length, data2.Length);
                Array.Sort(expected);

                for (int j = 0; j < functions.Length; j++)
                {
                    ListNode<int> result = functions[j](LinkedListUtilities.Initialize(data1), LinkedListUtilities.Initialize(data2));
                    int[] actual = LinkedListUtilities.ToArray(result);

                    Assert.IsTrue(ArrayUtilities.AreEqual(expected, actual));
                }
            }
        }

        private static ListNode<int> AppendAndSort(ListNode<int> a, ListNode<int> b)
        {
            LinkedListUtilities.Append(a, b);
            return LinkedListUtilities.Sort(a);
        }

        private static ListNode<int> SinglePass(ListNode<int> a, ListNode<int> b)
        {
            ListNode<int> head = a.Value >= b.Value ? a : b;
            ListNode<int> tail = head;

            while(a != null && b != null)
            {
                ListNode<int> next = null;
                if (a.Value <= b.Value)
                {
                    next = a;
                    a = a.Next;
                }
                else
                {
                    next = b;
                    b = b.Next;
                }

                tail.Next = next;
                tail = next;
            }

            tail.Next = a ?? b;

            return head;
        }
    }
}
