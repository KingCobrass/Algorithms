using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public static class BreadthFirstSearch
    {
        public static void Run(Vertex s)
        {
            s.Color = Color.Gray;
            s.Depth = 0;

            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(s);

            while(queue.Count > 0)
            {
                Vertex current = queue.Dequeue();
                foreach(Vertex next in current.Vertices)
                {
                    if(next.Color == Color.White)
                    {
                        next.Color = Color.Gray;
                        next.Depth = current.Depth + 1;
                        next.Parent = current;
                        queue.Enqueue(next);
                    }
                }

                current.Color = Color.Black;
            }
        }
    }
}
