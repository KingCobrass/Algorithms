using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Sorting
{
    [TestClass]
    public class SortedMerge
    {
        // CTCI 10.1
        [TestMethod]
        public void SortedMergeTest()
        {
            Action<int[], int[]>[] actions = new Action<int[], int[]>[]
            {
                SortedMerge.BruteForce,
                SortedMerge.SinglePass
            };

            for(int i = 0; i < 10; i++)
            {
                int[] A = ArrayUtilities.CreateRandomArray(40, 0, 20);
                int[] B = ArrayUtilities.CreateRandomArray(20, 0, 20);

                Array.Sort(A, 0, A.Length / 2);
                Array.Sort(B);

                int[][] results = new int[actions.Length][];

                for(int j = 0; j < actions.Length; j++)
                {
                    results[j] = new int[A.Length];
                    Array.Copy(A, results[j], A.Length);
                    int[] copyB = new int[B.Length];
                    Array.Copy(B, copyB, B.Length);

                    actions[j](results[j], copyB);
                    Assert.IsTrue(ArrayUtilities.AreEqual(results[0], results[j]));
                }
            }
        }

        private static void BruteForce(int[] A, int[] B)
        {
            Array.Copy(B, 0, A, B.Length, B.Length);
            Array.Sort(A);
        }

        private static void SinglePass(int[] A, int[] B)
        {
            int i = B.Length - 1;
            int j = B.Length - 1;
            int k = A.Length - 1;

            while(i >= 0 || j >= 0)
            {
                if(j < 0 || (i >= 0 && A[i] >= B[j]))
                {
                    A[k] = A[i];
                    i--;
                }
                else
                {
                    A[k] = B[j];
                    j--;
                }
                k--;
            }
        }
    }
}
