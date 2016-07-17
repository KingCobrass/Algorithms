using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.GraphAlgorithms
{
    public static class TopologicalSort
    {
        public static int[] Run(bool[,] graph)
        {
            int n = graph.GetLength(0);
            if (n != graph.GetLength(1))
                throw new ArgumentException(nameof(graph));

            bool[] started = new bool[n];
            bool[] finished = new bool[n];
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
                TopologicalSort.Search(graph, n, i, started, finished, list);

            return list.ToArray();
        }

        private static void Search(bool[,] graph, int n, int current, bool[] started, bool[] finished, List<int> list)
        {
            if (started[current])
                return;

            started[current] = true;

            for (int i = 0; i < n; i++)
            {
                if (graph[current, i])
                {
                    if (started[i] && !finished[i])
                        throw new ArgumentException(nameof(graph));

                    TopologicalSort.Search(graph, n, i, started, finished, list);
                }
            }

            finished[current] = true;
            list.Insert(0, current);
        }
    }
}
