using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public static class Kruskal
    {
        public static Graphs.Edge[] Run(Vertex[] vertices)
        {
            Dictionary<Vertex, List<Vertex>> sets = new Dictionary<Vertex, List<Vertex>>();
            foreach(Vertex v in vertices)
            {
                sets[v] = new List<Vertex>();
                sets[v].Add(v);
            }

            List<Graphs.Edge> results = new List<Graphs.Edge>();

            foreach(Graphs.Edge edge in vertices.SelectMany(v => v.Edges).OrderBy(e => e.Weight))
            {
                List<Vertex> from = sets[edge.From];
                List<Vertex> to = sets[edge.To];

                if(from != to)
                {
                    results.Add(edge);
                    foreach(Vertex v in to)
                    {
                        from.Add(v);
                        sets[v] = from;
                    }
                }
            }

            return results.ToArray();
        }
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
