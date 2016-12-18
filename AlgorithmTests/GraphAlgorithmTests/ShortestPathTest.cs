using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Graphs;
using Utilities;

namespace AlgorithmTests.ShortestPathTest
{
    [TestClass]
    public class ShortestPathTestClass
    {
        [TestMethod]
        public void ShortestPathTest()
        {
            Func<Vertex[], int[,]>[] functions = new Func<Vertex[], int[,]>[]
            {
                ShortestPathTestClass.RunBellmanFord,
                ShortestPathTestClass.RunDjikstra,
                ShortestPathTestClass.RunFloydWarshall,
            };

            Vertex[] vertices = new Vertex[10];
            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = new Vertex();

            for (int i = 0; i <= vertices.Length * (vertices.Length - 1); i++)
            {
                for (int j = 0; j < vertices.Length; j++)
                {
                    int[][,] results = new int[vertices.Length][,];

                    for (int k = 0; k < functions.Length; k++)
                    {
                        foreach (Vertex vertex in vertices)
                            vertex.Reset();

                        results[k] = functions[k](vertices);
                        Assert.IsTrue(ArrayUtilities.AreEqual(results[0], results[k]));
                    }
                }

                GraphUtilities.SetRandomEdge(vertices);
            }
        }

        private static int[,] RunDjikstra(Vertex[] vertices)
        {
            int[,] paths = new int[vertices.Length, vertices.Length];

            for (int i = 0; i < vertices.Length; i++)
            {
                ShortestPathTestClass.ResetAllVertices(vertices);
                Djikstra.Run(vertices[i]);
                for (int j = 0; j < vertices.Length; j++)
                    paths[i, j] = vertices[j].Depth;
            }

            return paths;
        }

        private static int[,] RunBellmanFord(Vertex[] vertices)
        {
            int[,] paths = new int[vertices.Length, vertices.Length];

            for(int i = 0; i < vertices.Length; i++)
            {
                ShortestPathTestClass.ResetAllVertices(vertices);
                BellmanFord.Run(vertices, i);
                for (int j = 0; j < vertices.Length; j++)
                    paths[i, j] = vertices[j].Depth;
            }

            return paths;
        }

        private static int[,] RunFloydWarshall(Vertex[] vertices)
        {
            return FloydWarshall.Run(vertices);
        }

        private static void ResetAllVertices(Vertex[] vertices)
        {
            foreach (Vertex v in vertices)
                v.Reset();
        }
    }
}
