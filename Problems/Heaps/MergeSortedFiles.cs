using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.Heaps
{
    [TestClass]
    public class MergedSortedFiles
    {
        [TestMethod]
        public void MergedSortedFilesTest()
        {
            Func<int[][], int[]>[] functions = new Func<int[][], int[]>[]
            {
                MergedSortedFiles.BruteForce,
                MergedSortedFiles.PriorityQueue
            };

            for(int i = 0; i < 10; i++)
            {
                int[] array = ArrayUtilities.CreateRandomArray(100, 0, 100);
                int[][] data = new int[10][];

                for(int j = 0; j < 10; j++)
                {
                    data[j] = new int[10];
                    Array.Copy(array, j * 10, data[j], 0, 10);
                    Array.Sort(data[j]);
                }

                int[][] results = new int[functions.Length][];

                for(int j = 0; j < functions.Length; j++)
                {
                    results[j] = functions[j](data);
                    Assert.IsTrue(ArrayUtilities.AreEqual(results[0], results[j]));
                }
            }
        }

        private static int[] BruteForce(int[][] data)
        {
            int[] results = new int[data.Sum(s => s.Length)];
            int i = 0;

            foreach (int[] array in data)
            {
                Array.Copy(array, 0, results, i, array.Length);
                i += array.Length;
            }

            Array.Sort(results);
            return results;
        }

        private static int[] PriorityQueue(int[][] data)
        {
            MinPriorityQueue<Indices> queue = new MinPriorityQueue<Indices>();
            foreach(int[] array in data)
            {
                if (array.Length > 0)
                    queue.Insert(new Indices { Index = 0, Array = array });
            }

            int[] results = new int[data.Select(d => d.Length).Sum()];

            for(int i = 0; i < results.Length; i++)
            {
                Indices current = queue.Pop();
                results[i] = current.Array[current.Index];
                current.Index++;
                if (current.Index != current.Array.Length)
                    queue.Insert(current);
            }

            return results;
        }

        private class Indices : IComparable<Indices>
        {
            public int Index { get; set; }
            public int[] Array { get; set; }

            public int CompareTo(Indices other)
            {
                return this.Array[this.Index].CompareTo(other.Array[other.Index]);
            }
        }
    }
}
