using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public static class TopologicalSort
    {
        public static Vertex[] Run(Vertex[] vertices)
        {
            List<Vertex> list = new List<Vertex>();

            foreach(Vertex v in vertices)
                TopologicalSort.Run(v, list);

            return list.ToArray();
        }

        private static void Run(Vertex vertex, List<Vertex> list)
        {
            if (vertex.Color != Color.White)
                return;

            vertex.Color = Color.Gray;

            foreach(Vertex next in vertex.Vertices)
            {
                if(next.Color == Color.White)
                {
                    next.Parent = vertex;
                    TopologicalSort.Run(next, list);
                }
            }

            vertex.Color = Color.Black;
            list.Insert(0, vertex);
        }

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
