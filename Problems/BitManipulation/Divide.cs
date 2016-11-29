using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.BitManipulation
{
    // EOPI 5.6
    [TestClass]
    public class Divide
    {
        [TestMethod]
        public void DivideTest()
        {
            Func<int, int, int>[] functions = new Func<int, int, int>[]
            {
                (x, y) => x / y,
                Divide.BruteForce,
                Divide.Shift
            };

            for(int x = 0; x < 100; x++)
            {
                for(int y = 1; y <= x; y++ )
                {
                    Tests.TestFunctions(x, y, functions);
                }
            }
        }

        private static int BruteForce(int x, int y)
        {
            int q = 0;
            while(x >= y)
            {
                x -= y;
                q++;
            }

            return q;
        }

        private static int Shift(int x, int y)
        {
            int p = 32;
            long yp = (long)y << p;
            int q = 0;

            while(x >= y)
            {
                while(yp > x)
                {
                    yp >>= 1;
                    p--;
                }

                q |= 1 << p;
                x -= y << p;
            }

            return q;
        }
    }
}
