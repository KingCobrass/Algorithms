using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DynamicProgramming;

namespace AlgorithmTests.DynamicProgrammingTests
{
    [TestClass]
    public class LongestCommonSubsequenceTests
    {
        [TestMethod]
        public void LongestCommonSubsequenceTest()
        {
            LongestCommonSubsequenceTests.LongestCommonSubsequenceTest("aaa", "aa", "aa");
            LongestCommonSubsequenceTests.LongestCommonSubsequenceTest("abc", "a", "a");
            LongestCommonSubsequenceTests.LongestCommonSubsequenceTest("aetr", "vbn", "");
            LongestCommonSubsequenceTests.LongestCommonSubsequenceTest("abcdefgh", "aceg", "aceg");
            LongestCommonSubsequenceTests.LongestCommonSubsequenceTest("abcbdab", "bdcaba", "bdab");
        }

        private static void LongestCommonSubsequenceTest(string a, string b, string expected)
        {
            string actual = LongestCommonSubsequence.GetLongestCommonSubsequence(a, b);
            Assert.AreEqual(expected, actual);
        }
    }
}
