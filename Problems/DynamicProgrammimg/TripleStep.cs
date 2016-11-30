using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.DynamicProgrammimg
{
    // CTCI 8.1
    [TestClass]
    public class TripleStep
    {
        [TestMethod]
        public void TripleStepTest()
        {
            Func<int, int>[] functions = new Func<int, int>[]
            {
                TripleStep.BottomUp,
                TripleStep.TopDown
            };

            for (int i = 0; i < 30; i++)
                Tests.TestFunctions(i, functions);
        }

        private static int BottomUp(int n)
        {
            int[] counts = new int[n + 1];
            counts[0] = 1;

            for(int i = 0; i < counts.Length; i++)
            {
                if (i >= 1)
                    counts[i] += counts[i - 1];

                if (i >= 2)
                    counts[i] += counts[i - 2];

                if (i >= 3)
                    counts[i] += counts[i - 3];
            }

            return counts[n];
        }

        private static int TopDown(int n)
        {
            int[] counts = new int[n + 1];
            counts[0] = 1;

            return TripleStep.TopDown(n, counts);
        }

        private static int TopDown(int n, int[] counts)
        {
            if (n < 0)
                return 0;

            if(counts[n] == 0)
            {
                counts[n] = TripleStep.TopDown(n - 1, counts)
                    + TripleStep.TopDown(n - 2, counts)
                    + TripleStep.TopDown(n - 3, counts);
            }

            return counts[n];
        }
    }
}
