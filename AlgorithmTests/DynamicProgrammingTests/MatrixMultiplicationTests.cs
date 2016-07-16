using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DynamicProgramming;

namespace AlgorithmTests.DynamicProgrammingTests
{
    [TestClass]
    public class MatrixMultiplicationTests
    {
        [TestMethod]
        public void MatrixMultiplicationTest()
        {
            MatrixMultiplicationTests.MatrixMultiplicationTest(new int[] { 1, 2 }, 0);
            MatrixMultiplicationTests.MatrixMultiplicationTest(new int[] { 1, 2, 3 }, 6);
            MatrixMultiplicationTests.MatrixMultiplicationTest(new int[] { 30, 35, 15, 5, 10, 20, 25 }, 15125);
        }

        private static void MatrixMultiplicationTest(int[] sizes, int expected)
        {
            int actual = MatrixMultiplication.MinimumOperations(sizes);
            Assert.AreEqual(expected, actual);
        }
    }
}
