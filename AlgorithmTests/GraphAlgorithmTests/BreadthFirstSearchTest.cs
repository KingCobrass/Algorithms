using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.GraphAlgorithms;
using Utilities;

namespace AlgorithmTests.GraphAlgorithmTests
{
    [TestClass]
    public class BreadthFirstSearchTestClass
    {
        [TestMethod]
        public void BreadthFirstSearchTest()
        {
            int n = 10;
            bool[,] graph = new bool[n, n];

            for(int i = 0; i <= n * n; i++)
            {
                int[,] allPaths = BreadthFirstSearchTestClass.CreateAllPathsGraph(graph, n);

                for (int j = 0; j < n; j++)
                {
                    int[] depths = BreadthFirstSearch.Run(graph, j);
                    for (int k = 0; k < n; k++)
                        Assert.AreEqual(allPaths[j, k], depths[k]);
                }

                GraphUtilities.SetRandomEdge(graph, n);
            }
        }

        private static int[,] CreateAllPathsGraph(bool[,] graph, int n)
        {
            int[,] weightedGraph = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                        weightedGraph[i, j] = graph[i, j] ? 1 : int.MaxValue;
                }
            }

            return FloydWarshall.Run(weightedGraph);
        }
    }
}
