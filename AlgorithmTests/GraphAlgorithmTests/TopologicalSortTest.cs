using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.GraphAlgorithms;

namespace AlgorithmTests.GraphAlgorithmTests
{
    [TestClass]
    public class TopologicalSortTestClass
    {
        [TestMethod]
        public void TopologicalSortTest()
        {
            int n = 10;

            for(int i = 0; i < 10; i++)
            {
                bool[,] graph = TopologicalSortTestClass.CreateDirectedAcyclicGraph(n);

                int[] order = TopologicalSort.Run(graph);

                for (int j = n - 1; j >= 0; j--)
                {
                    bool[] visited = DepthFirstSearch.Run(graph, order[j]);
                    for (int k = 0; k < j; k++)
                        Assert.IsFalse(visited[order[k]]);
                }
            }
        }

        private static bool[,] CreateDirectedAcyclicGraph(int n)
        {
            bool[,] graph = new bool[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(i != j)
                        graph[i, j] = true;
                }
            }

            while (!TopologicalSortTestClass.IsDirectedAcyclicGraph(graph, n))
                TopologicalSortTestClass.RemoveRandomEdge(graph, n);

            return graph;
        }

        private static void RemoveRandomEdge(bool[,] graph, int n)
        {
            bool found = false;
            int i = 0;
            int j = 0;

            int count = 0;
            Random random = new Random();

            for (int k = 0; k < n; k++)
            {
                for (int l = 0; l < n; l++)
                {
                    if (!graph[k, l])
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
                graph[i, j] = false;
        }

        private static bool IsDirectedAcyclicGraph(bool[,] graph, int n)
        {
            bool[] visiting = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (TopologicalSortTestClass.HasCycle(graph, n, i, visiting))
                    return false;
            }

            return true;
        }

        private static bool HasCycle(bool[,] graph, int n, int current, bool[] visiting)
        {
            if (visiting[current])
                return true;

            visiting[current] = true;

            for (int i = 0; i < n; i++)
            {
                if(graph[current, i] && TopologicalSortTestClass.HasCycle(graph, n, i, visiting))
                    return true;
            }

            visiting[current] = false;

            return false;
        }
    }
}
