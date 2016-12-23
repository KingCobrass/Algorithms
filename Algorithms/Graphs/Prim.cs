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
            PriorityQueue<Node> queue = new MinPriorityQueue<Node>();

            vertices[0].Depth = 0;
            queue.Insert(new Node(vertices[0]));

            while(!queue.IsEmpty)
            {
                Vertex current = queue.Pop().Vertex;
                current.Color = Color.Black;

                foreach (Edge edge in current.Edges)
                {
                    if (edge.To.Color == Color.Black)
                        continue;

                    if (edge.To.Depth > edge.Weight)
                    {
                        edge.To.Depth = edge.Weight;
                        edge.To.Parent = current;
                        queue.Insert(new Node(edge.To));
                    }
                }
            }

            Edge[] results = new Edge[vertices.Length - 1];

            for(int i = 0; i < results.Length; i++)
            {
                foreach(Edge edge in vertices[i + 1].Edges)
                {
                    if(edge.To == vertices[i + 1].Parent)
                    {
                        results[i] = edge;
                        break;
                    }
                }
            }

            return results;
        }

        private class Node : IComparable<Node>
        {
            public Vertex Vertex { get; private set; }
            public int Priority { get; private set; }

            public Node(Vertex vertex)
            {
                this.Vertex = vertex;
                this.Priority = vertex.Depth;
            }

            public int CompareTo(Node other)
            {
                return this.Priority.CompareTo(other.Priority);
            }
        }
    }
}
