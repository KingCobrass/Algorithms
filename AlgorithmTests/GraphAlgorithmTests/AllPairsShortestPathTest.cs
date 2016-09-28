using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.GraphAlgorithms;
using Utilities;

namespace AlgorithmTests.GraphAlgorithmTests
{
    [TestClass]
    public class AllPairsShortestPathTestClass
    {
        [TestMethod]
        public void AllPairsShortestPathTest()
        {
            int n = 10;
            int[,] graph = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    if (i != j)
                        graph[i, j] = int.MaxValue;
            }

            for (int i = 0; i <= n * n; i++)
            {
                int[,] floydWarshall = FloydWarshall.Run(graph);
                for(int j = 0; j < n; j++)
                {
                    int[] djikstra = Djikstra.Run(graph, j);

                    for (int k = 0; k < n; k++)
                        Assert.AreEqual(floydWarshall[j, k], djikstra[k]);
                }

                Graphs.SetRandomEdge(graph, n);
            }
        }
    }
}
