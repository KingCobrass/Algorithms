using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public static class Kruskal
    {
        public static Edge[] Run(Vertex[] vertices)
        {
            Dictionary<Vertex, List<Vertex>> sets = new Dictionary<Vertex, List<Vertex>>();
            foreach(Vertex v in vertices)
            {
                sets[v] = new List<Vertex>();
                sets[v].Add(v);
            }

            List<Edge> results = new List<Edge>();

            foreach(Edge edge in vertices.SelectMany(v => v.Edges).OrderBy(e => e.Weight))
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
    }
}
