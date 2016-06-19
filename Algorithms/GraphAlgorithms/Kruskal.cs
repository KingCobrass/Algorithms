using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.GraphAlgorithms
{
    public static class Kruskal
    {
        private class Edge
        {
            public int From { get; set; }
            public int To { get; set; }
            public int Weight { get; set; }
        }

        public static int[,] Run(int[,] graph)
        {
            int n = graph.GetLength(0);
            if (n != graph.GetLength(1))
                throw new ArgumentException(nameof(graph));

            List<int>[] sets = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                sets[i] = new List<int>();
                sets[i].Add(i);
            }

            int[,] results = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                    results[i, j] = results[j, i] = int.MaxValue;
            }

            foreach(Edge edge in Kruskal.Edges(graph, n).OrderBy(e => e.Weight))
            {
                int from = edge.From;
                int to = edge.To;
                if(sets[from][0] != sets[to][0])
                {
                    results[from, to] = edge.Weight;
                    results[to, from] = edge.Weight;

                    foreach (int i in sets[to])
                    {
                        sets[from].Add(i);
                        sets[i] = sets[from];
                    }

                }
            }

            return results;
        }

        private static IEnumerable<Edge> Edges(int[,] graph, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int weight = graph[i, j];
                    if (weight != 0 && weight != int.MaxValue)
                        yield return new Edge { From = i, To = j, Weight = weight };
                }
            }
        }
    }
}
