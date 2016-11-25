using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.Stacks
{
    // CTCI 3.5
    [TestClass]
    public class SortStack
    {
        [TestMethod]
        public void SortStackTest()
        {
            Action<Stack<int>>[] actions = new Action<Stack<int>>[]
            {
                StackUtilities.Sort,
                SortStack.SecondStack
            };

            for(int i = 0; i < 10; i++)
            {
                int[] data = ArrayUtilities.CreateRandomArray(15, 0, 10);
                Stack<int>[] parameters = new Stack<int>[actions.Length];

                for (int j = 0; j < actions.Length; j++)
                    parameters[j] = StackUtilities.Initialize(data);

                for(int j = 0; j < actions.Length; j++)
                {
                    actions[j](parameters[j]);
                    Assert.IsTrue(StackUtilities.AreEqual(parameters[0], parameters[j]));
                }
            }
        }

        private static void SecondStack(Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();

            while(!stack.IsEmpty)
            {
                if(temp.IsEmpty || stack.Peek() >= temp.Peek())
                    temp.Push(stack.Pop());
                else
                {
                    int item = stack.Pop();
                    while (!temp.IsEmpty && temp.Peek() > item)
                        stack.Push(temp.Pop());
                    temp.Push(item);
                }
            }

            while (!temp.IsEmpty)
                stack.Push(temp.Pop());
        }
    }
}
