using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.Arrays
{
    // CTCI 17.5
    [TestClass]
    public class LettersAndNumbers
    {
        [TestMethod]
        public void LettersAndNumbersTest()
        {
            Func<char[], int>[] functions = new Func<char[], int>[]
            {
                LettersAndNumbers.BruteForce,
                LettersAndNumbers.HashTable
            };

            for(int i = 0; i < 10; i++)
            {
                char[] data = StringUtilities.CreateRandomAlphanumericString(20).ToCharArray();
                Tests.TestFunctions(data, functions);
            }
        }

        private static int BruteForce(char[] data)
        {
            for(int i = data.Length; i > 1; i--)
            {
                for(int j = 0; j <= data.Length - i; j++)
                {
                    int diff = 0;

                    for(int k = j; k < j + i; k++)
                    {
                        if (LettersAndNumbers.IsNumber(data[k]))
                            diff++;
                        else
                            diff--;
                    }

                    if (diff == 0)
                        return i;
                }
            }

            return 0;
        }

        private static int HashTable(char[] data)
        {
            int[] diffs = new int[data.Length];
            int diff = 0;

            for(int i = 0; i < data.Length; i++)
            {
                if (LettersAndNumbers.IsNumber(data[i]))
                    diff++;
                else
                    diff--;

                diffs[i] = diff;
            }

            HashTable<int, int> hashTable = new HashTable<int, int>();
            hashTable[0] = -1;
            int max = 0;

            for(int i = 0; i < diffs.Length; i++)
            {
                if (hashTable.Contains(diffs[i]))
                    max = Math.Max(max, i - hashTable[diffs[i]]);
                else
                    hashTable[diffs[i]] = i;
            }

            return max;
        }

        private static bool IsNumber(char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}
