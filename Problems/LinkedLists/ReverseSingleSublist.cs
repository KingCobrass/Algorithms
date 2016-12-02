using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.LinkedLists
{
    [TestClass]
    public class ReverseSingleSublist
    {
        // EOPI 8.2
        [TestMethod]
        public void ReverseSingleSublistTest()
        {
            Func<ListNode<int>, int, int, ListNode<int>>[] functions = new Func<ListNode<int>, int, int, ListNode<int>>[]
            {
                ReverseSingleSublist.BruteForce,
                ReverseSingleSublist.SinglePass
            };

            for(int i = 0; i < 10; i++)
            {
                int[] data = ArrayUtilities.CreateRandomArray(10, 0, 10);
                for (int start = 1; start <= 10; start++)
                {
                    for(int end = start; end <= 10; end++)
                    {
                        ListNode<int>[] results = new ListNode<int>[functions.Length];

                        for (int j = 0; j < results.Length; j++)
                        {
                            ListNode<int> head = LinkedListUtilities.Initialize(data);
                            results[j] = functions[j](head, start, end);
                            Assert.IsTrue(LinkedListUtilities.AreEqual(results[0], results[j]));
                        }
                    }
                }
            }
        }

        private static ListNode<int> BruteForce(ListNode<int> head, int start, int end)
        {
            int[] data = LinkedListUtilities.ToArray(head);
            for(int i = 0; i < (end - start + 1) / 2; i++)
                ArrayUtilities.Swap(data, start + i - 1, end - i - 1);

            return LinkedListUtilities.Initialize(data);
        }

        private static ListNode<int> SinglePass(ListNode<int> head, int start, int end)
        {
            if (start == end)
                return head;

            ListNode<int> sentinel = new ListNode<int>();
            sentinel.Next = head;
            ListNode<int> current = head;
            ListNode<int> predecessor = sentinel;

            for(int i = 1; i < start; i++)
            {
                predecessor = current;
                current = current.Next;
            }

            ListNode<int> subListHead = current;
            ListNode<int> previous = null;

            for(int i = start; i <= end; i++)
            {
                ListNode<int> next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            predecessor.Next = previous;
            subListHead.Next = current;

            return sentinel.Next;
        }
    }
}
