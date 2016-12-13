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
            Vertex[] vertices = new Vertex[10];
            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = new Vertex();

            for (int i = 0; i <= vertices.Length * (vertices.Length - 1); i++)
            {
                int[,] allPaths = FloydWarshall.Run(vertices);

                for (int j = 0; j < vertices.Length; j++)
                {
                    BreadthFirstSearch.Run(vertices[j]);
                    for (int k = 0; k < vertices.Length; k++)
                    {
                        Assert.IsFalse(vertices[k].Color == Color.Gray);
                        Assert.AreEqual(vertices[k].Color == Color.White, vertices[k].Depth == int.MaxValue);
                        Assert.AreEqual(vertices[k].Depth, allPaths[j, k]);
                    }

                    foreach (Vertex vertex in vertices)
                        vertex.Reset();
                }

                GraphUtilities.SetRandomEdge(vertices);
            }
        }
    }
}
