using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.GraphAlgorithms
{
    public static class BreadthFirstSearch
    {
        public static int[] Run(bool[,] graph, int start)
        {
            int n = graph.GetLength(0);
            if (n != graph.GetLength(1))
                throw new ArgumentException(nameof(graph));

            if (start >= n)
                throw new ArgumentException(nameof(start));

            int[] depths = new int[n];
            for (int i = 0; i < n; i++)
                depths[i] = int.MaxValue;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            depths[start] = 0;

            while(queue.Count > 0)
            {
                int current = queue.Dequeue();
                for(int i = 0; i < n; i++)
                {
                    if (!graph[current, i] || depths[i] != int.MaxValue)
                        continue;

                    depths[i] = depths[current] + 1;

                    queue.Enqueue(i);
                }
            }

            return depths;
        }
    }
}
