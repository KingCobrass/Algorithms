using System;
using Algorithms.DataStructures;

namespace Algorithms.GraphAlgorithms
{
    public static class Djikstra
    {
        public static int[] Run(int[,] graph, int start)
        {
            int n = graph.GetLength(0);
            if (n != graph.GetLength(1))
                throw new ArgumentException(nameof(graph));

            if (start < 0 || start > n)
                throw new ArgumentException(nameof(start));

            int[] depths = new int[n];
            for (int i = 0; i < depths.Length; i++)
                depths[i] = int.MaxValue;

            depths[start] = 0;
            PriorityQueue<int> queue = new PriorityQueue<int>(n * n, (x, y) => y.CompareTo(x));
                queue.Insert(start, 0);

            bool[] visited = new bool[n];

            while(!queue.IsEmpty)
            {
                int current = queue.Pop();

                if (visited[current])
                    continue;

                visited[current] = true;

                for(int i = 0; i < n; i++)
                {
                    int weight = graph[current, i];
                    if (weight == int.MaxValue)
                        continue;

                    int depth = depths[current] + weight;

                    if(depths[i] > depth)
                    {
                        depths[i] = depth;
                        queue.Insert(i, depth);
                    }
                }
            }

            return depths;
        }
    }
}
