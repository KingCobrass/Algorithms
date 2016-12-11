using System;
using Algorithms.DataStructures;

namespace Algorithms.Graphs
{
    public static class Djikstra
    {
        public static void Run(Vertex vertex)
        {
            vertex.Depth = 0;
            PriorityQueue<Vertex> queue = new PriorityQueue<Vertex>((x, y) => y.Depth.CompareTo(x.Depth));

            queue.Insert(vertex);
            while(!queue.IsEmpty)
            {
                Vertex current = queue.Pop();
                foreach(Edge edge in current.Edges)
                {
                    if(edge.From.Depth + edge.Weight < edge.To.Depth)
                    {
                        edge.To.Depth = edge.From.Depth + edge.Weight;
                        edge.To.Parent = edge.From;
                        queue.Insert(edge.To);
                    }
                }
            }
        }

        public static int[] Run(int[,] graph, int start)
        {
            int n = graph.GetLength(0);
            if (n != graph.GetLength(1))
                throw new ArgumentException(nameof(graph));

            if (start < 0 || start > n)
                throw new ArgumentException(nameof(start));

            int[] depths = new int[n];
            for (int i = 0; i < depths.Length; i++)
                depths[i] = int.MaxValue;

            depths[start] = 0;
            MinPriorityQueue<Node> queue = new MinPriorityQueue<Node>();
                queue.Insert(new Node { Index = start, Depth = 0 });

            bool[] visited = new bool[n];

            while(!queue.IsEmpty)
            {
                Node node = queue.Pop();
                int current = node.Index;

                if (visited[current])
                    continue;

                visited[current] = true;

                for(int i = 0; i < n; i++)
                {
                    int weight = graph[current, i];
                    if (weight == int.MaxValue)
                        continue;

                    int depth = depths[current] + weight;

                    if(depths[i] > depth)
                    {
                        depths[i] = depth;
                        queue.Insert(new Node { Index = i, Depth = depth });
                    }
                }
            }

            return depths;
        }

        private class Node : IComparable<Node>
        {
            public int Index { get; set; }
            public int Depth { get; set; }

            public int CompareTo(Node other)
            {
                return this.Depth.CompareTo(other.Depth);
            }
        }
    }
}
