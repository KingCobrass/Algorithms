using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public static class FloydWarshall
    {
        public static int[,] Run(Vertex[] vertices)
        {
            int[,] depths = new int[vertices.Length, vertices.Length];
            for (int i = 0; i < depths.GetLength(0); i++)
            {
                for (int j = 0; j < depths.GetLength(1); j++)
                {
                    if(i != j)
                        depths[i, j] = int.MaxValue;
                }
            }

            for(int i = 0; i < vertices.Length; i++)
            {
                foreach(Edge edge in vertices[i].Edges)
                {
                    int j = 0;
                    while (j < vertices.Length && vertices[j] != edge.To)
                        j++;

                    depths[i, j] = edge.Weight;
                }
            }

            for (int i = 0; i < vertices.Length; i++)
            {
                for (int j = 0; j < vertices.Length; j++)
                {
                    for (int k = 0; k < vertices.Length; k++)
                    {
                        if(depths[j, i] != int.MaxValue && depths[i, k] != int.MaxValue)
                            depths[j, k] = Math.Min(depths[j, k], depths[j, i] + depths[i, k]);
                    }
                }
            }

            return depths;
        }
    }
}
