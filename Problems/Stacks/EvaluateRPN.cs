using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Problems.Stacks
{
    [TestClass]
    public class EvaluateRPN
    {
        [TestMethod]
        public void EvaluateRPNTest()
        {
            EvaluateRPN.EvaluateRPNTest(1729, "1729");
            EvaluateRPN.EvaluateRPNTest(15, "3,4,+,2,*,1,+");
            EvaluateRPN.EvaluateRPNTest(42, "6,6,1,+,*");
        }

        private static void EvaluateRPNTest(int expected, string rpn)
        {
            Assert.AreEqual(expected, EvaluateRPN.Stack(rpn));
        }

        private static int Stack(string rpn)
        {
            string operators = "+-*/";
            Func<int, int, int>[] functions = new Func<int, int, int>[]
            {
                (x, y) => x + y,
                (x, y) => x - y,
                (x, y) => x * y,
                (x, y) => x / y,
            };

            string[] tokens = rpn.Split(',');
            Stack<int> values = new Stack<int>();

            foreach(string token in tokens)
            {
                int index = operators.IndexOf(token);
                if (index == -1)
                {
                    values.Push(int.Parse(token));
                    continue;
                }

                int y = values.Pop();
                int x = values.Pop();

                values.Push(functions[index](x, y));
            }

            return values.Pop();
        }
    }
}
