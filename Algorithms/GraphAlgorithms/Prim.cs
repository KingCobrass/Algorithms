using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.DataStructures;

namespace Algorithms.GraphAlgorithms
{
    public static class Prim
    {
        public static int[,] Run(int[,] graph)
        {
            int n = graph.GetLength(0);
            if (n != graph.GetLength(1))
                throw new ArgumentException(nameof(graph));

            int[,] results = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                    results[i, j] = results[j, i] = int.MaxValue;
            }

            int[] parents = new int[n];
            for(int i = 1; i < n; i++)
                parents[i] = -1;

            int[] priorities = new int[n];
            for (int i = 1; i < priorities.Length; i++)
                priorities[i] = int.MaxValue;

            bool[] visited = new bool[n];

            PriorityQueue<int> queue = new PriorityQueue<int>(n * n, (x, y) => y.CompareTo(x));
            queue.Insert(0, 0);

            while(!queue.IsEmpty)
            {
                int current = queue.Pop();
                if (visited[current])
                    continue;

                visited[current] = true;

                results[current, parents[current]] = results[parents[current], current] = graph[current, parents[current]];

                for (int i = 0; i < n; i++)
                {
                    if (visited[i])
                        continue;

                    int weight = graph[current, i];
                    if (weight == int.MaxValue)
                        continue;

                    if(weight < priorities[i])
                    {
                        priorities[i] = weight;
                        parents[i] = current;
                    }

                    queue.Insert(i, priorities[i]);
                }
            }

            return results;
        }
    }
}
