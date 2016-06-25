using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.GraphAlgorithms;

namespace AlgorithmTests.GraphAlgorithmTests
{
    [TestClass]
    public class SingleSourceShortestPathTestClass
    {
        [TestMethod]
        public void SingleSourceShortestPathTest()
        {
            int n = 10;
            int[,] graph = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    if(i != j)
                        graph[i, j] = int.MaxValue;
            }

            for (int i = 0; i <= n * n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    int[] bellmanFord = BellmanFord.Run(graph, j);
                    int[] djikstra = Djikstra.Run(graph, j);

                    for (int k = 0; k < n; k++)
                        Assert.AreEqual(bellmanFord[k], djikstra[k]);
                }

                TestUtilities.SetRandomEdge(graph, n);
            }
        }
    }
}
