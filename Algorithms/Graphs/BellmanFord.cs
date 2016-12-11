using System;
using System.Linq;

namespace Algorithms.Graphs
{
    public static class BellmanFord
    {
        public static bool Run(Vertex[] vertices, int source)
        {
            vertices[source].Depth = 0;

            for (int i = 0; i < vertices.Length; i++)
            {
                foreach(Vertex v in vertices)
                {
                    foreach(Edge e in v.Edges)
                    {
                        if(e.From.Depth + e.Weight < e.To.Depth)
                        {
                            e.To.Depth = e.From.Depth + e.Weight;
                            e.To.Parent = e.From;
                        }
                    }
                }
            }

            foreach (Vertex v in vertices)
            {
                foreach (Edge e in v.Edges)
                {
                    if(e.From.Depth + e.Weight < e.To.Depth)
                        return false;
                }
            }

            return true;
        }

        public static int[] Run(int[,] graph, int start)
        {
            int n = graph.GetLength(0);
            if (n != graph.GetLength(1))
                throw new ArgumentException(nameof(graph));

            if(start < 0 || start > n)
                throw new ArgumentException(nameof(start));

            int[] depths = new int[n];

            for (int i = 0; i < depths.Length; i++)
                depths[i] = int.MaxValue;

            depths[start] = 0;

            for(int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (depths[j] == int.MaxValue)
                        continue;

                    for (int k = 0; k < n; k++)
                    {
                        if (graph[j, k] == int.MaxValue)
                            continue;

                        depths[k] = Math.Min(depths[k], depths[j] + graph[j, k]);
                    }
                }
            }

            return depths;
        }
    }
}
