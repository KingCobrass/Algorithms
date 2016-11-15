using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Arrays
{
    [TestClass]
    public class FirstMissingElement
    {
        // EOPI 25.2
        [TestMethod]
        public void FirstMissingElementTest()
        {
            Func<int[], int>[] functions = new Func<int[], int>[]
            {
                FirstMissingElement.BruteForce,
                FirstMissingElement.Iterative
            };

            for(int i = 0; i < 10; i++)
            {
                int[][] data = new int[functions.Length][];
                int[] original = ArrayUtilities.CreateRandomArray(20, -10, 10);

                for (int j = 0; j < functions.Length; j++)
                {
                    data[j] = new int[original.Length];
                    Array.Copy(original, data[j], original.Length);
                }

                int[] results = new int[functions.Length];

                for(int j = 0; j < functions.Length; j++)
                {
                    results[j] = functions[j](data[j]);
                    Assert.AreEqual(results[j], results[0]);
                }
            }
        }

        private static int BruteForce(int[] data)
        {
            Array.Sort(data);

            if (data[0] > 1)
                return data[0] - 1;

            int i = 0;

            while (i < data.Length && data[i] < 1)
                i++;

            if(i == data.Length || data[i] > 1)
                return 1;

            i++;

            while (i < data.Length && data[i] - data[i - 1] < 2)
                i++;

            if(i == data.Length)
                return data[data.Length - 1] + 1;

            return data[i - 1] + 1;
        }

        private static int Iterative(int[] data)
        {
            for(int i = 0; i < data.Length; i++)
            {
                while (data[i] > 0 && data[i] <= data.Length && data[i] != data[data[i] - 1])
                    ArrayUtilities.Swap(data, i, data[i] - 1);
            }

            for(int i = 1; i <= data.Length; i++)
            {
                if (data[i - 1] != i)
                    return i;
            }

            return data.Length + 1;
        }
    }
}
