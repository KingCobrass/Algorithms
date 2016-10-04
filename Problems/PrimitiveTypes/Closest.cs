using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.PrimitiveTypes
{
    [TestClass]
    public class Closest
    {
        [TestMethod]
        public void ClosestTest()
        {
            for (int i = 1; i < 100; i++)
                Tests.TestFunctions(i, Closest.BruteForce, Closest.CheckBits);
        }

        private static int BruteForce(int x)
        {
            int count = Closest.DigitCount(x);

            for(int i = 1;  i < x || int.MaxValue - i > x; i++)
            {
                if (i < x && Closest.DigitCount(x - i) == count)
                    return x - i;

                if (int.MaxValue - i > x && Closest.DigitCount(x + i) == count)
                    return x + i;
            }

            return -1;
        }

        private static int DigitCount(int x)
        {
            int count = 0;
            while(x > 0)
            {
                x &= (x - 1);
                count++;
            }

            return count;
        }

        private static int CheckBits(int x)
        {
            for(int i = 0; i < 31; i++)
            {
                int bits = (x >> i) & 3;
                if (bits == 1 || bits == 2)
                    return x ^ (3 << i);
            }

            return -1;
        }
    }
}
