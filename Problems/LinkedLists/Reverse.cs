using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.LinkedLists
{
    [TestClass]
    public class Reverse
    {
        [TestMethod]
        public void ReverseTest()
        {
            Func<ListNode<int>, ListNode<int>>[] functions = new Func<ListNode<int>, ListNode<int>>[]
            {
                Reverse.BruteForce,
                Reverse.Build,
                Reverse.Traverse
            };

            for(int i = 0; i < 10; i++)
            {
                int[] data = ArrayUtilities.CreateRandomArray(10, 0, 15);
                ListNode<int>[] results = new ListNode<int>[functions.Length];

                for(int j = 0; j < functions.Length; j++)
                {
                    results[j] = functions[j](LinkedListUtilities.Initialize(data));
                    Assert.IsTrue(LinkedListUtilities.AreEqual(results[0], results[j]));
                }
            }
        }

        private static ListNode<int> BruteForce(ListNode<int> node)
        {
            Stack<ListNode<int>> stack = new Stack<ListNode<int>>();

            while(node != null)
            {
                stack.Push(node);
                node = node.Next;
            }

            ListNode<int> head = stack.Pop();
            ListNode<int> tail = head;

            while(!stack.IsEmpty)
            {
                tail.Next = stack.Pop();
                tail = tail.Next;
            }

            tail.Next = null;
            return head;
        }

        private static ListNode<int> Build(ListNode<int> node)
        {
            ListNode<int> previous = null;

            while(node != null)
            {
                ListNode<int> next = node.Next;
                node.Next = previous;
                previous = node;
                node = next;
            }

            return previous;
        }

        private static ListNode<int> Traverse(ListNode<int> node)
        {
            ListNode<int> head = node;
            
            while(node.Next != null)
            {
                ListNode<int> next = node.Next;
                node.Next = next.Next;
                next.Next = head;
                head = next;
            }

            return head;
        }
    }
}
