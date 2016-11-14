using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.PrimitiveTypes
{
    // EOPI 25.1
    [TestClass]
    public class ComputeGCD
    {
        [TestMethod]
        public void ComputeGCDTest()
        {
            Func<int, int, int>[] functions = new Func<int, int, int>[]
            {
                ComputeGCD.Euclid,
                ComputeGCD.Restricted
            };

            ComputeGCD.Restricted(2, 1);

            for (int i = 1; i < 50; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Tests.TestFunctions(i, j, functions);
                }
            }
        }

        public static int Euclid(int a, int b)
        {
            if (b == 0)
                return a;

            return ComputeGCD.Euclid(b, a % b);
        }

        public static int Restricted(int a, int b)
        {
            if (a == b)
                return a;

            if((a & 1) == 0)
            {
                if ((b & 1) == 0)
                    return ComputeGCD.Restricted(a >> 1, b >> 1) << 1;

                return ComputeGCD.Restricted(a >> 1, b);
            }

            if((b & 1) == 0)
                return ComputeGCD.Restricted(a, b >> 1);

            if (a > b)
                return ComputeGCD.Restricted(a - b, b);

            return ComputeGCD.Restricted(b - a, a);
        }
    }
}
