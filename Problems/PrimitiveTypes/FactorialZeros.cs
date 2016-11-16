using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.PrimitiveTypes
{
    [TestClass]
    public class FactorialZeros
    {
        [TestMethod]
        public void FactorialZerosTest()
        {
            Func<int, int>[] functions = new Func<int, int>[]
            {
                FactorialZeros.BruteForce,
                FactorialZeros.PowersOfFive
            };

            for(int i = 0; i <= 15; i++)
                Tests.TestFunctions(i, functions);
        }

        private static int BruteForce(int n)
        {
            long factorial = 1;

            while(n > 1)
            {
                factorial *= n;
                n--;
            }

            int count = 0;

            while(factorial % 10 == 0)
            {
                factorial /= 10;
                count++;
            }

            return count;
        }

        private static int PowersOfFive(int n)
        {
            if (n == 0)
                return 0;

            int count = 0;
            while(n >= 5)
            {
                count += n / 5;
                n /= 5;
            }

            return count;
        }
    }
}
