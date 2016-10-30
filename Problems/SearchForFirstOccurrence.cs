using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems
{
    // EOPI 12.1
    [TestClass]
    public class SearchForFirstOccurrence
    {
        [TestMethod]
        public void SearchForFirstOccurrenceTest()
        {
            Func<int[], int, int>[] functions = new Func<int[], int, int>[]
            {
                SearchForFirstOccurrence.BruteForce,
                SearchForFirstOccurrence.BinarySearch
            };

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    int[] data = ArrayUtilities.CreateRandomArray(j, 0, 10);
                    Array.Sort(data);

                    for(int k = 0; k < 10; k++)
                    {
                        Tests.TestFunctions(data, k, functions);
                    }
                }
            }
        }

        private static int BruteForce(int[] data, int k)
        {
            int i = Array.BinarySearch(data, k);

            if (i < 0)
                return -1;

            while (i > 0 && data[i - 1] == k)
                i--;

            return i;
        }

        private static int BinarySearch(int[] data, int k)
        {
            int low = 0;
            int high = data.Length - 1;
            int result = -1;

            while(high >= low)
            {
                int mid = low + (high - low) / 2;

                if (data[mid] < k)
                    low = mid + 1;
                else
                {
                    high = mid - 1;
                    if (data[mid] == k)
                        result = mid;
                }
            }

            return result;
        }
    }
}
