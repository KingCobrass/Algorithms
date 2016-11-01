using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.HashTables
{
    // EOPI 13.1
    [TestClass]
    public class PalindromicPermutations
    {
        [TestMethod]
        public void PalindromicPermutationsTest()
        {
            Func<string, bool>[] functions = new Func<string, bool>[]
            {
                PalindromicPermutations.BruteForce,
                PalindromicPermutations.HashTable
            };

            for(int i = 0; i < 100; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    string s = StringUtilities.CreateRandomString(j);

                    Tests.TestFunctions(s, functions);
                }
            }
        }

        private static bool BruteForce(string s)
        {
            foreach(char[] data in PalindromicPermutations.Permutations(s.ToCharArray(), 0))
            {
                if (PalindromicPermutations.IsPalindrome(data))
                    return true;
            }

            return false;
        }

        private static IEnumerable<char[]> Permutations(char[] data, int index)
        {
            if (index >= data.Length - 1)
            {
                yield return data;
                yield break;
            }

            for (int i = index; i < data.Length; i++)
            {
                ArrayUtilities.Swap(data, i, index);

                foreach (char[] permutation in PalindromicPermutations.Permutations(data, index + 1))
                    yield return permutation;

                ArrayUtilities.Swap(data, i, index);
            }
        }

        private static bool IsPalindrome(char[] data)
        {
            for(int i = 0; i < data.Length / 2; i++)
            {
                if (data[i] != data[data.Length - i - 1])
                    return false;
            }

            return true;
        }

        private static bool HashTable(string s)
        {
            HashTable<char, int> hashTable = new HashTable <char, int>();

            foreach(char c in s)
                hashTable[c] = hashTable[c] + 1;

            return hashTable.Values.Where(i => i % 2 > 0).Count() <= 1;
        }
    }
}
