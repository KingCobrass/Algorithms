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
    }
}
