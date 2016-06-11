using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.GraphAlgorithms;

namespace AlgorithmTests.GraphAlgorithmTests
{
    [TestClass]
    public class DepthFirstSearchTestClass
    {
        [TestMethod]
        public void DepthFirstSearchTest()
        {
            int n = 10;
            bool[,] graph = new bool[n, n];

            for(int i = 0; i <= n * n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    bool[] expected = BreadthFirstSearch.Run(graph, j).Select(k => k != int.MaxValue).ToArray();
                    bool[] actual = DepthFirstSearch.Run(graph, j);

                    for (int k = 0; k < n; k++)
                        Assert.AreEqual(expected[k], actual[k]);
                }

                TestUtilities.SetRandomEdge(graph, n);
            }
        }

        private static bool[] CreateAllVisited(bool[,] graph, int start, int n)
        {
            int[] depths = BreadthFirstSearch.Run(graph, start);
            return depths.Select(i => i != int.MaxValue).ToArray();
        }
    }
}
