using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace AlgorithmTests.DataStructureTests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void HashTableTest()
        {
            for(int i = 0; i < 10; i++)
            {
                int[] data = ArrayUtilities.CreateRandomArray(20, 0, 15);

                HashTable<int, int> hashTable = new HashTable<int, int>();

                for(int j = 0; j < data.Length; j++)
                {
                    hashTable[j] = data[j];
                    Assert.IsTrue(hashTable.Contains(j));
                }

                for(int j = 0; j < data.Length; j++)
                {
                    bool contains = hashTable.Contains(j);
                    bool deleted = hashTable.Delete(j);
                    Assert.AreEqual(contains, deleted);
                    Assert.IsFalse(hashTable.Contains(j));
                }
            }
        }
    }
}
