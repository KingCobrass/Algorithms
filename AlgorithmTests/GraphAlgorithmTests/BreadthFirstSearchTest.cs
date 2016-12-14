using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Graphs;
using Utilities;

namespace AlgorithmTests.GraphAlgorithmTests
{
    [TestClass]
    public class BreadthFirstSearchTestClass
    {
        [TestMethod]
        public void BreadthFirstSearchTest()
        {
            Func<Vertex[], int, int[]>[] functions = new Func<Vertex[], int, int[]>[]
            {
                BreadthFirstSearchTestClass.RunBreadthFirstSearch,
                BreadthFirstSearchTestClass.RunBellmanFord,
                BreadthFirstSearchTestClass.RunDjikstra,
                BreadthFirstSearchTestClass.RunFloydWarshall,
            };

            Vertex[] vertices = new Vertex[10];
            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = new Vertex();

            for (int i = 0; i <= vertices.Length * (vertices.Length - 1); i++)
            {
                for(int j = 0; j < vertices.Length; j++)
                {
                    int[][] results = new int[vertices.Length][];

                    for(int k = 0; k < functions.Length; k++)
                    {
                        foreach (Vertex vertex in vertices)
                            vertex.Reset();

                        results[k] = functions[k](vertices, j);
                        Assert.IsTrue(ArrayUtilities.AreEqual(results[0], results[k]));
                    }
                }

                GraphUtilities.SetRandomEdge(vertices);
            }
        }

        private static int[] RunBreadthFirstSearch(Vertex[] vertices, int source)
        {
            BreadthFirstSearch.Run(vertices[source]);
            return vertices.Select(v => v.Depth).ToArray();
        }

        private static int[] RunDjikstra(Vertex[] vertices, int source)
        {
            Djikstra.Run(vertices[source]);
            return vertices.Select(v => v.Depth).ToArray();
        }

        private static int[] RunBellmanFord(Vertex[] vertices, int source)
        {
            BellmanFord.Run(vertices, source);
            return vertices.Select(v => v.Depth).ToArray();
        }

        private static int[] RunFloydWarshall(Vertex[] vertices, int source)
        {
            int[,] depths = FloydWarshall.Run(vertices);
            return Enumerable.Range(0, vertices.Length).Select(i => depths[source, i]).ToArray();
        }
    }
}
