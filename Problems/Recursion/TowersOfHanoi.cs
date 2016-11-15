using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Problems.Recursion
{
    [TestClass]
    public class TowersOfHanoi
    {
        // EOPI 16.1
        [TestMethod]
        public void TowersOfHanoiTest()
        {
            for (int i = 1; i <= 7; i++)
                TowersOfHanoi.Recursion(i);
        }

        private static void Recursion(int n)
        {
            Stack<int>[] towers = new Stack<int>[3];
            for (int i = 0; i < towers.Length; i++)
                towers[i] = new Stack<int>();

            for (int i = n; i > 0; i--)
                towers[0].Push(i);

            TowersOfHanoi.MoveTower(towers, 0, 2, 1, n);

            Assert.IsTrue(towers[0].Count == 0);
            Assert.IsTrue(towers[1].Count == 0);
            Assert.IsTrue(towers[2].Count == n);

            for(int i = 1; i <= n; i++)
            {
                int ring = towers[2].Pop();
                Assert.AreEqual(i, ring);
            }
        }

        private static void MoveTower(Stack<int>[] towers, int from, int to, int other, int depth)
        {
            if(depth > 0)
            {
                TowersOfHanoi.MoveTower(towers, from, other, to, depth - 1);
                towers[to].Push(towers[from].Pop());
                TowersOfHanoi.MoveTower(towers, other, to, from, depth - 1);
            }
        }
    }
}
