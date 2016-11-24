using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace AlgorithmTests.DataStructureTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void StackTest()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 1; j < 20; j++)
                {
                    int[] data = ArrayUtilities.CreateRandomArray(j, 0, 100);
                    Stack<int> stack = new Stack<int>();

                    Assert.IsTrue(stack.IsEmpty);

                    for(int k = 0; k < data.Length; k++)
                    {
                        stack.Push(data[k]);
                        Assert.AreEqual(data[k], stack.Peek());
                        Assert.IsFalse(stack.IsEmpty);
                    }

                    for(int k = data.Length - 1; k >= 0; k--)
                    {
                        Assert.AreEqual(data[k], stack.Peek());
                        int item = stack.Pop();
                        Assert.AreEqual(data[k], item);
                        Assert.AreEqual(stack.IsEmpty, k == 0);
                    }

                    Assert.IsTrue(stack.IsEmpty);
                }
            }
        }
    }
}
