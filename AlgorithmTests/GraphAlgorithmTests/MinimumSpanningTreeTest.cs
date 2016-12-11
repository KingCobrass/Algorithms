using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Graphs;

namespace AlgorithmTests.GraphAlgorithmTests
{
    [TestClass]
    public class MinimumSpanningTreeTestClass
    {
        [TestMethod]
        public void MinimumSpanningTreeTest()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int n = 1; n <= 10; n++)
                {
                    int[,] graph = MinimumSpanningTreeTestClass.CreateSpanningTree(n);
                    int[,] minimimSpanningTreeKruskal = Kruskal.Run(graph);
                    int[,] minimumSpanningTreePrim = Prim.Run(graph);

                    int kruskalLength = MinimumSpanningTreeTestClass.Length(minimimSpanningTreeKruskal, n);
                    int primLength = MinimumSpanningTreeTestClass.Length(minimumSpanningTreePrim, n);

                    Assert.AreEqual(kruskalLength, primLength);
                }
            }
        }

        private static int[,] CreateSpanningTree(int n)
        {
            int[,] graph = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    graph[i, j] = (i == j) ? 0 : int.MaxValue;
            }

            while (!MinimumSpanningTreeTestClass.IsSpanningTree(graph, n))
                MinimumSpanningTreeTestClass.AddRandomWeightedEdge(graph, n, 10);

            return graph;
        }

        private static void AddRandomWeightedEdge(int[,] graph, int n, int maxWeight)
        {
            bool found = false;
            int i = 0;
            int j = 0;

            int count = 0;
            Random random = new Random();

            for (int k = 0; k < n; k++)
            {
                for (int l = k + 1; l < n; l++)
                {
                    if (graph[k, l] != int.MaxValue)
                        continue;

                    count++;

                    if (random.Next(0, count) == 0)
                    {
                        found = true;
                        i = k;
                        j = l;
                    }
                }
            }

            if (found)
                graph[i, j] = graph[j, i] = random.Next(1, maxWeight + 1);
        }

        private static bool IsSpanningTree(int[,] graph, int n)
        {
            bool[,] paths = new bool[n, n];
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    paths[i, j] = (graph[i, j] != int.MaxValue);
            }

            bool[] visited = DepthFirstSearch.Run(paths, 0);
            return visited.All(b => b);
        }

        private static int Length(int[,] spanningTree, int n)
        {
            int length = 0;

            for(int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int weight = spanningTree[i, j];
                    if(weight != int.MaxValue)
                        length += weight;
                }
            }

            return length;
        }
    }
}
