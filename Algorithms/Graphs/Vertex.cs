using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public enum Color
    {
        White,
        Gray,
        Black
    }

    public class Vertex
    {
        List<Edge> edges = new List<Edge>();

        public Color Color { get; set; }
        public int Depth { get; set; }
        public Vertex Parent { get; set; }

        public Vertex()
        {
            this.Reset();
        }

        public IEnumerable<Edge> Edges
        {
            get
            {
                return this.edges;
            }
        }

        public IEnumerable<Vertex> Vertices
        {
            get
            {
                return this.Edges.Select(e => e.To);
            }
        }

        public void AddDirectedEdge(Vertex to, int weight = 1)
        {
            this.edges.Add(new Edge(this, to, weight));
        }

        public void AddUnDirectedEdge(Vertex to, int weight = 1)
        {
            this.AddDirectedEdge(to, weight);
            to.AddDirectedEdge(this, weight);
        }

        public void Reset()
        {
            this.Color = Color.White;
            this.Depth = int.MaxValue;
            this.Parent = null;
        }
    }
}
