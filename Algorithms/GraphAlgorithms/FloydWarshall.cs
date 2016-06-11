using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.GraphAlgorithms
{
    public static class FloydWarshall
    {
        public static int[,] Run(int[,] graph)
        {
            int n = graph.GetLength(0);
            if (n != graph.GetLength(1))
                throw new ArgumentException(nameof(graph));

            int[,] results = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    results[i, j] = graph[i, j];
            }

            for(int k = 0; k < n; k++)
            {
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        if (results[i, k] != int.MaxValue && results[k, j] != int.MaxValue)
                            results[i, j] = Math.Min(results[i, j], results[i, k] + results[k, j]);
                    }
                }
            }

            return results;
        }
    }
}
