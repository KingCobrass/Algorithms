using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public static class DepthFirstSearch
    {
        public static void Run(Vertex s)
        {
            if (s.Color != Color.White)
                return;

            s.Color = Color.Gray;

            foreach (Vertex next in s.Vertices)
            {
                if (next.Color == Color.White)
                {
                    next.Parent = s;
                    DepthFirstSearch.Run(next);
                }
            }

            s.Color = Color.Black;
        }
    }
}
