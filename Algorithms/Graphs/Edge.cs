using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public class Edge
    {
        public Vertex From { get; }
        public Vertex To { get; }
        public int Weight { get; }

        public Edge(Vertex from, Vertex to, int weight)
        {
            this.From = from;
            this.To = to;
            this.Weight = weight;
        }
    }
}
