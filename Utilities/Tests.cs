using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utilities
{
    public static class Tests
    {
        public static void TestFunctions<T, U>(T p1, params Func<T, U>[] functions)
        {
            U[] results = new U[functions.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = functions[i](p1);
                Assert.AreEqual(results[0], results[i]);
            }
        }

        public static void TestFunctions<T, U, V, W>(T p1, U p2, V p3, params Func<T, U, V, W>[] functions)
        {
            W[] results = new W[functions.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = functions[i](p1, p2, p3);
                Assert.AreEqual(results[0], results[i]);
            }
        }
    }
}
