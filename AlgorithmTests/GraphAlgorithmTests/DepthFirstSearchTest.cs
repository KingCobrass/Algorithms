using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Graphs;
using Utilities;

namespace AlgorithmTests.GraphAlgorithmTests
{
    [TestClass]
    public class DepthFirstSearchTestClass
    {
        [TestMethod]
        public void DepthFirstSearchTest()
        {
            Func<Vertex[], int, bool[]>[] functions = new Func<Vertex[], int, bool[]>[]
            {
                DepthFirstSearchTestClass.RunDepthFirstSearch,
                DepthFirstSearchTestClass.RunBreadthFirstSearch,
                DepthFirstSearchTestClass.RunBellmanFord,
                DepthFirstSearchTestClass.RunDjikstra,
                DepthFirstSearchTestClass.RunFloydWarshall,
            };

            Vertex[] vertices = new Vertex[10];
            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = new Vertex();

            for (int i = 0; i <= vertices.Length * (vertices.Length - 1); i++)
            {
                for (int j = 0; j < vertices.Length; j++)
                {
                    bool[][] results = new bool[vertices.Length][];

                    for (int k = 0; k < functions.Length; k++)
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

        private static bool[] RunDepthFirstSearch(Vertex[] vertices, int source)
        {
            DepthFirstSearch.Run(vertices[source]);
            return vertices.Select(v => v.Color == Color.Black).ToArray();
        }

        private static bool[] RunBreadthFirstSearch(Vertex[] vertices, int source)
        {
            BreadthFirstSearch.Run(vertices[source]);
            return vertices.Select(v => v.Color == Color.Black).ToArray();
        }

        private static bool[] RunDjikstra(Vertex[] vertices, int source)
        {
            Djikstra.Run(vertices[source]);
            return vertices.Select(v => v.Depth != int.MaxValue).ToArray();
        }

        private static bool[] RunBellmanFord(Vertex[] vertices, int source)
        {
            BellmanFord.Run(vertices, source);
            return vertices.Select(v => v.Depth != int.MaxValue).ToArray();
        }

        private static bool[] RunFloydWarshall(Vertex[] vertices, int source)
        {
            int[,] depths = FloydWarshall.Run(vertices);
            return Enumerable.Range(0, vertices.Length).Select(i => depths[source, i] != int.MaxValue).ToArray();
        }
    }
}
