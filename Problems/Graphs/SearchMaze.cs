using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Graphs
{
    // EOPI 19.1
    [TestClass]
    public class SearchMaze
    {
        [TestMethod]
        public void SearchMazeTest()
        {
            Func<bool[,], Cell, Cell, bool>[] functions = new Func<bool[,], Cell, Cell, bool>[]
            {
                SearchMaze.BFS,
                SearchMaze.DFS
            };

            int n = 6;
            bool[,] maze = new bool[n, n];
            maze[0, 0] = true;
            maze[n - 1, n - 1] = true;

            for(int i = 0; i < n * n - 2; i++)
            {
                Utilities.GraphUtilities.SetRandomEdge(maze, n);
                Tests.TestFunctions(maze, new Cell { X = 0, Y = 0 }, new Cell { X = n - 1, Y = n - 1 }, functions);
            }
        }

        private static int[] Deltas = new int[] { 0, 1, 0, -1, 0 };

        private static bool BFS(bool[,] graph, Cell start, Cell end)
        {
            bool[,] visited = new bool[graph.GetLength(0), graph.GetLength(1)];
            Queue<Cell> queue = new Queue<Cell>();
            visited[start.X, start.Y] = true;
            queue.Enqueue(start);

            while(queue.Count > 0)
            {
                Cell current = queue.Dequeue();
                if (current.X == end.X && current.Y == end.Y)
                    return true;

                for(int i = 0; i < 4; i++)
                {
                    int x = current.X + Deltas[i];
                    int y = current.Y + Deltas[i + 1];

                    if (x < 0 || x >= visited.GetLength(0))
                        continue;

                    if (y < 0 || y >= visited.GetLength(1))
                        continue;

                    if (visited[x, y] || !graph[x, y])
                        continue;

                    visited[x, y] = true;
                    queue.Enqueue(new Cell { X = x, Y = y });
                }
            }

            return false;
        }

        private static bool DFS(bool[,] graph, Cell start, Cell end)
        {
            bool[,] visited = new bool[graph.GetLength(0), graph.GetLength(1)];
            return SearchMaze.Search(graph, visited, start, end);
        }

        private static bool Search(bool[,] graph, bool[,] visited, Cell current, Cell end)
        {
            if (current.X == end.X && current.Y == end.Y)
                return true;

            for(int i = 0; i < 4; i++)
            {
                int x = current.X + Deltas[i];
                int y = current.Y + Deltas[i + 1];

                if (x < 0 || x >= visited.GetLength(0))
                    continue;

                if (y < 0 || y >= visited.GetLength(0))
                    continue;

                if (visited[x, y] || !graph[x, y])
                    continue;

                visited[x, y] = true;

                if (SearchMaze.Search(graph, visited, new Cell { X = x, Y = y }, end))
                    return true;
            }

            return false;
        }

        private class Cell
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
