using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.DataStructures;

namespace Algorithms.Graphs
{
    public static class Prim
    {
        public static Edge[] Run(Vertex[] vertices)
        {
            PriorityQueue<Vertex> queue = new PriorityQueue<Vertex>((x, y) => y.Depth.CompareTo(x.Depth));
            List<Edge> results = new List<Edge>();

            vertices[0].Depth = 0;
            queue.Insert(vertices[0]);

            while(!queue.IsEmpty)
            {
                Vertex current = queue.Pop();
                current.Color = Color.Black;

                foreach (Edge edge in current.Edges)
                {
                    if (edge.To.Color == Color.Black)
                        continue;

                    if (edge.To.Depth > edge.Weight)
                    {
                        edge.To.Depth = edge.Weight;
                        queue.Insert(edge.To);
                        results.Add(edge);
                    }
                }
            }

            return results.ToArray();
        }

        private class VertexNode : IComparable<VertexNode>
        {
            public Vertex Vertex { get; private set; }
            public int CompareTo(VertexNode other)
            {
                throw new NotImplementedException();
            }
        }

        public static int[,] Run(int[,] graph)
        {
            int n = graph.GetLength(0);
            if (n != graph.GetLength(1))
                throw new ArgumentException(nameof(graph));

            int[,] results = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                    results[i, j] = results[j, i] = int.MaxValue;
            }

            int[] parents = new int[n];

            int[] priorities = new int[n];
            for (int i = 1; i < priorities.Length; i++)
                priorities[i] = int.MaxValue;

            bool[] visited = new bool[n];

            MinPriorityQueue<Node> queue = new MinPriorityQueue<Node>();
            queue.Insert(new Node { Index = 0, Priority = 0 });

            while(!queue.IsEmpty)
            {
                Node node = queue.Pop();
                int current = node.Index;
                if (visited[current])
                    continue;

                visited[current] = true;

                results[current, parents[current]] = results[parents[current], current] = graph[current, parents[current]];

                for (int i = 0; i < n; i++)
                {
                    if (visited[i])
                        continue;

                    int weight = graph[current, i];
                    if (weight == int.MaxValue)
                        continue;

                    if(weight < priorities[i])
                    {
                        priorities[i] = weight;
                        parents[i] = current;
                    }

                    queue.Insert(new Node { Index = i, Priority = priorities[i] });
                }
            }

            return results;
        }

        private class Node : IComparable<Node>
        {
            public int Index { get; set; }
            public int Priority { get; set; }

            public int CompareTo(Node other)
            {
                return this.Priority.CompareTo(other.Priority);
            }
        }
    }
}
