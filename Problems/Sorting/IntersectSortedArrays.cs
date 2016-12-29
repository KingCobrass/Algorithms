using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Search;
using Utilities;

namespace Problems.Sorting
{
    // EOPI 14.1
    [TestClass]
    public class IntersectSortedArrays
    {
        [TestMethod]
        public void IntersectSortedArraysTest()
        {
            Func<int[], int[], int[]>[] functions = new Func<int[], int[], int[]>[]
            {
                IntersectSortedArrays.BruteForce,
                IntersectSortedArrays.Search,
                IntersectSortedArrays.Iterate
            };

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    int[] a = ArrayUtilities.CreateRandomArray(i, 0, 8);
                    int[] b = ArrayUtilities.CreateRandomArray(j, 0, 8);

                    Array.Sort(a);
                    Array.Sort(b);

                    Tests.TestFunctions(a, b, functions);
                }
            }
        }

        private static int[] BruteForce(int[] a, int[] b)
        {
            List<int> list = new List<int>();

            for(int i = 0; i < a.Length; i++)
            {
                if (i > 0 && a[i] == a[i - 1])
                    continue;

                for(int j = 0; j < b.Length; j++)
                {
                    if(a[i] == b[j])
                    {
                        list.Add(a[i]);
                        break;
                    }
                }
            }

            return list.ToArray();
        }

        private static int[] Search(int[] a, int[] b)
        {
            List<int> list = new List<int>();

            for(int i = 0; i < a.Length; i++)
            {
                if (i > 0 && a[i] == a[i - 1])
                    continue;

                int j = BinarySearch.Find(b, a[i]);

                if (j >= 0)
                    list.Add(a[i]);
            }

            return list.ToArray();
        }

        private static int[] Iterate(int[] a, int[] b)
        {
            int i = 0;
            int j = 0;

            List<int> list = new List<int>();

            while(i < a.Length && j < b.Length)
            {
                if (a[i] == b[j] && (i == 0 || a[i] != a[i - 1]))
                {
                    list.Add(a[i]);
                    i++;
                    j++;
                }
                else if (a[i] > b[j])
                    j++;
                else
                    i++;
            }

            return list.ToArray();
        }
    }
}
