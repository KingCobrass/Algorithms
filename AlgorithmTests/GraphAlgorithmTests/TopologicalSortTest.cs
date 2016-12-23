using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Graphs;

namespace AlgorithmTests.GraphAlgorithmTests
{
    [TestClass]
    public class TopologicalSortTestClass
    {
        [TestMethod]
        public void TopologicalSortTest()
        {
            for(int n = 0; n < 5; n++)
            {
                Vertex[] vertices = TopologicalSortTestClass.CreateDirectedAcyclicGraph(n);
                Vertex[] order = TopologicalSort.Run(vertices);

                for (int i = n - 1; i >= 0; i--)
                {
                    foreach (Vertex v in vertices)
                        v.Reset();

                    DepthFirstSearch.Run(order[i]);
                    for (int j = 0; j < i; j++)
                        Assert.AreEqual(Color.White, order[j].Color);
                }
            }
        }

        private static Vertex[] CreateDirectedAcyclicGraph(int n)
        {
            Vertex[] vertices = new Vertex[n];

            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = new Vertex();

            for(int i = 0; i < vertices.Length; i++)
            {
                for (int j = 0; j < i; j++)
                    vertices[i].AddUnDirectedEdge(vertices[j]);
            }

            while (!TopologicalSortTestClass.IsDirectedAcyclicGraph(vertices))
                TopologicalSortTestClass.RemoveRandomEdge(vertices);

            foreach (Vertex v in vertices)
                v.Reset();

            return vertices;
        }

        private static void RemoveRandomEdge(Vertex[] vertices)
        {
            bool found = false;
            int i = 0;
            int j = 0;

            int count = 0;
            Random random = new Random();

            for (int k = 0; k < vertices.Length; k++)
            {
                for (int l = 0; l < vertices.Length; l++)
                {
                    count++;

                    if (random.Next(0, count) == 0)
                    {
                        found = true;
                        i = k;
                        j = l;
                    }
                }
            }

            if (found)
                vertices[i].RemoveDirectedEdge(vertices[j]);
        }

        private static bool IsDirectedAcyclicGraph(Vertex[] vertices)
        {
            foreach (Vertex v in vertices)
                v.Reset();

            return !vertices.Any(v => TopologicalSortTestClass.HasCycle(v));
        }

        private static bool HasCycle(Vertex vertex)
        {
            if (vertex.Color == Color.Gray)
                return true;

            if (vertex.Color == Color.Black)
                return false;

            vertex.Color = Color.Gray;

            if (vertex.Vertices.Any(v => TopologicalSortTestClass.HasCycle(v)))
                return true;

            vertex.Color = Color.Black;

            return false;
        }
    }
}
