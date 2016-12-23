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
    }
}
