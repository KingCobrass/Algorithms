using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Graphs;
using Utilities;

namespace AlgorithmTests.GraphAlgorithmTests
{
    [TestClass]
    public class MinimumSpanningTreeTestClass
    {
        [TestMethod]
        public void MinimumSpanningTreeTest()
        {
            Func<Vertex[], int>[] functions = new Func<Vertex[], int>[]
            {
                MinimumSpanningTreeTestClass.RunPrim,
                MinimumSpanningTreeTestClass.RunKruskal
            };
            
            for(int i = 0; i < 10; i++)
            {
                for(int n = 1; n <= 10; n++)
                {
                    Vertex[] vertices = MinimumSpanningTreeTestClass.CreateSpanningTree(n);
                    Tests.TestFunctions(vertices, functions);
                }
            }
        }

        private static int RunPrim(Vertex[] vertices)
        {
            foreach (Vertex v in vertices)
                v.Reset();

            return Prim.Run(vertices).Sum(e => e.Weight);
        }

        private static int RunKruskal(Vertex[] vertices)
        {
            foreach (Vertex v in vertices)
                v.Reset();

            return Kruskal.Run(vertices).Sum(e => e.Weight);
        }

        private static Vertex[] CreateSpanningTree(int n)
        {
            Vertex[] vertices = new Vertex[n];
            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = new Vertex();


            while (!MinimumSpanningTreeTestClass.IsSpanningTree(vertices))
                MinimumSpanningTreeTestClass.AddRandomWeightedEdge(vertices, 10);

            return vertices;
        }

        private static void AddRandomWeightedEdge(Vertex[] vertices, int maxWeight)
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
                    if (k == l || vertices[k].Vertices.Any(v => v == vertices[l]))
                        continue;

                    count++;
                    if (random.Next(0, count) == 0)
                    {
                        i = k;
                        j = l;
                        found = true;
                    }
                }
            }

            if (found)
                vertices[i].AddUnDirectedEdge(vertices[j], random.Next(1, maxWeight + 1));
        }

        private static bool IsSpanningTree(Vertex[] vertices)
        {
            foreach (Vertex v in vertices)
                v.Reset();

            DepthFirstSearch.Run(vertices[0]);

            return vertices.All(v => v.Color == Color.Black);
        }
    }
}
