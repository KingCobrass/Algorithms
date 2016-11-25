using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Graphs
{
    // CTCI 4.1
    [TestClass]
    public class RouteBetweenNodes
    {
        [TestMethod]
        public void RouteBetweenNodesTest()
        {
            int n = 10;

            Func<bool[,], int, int, bool>[] functions = new Func<bool[,], int, int, bool>[]
            {
                RouteBetweenNodes.BFS,
                RouteBetweenNodes.DFS
            };

            for(int i = 0; i < 10; i++)
            {
                bool[,] graph = new bool[n, n];

                for(int j = 0; j < n * n; j++)
                {
                    GraphUtilities.SetRandomEdge(graph, n);
                    Tests.TestFunctions(graph, 0, n - 1, functions);
                }
            }
        }

        private static bool BFS(bool[,] graph, int start, int end)
        {
            bool[] visited = new bool[graph.GetLength(0)];

            Queue<int> queue = new Queue<int>();

            visited[start] = true;
            queue.Enqueue(start);

            while(queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (current == end)
                    return true;

                for(int j = 0; j < graph.GetLength(0); j++)
                {
                    if (visited[j] || !graph[current, j])
                        continue;

                    visited[j] = true;
                    queue.Enqueue(j);
                }
            }

            return false;
        }

        private static bool DFS(bool[,] graph, int start, int end)
        {
            return RouteBetweenNodes.Search(graph, new bool[graph.GetLength(0)], start, end);
        }

        private static bool Search(bool[,] graph, bool[] visited, int current, int end)
        {
            if (current == end)
                return true;

            if (visited[current])
                return false;

            visited[current] = true;

            for(int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[current, i] && Search(graph, visited, i, end))
                    return true;
            }

            return false;
        }
    }
}
