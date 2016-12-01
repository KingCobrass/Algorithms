using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Search
{
    // EOPI 12.2
    [TestClass]
    public class EntryEqualToIndex
    {
        [TestMethod]
        public void EntryEqualToIndexTest()
        {
            Func<int[], int>[] functions = new Func<int[], int>[]
            {
                EntryEqualToIndex.BruteForce,
                EntryEqualToIndex.Search
            };

            for(int i = 0; i < 1000; i++)
            {
                int[] data = ArrayUtilities.CreateRandomArray(20, -10, 10).Distinct().ToArray();
                Array.Sort(data);
                Tests.TestFunctions(data, functions);
            }
        }

        private static int BruteForce(int[] data)
        {
            for(int i = 0; i < data.Length; i++)
            {
                if (i == data[i])
                    return i;
            }

            return -1;
        }

        private static int Search(int[] data)
        {
            int low = 0;
            int high = data.Length - 1;

            while(low <= high)
            {
                int mid = low + (high - low) / 2;

                if (data[mid] == mid)
                    return mid;
                else if (data[mid] > mid)
                    high = mid - 1;
                else
                    low = mid + 1;
            }

            return -1;
        }
    }
}
