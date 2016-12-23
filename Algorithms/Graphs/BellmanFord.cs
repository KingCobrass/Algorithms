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
                        if(e.From.Depth != int.MaxValue && e.From.Depth + e.Weight < e.To.Depth)
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
    }
}
