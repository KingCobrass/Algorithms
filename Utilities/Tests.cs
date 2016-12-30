using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utilities
{
    public static class Tests
    {
        public static void TestFunctions<T, U>(T p1, params Func<T, U>[] functions)
        {
            Tests.TestFunctionsCore(p1, functions, (x, y) => x.Equals(y));
        }

        public static void TestFunctions<T, U>(T p1, params Func<T, U[]>[] functions)
        {
            Tests.TestFunctionsCore(p1, functions, (x, y) => ArrayUtilities.AreEqual(x, y));
        }

        private static void TestFunctionsCore<T, U>(T p1, Func<T, U>[] functions, Func<U, U, bool> comparison)
        {
            U[] results = new U[functions.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = functions[i](p1);
                Assert.IsTrue(comparison(results[0], results[i]));
            }
        }

        public static void TestFunctions<T, U, V>(T p1, U p2, params Func<T, U, V>[] functions)
        {
            Tests.TestFunctionsCore(p1, p2, functions, (x, y) => x.Equals(y));
        }

        public static void TestFunctions<T, U, V>(T p1, U p2, params Func<T, U, V[]>[] functions)
        {
            Tests.TestFunctionsCore(p1, p2, functions, (x, y) => ArrayUtilities.AreEqual(x, y));
        }

        private static void TestFunctionsCore<T, U, V>(T p1, U p2, Func<T, U, V>[] functions, Func<V, V, bool> comparison)
        {
            V[] results = new V[functions.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = functions[i](p1, p2);
                Assert.IsTrue(comparison(results[0], results[i]));
            }
        }

        public static void TestFunctions<T, U, V, W>(T p1, U p2, V p3, params Func<T, U, V, W>[] functions)
        {
            Tests.TestFunctionsCore(p1, p2, p3, functions, (x, y) => x.Equals(y));
        }

        public static void TestFunctions<T, U, V, W>(T p1, U p2, V p3, params Func<T, U, V, W[]>[] functions)
        {
            Tests.TestFunctionsCore(p1, p2, p3, functions, (x, y) => ArrayUtilities.AreEqual(x, y));
        }

        private static void TestFunctionsCore<T, U, V, W>(T p1, U p2, V p3, Func<T, U, V, W>[] functions, Func<W, W, bool> comparison)
        {
            W[] results = new W[functions.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = functions[i](p1, p2, p3);
                Assert.IsTrue(comparison(results[0], results[i]));
            }
        }

        public static void TestFunctions<T, U, V, W, X>(T p1, U p2, V p3, W p4, params Func<T, U, V, W, X>[] functions)
        {
            Tests.TestFunctionsCore(p1, p2, p3, p4, functions, (x, y) => x.Equals(y));
        }

        public static void TestFunctions<T, U, V, W, X>(T p1, U p2, V p3, W p4, params Func<T, U, V, W, X[]>[] functions)
        {
            Tests.TestFunctionsCore(p1, p2, p3, p4, functions, (x, y) => ArrayUtilities.AreEqual(x, y));
        }

        private static void TestFunctionsCore<T, U, V, W, X>(T p1, U p2, V p3, W p4, Func<T, U, V, W, X>[] functions, Func<X, X, bool> comparison)
        {
            X[] results = new X[functions.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = functions[i](p1, p2, p3, p4);
                Assert.IsTrue(comparison(results[0], results[i]));
            }
        }
    }
}
