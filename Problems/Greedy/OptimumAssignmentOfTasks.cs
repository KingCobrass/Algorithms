using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Greedy
{
    // EOPI 18.1
    [TestClass]
    public class OptimumAssignmentOfTasks
    {
        [TestMethod]
        public void OptimumAssignmentOfTasksTest()
        {
            Func<int[], int>[] functions = new Func<int[], int>[]
            {
                OptimumAssignmentOfTasks.BruteForce,
                OptimumAssignmentOfTasks.Greedy
            };

            for (int i = 0; i < 10; i++)
            {
                int[] tasks = ArrayUtilities.CreateRandomArray(6, 0, 10);
                Tests.TestFunctions(tasks, functions);
            }
        }

        private static int BruteForce(int[] tasks)
        {
            int min = int.MaxValue;

            foreach (int[] permutation in OptimumAssignmentOfTasks.Permutations(tasks, 0))
            {
                int max = int.MinValue;
                for (int i = 0; i < permutation.Length / 2; i++)
                    max = Math.Max(max, permutation[i] + permutation[permutation.Length - i - 1]);

                min = Math.Min(min, max);
            }

            return min;
        }

        private static IEnumerable<int[]> Permutations(int[] data, int index)
        {
            if (index == data.Length)
                yield return data;

            for(int i = index; i < data.Length; i++)
            {
                ArrayUtilities.Swap(data, i, index);

                foreach (int[] permutation in OptimumAssignmentOfTasks.Permutations(data, index + 1))
                    yield return permutation;

                ArrayUtilities.Swap(data, i, index);
            }
        }

        private static int Greedy(int[] tasks)
        {
            int[] sorted = new int[tasks.Length];
            Array.Copy(tasks, sorted, tasks.Length);
            Array.Sort(sorted);

            int max = int.MinValue;

            for (int i = 0; i < sorted.Length / 2; i++)
                max = Math.Max(max, sorted[i] + sorted[sorted.Length - i - 1]);

            return max;
        }
    }
}
