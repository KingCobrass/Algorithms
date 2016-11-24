using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.LinkedLists
{
    // CTCI 2.1
    [TestClass]
    public class RemoveDups
    {
        [TestMethod]
        public void RemoveDupsTest()
        {
            Action<ListNode<int>>[] functions = new Action<ListNode<int>>[]
            {
                RemoveDups.Search,
                RemoveDups.Multiset
            };

            for(int i = 0; i < 10; i++)
            {
                int[] data = ArrayUtilities.CreateRandomArray(20, 0, 15);

                ListNode<int>[] nodes = new ListNode<int>[functions.Length];

                for(int j = 0; j < nodes.Length; j++)
                    nodes[j] = LinkedListUtilities.Initialize(data);

                for (int j = 0; j < functions.Length; j++)
                    functions[j](nodes[j]);

                for(int j = 1; j < functions.Length; j++)
                    Assert.IsTrue(ArrayUtilities.AreEqual(LinkedListUtilities.ToArray(nodes[0]), LinkedListUtilities.ToArray(nodes[j])));
            }
        }

        private static void Search(ListNode<int> head)
        {
            while(head != null)
            {
                ListNode<int> current = head.Next;
                ListNode<int> previous = head;

                while(current != null)
                {
                    if (current.Value == head.Value)
                        previous.Next = current.Next;
                    else
                        previous = current;

                    current = current.Next;
                }

                head = head.Next;
            }
        }

        private static void Multiset(ListNode<int> head)
        {
            Multiset<int> multiset = new Multiset<int>();
            ListNode<int> previous = null;

            while(head != null)
            {
                if (multiset.Contains(head.Value))
                    previous.Next = head.Next;
                else
                {
                    previous = head;
                    multiset.Add(head.Value);
                }

                head = head.Next;
            }
        }
    }
}
