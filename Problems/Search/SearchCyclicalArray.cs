using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Search
{
    // EOPI 12.3
    [TestClass]
    public class SearchCyclicalArray
    {
        [TestMethod]
        public void SearchCyclicalArrayTest()
        {
            Func<int[], int>[] functions = new Func<int[], int>[]
            {
                SearchCyclicalArray.BruteForce,
                SearchCyclicalArray.BinarySearch
            };

            Random random = new Random();

            for(int i = 0; i < 10; i++)
            {
                int[] data = ArrayUtilities.CreateRandomArray(20, 0, 50).Distinct().ToArray();
                Array.Sort(data);
                int shift = random.Next(0, data.Length);
                int[] copy = new int[data.Length];

                Array.Copy(data, 0, copy, shift, data.Length - shift);
                Array.Copy(data, data.Length - 1 - shift, copy, 0, shift);
                Array.Copy(copy, data, data.Length);

                Tests.TestFunctions(data, functions);
            }
        }

        private static int BruteForce(int[] data)
        {
            for(int i = 1; i < data.Length; i++)
            {
                if (data[i] < data[i - 1])
                    return i;
            }

            return 0;
        }

        private static int BinarySearch(int[] data)
        {
            int low = 0;
            int high = data.Length - 1;

            while(low < high)
            {
                int mid = low + (high - low) / 2;

                if (data[high] > data[mid])
                    high = mid;
                else
                    low = mid + 1;
            }

            return low;
        }
    }
}
