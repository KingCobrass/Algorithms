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
            this.Color = Color.White;
            this.Depth = int.MaxValue;
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

        public void AddEdge(Vertex to, bool directed = true)
        {
            this.edges.Add(new Edge { From = this, To = to });
            if (!directed)
                to.AddEdge(this, false);
        }
    }
}
