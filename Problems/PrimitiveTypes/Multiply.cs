using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.PrimitiveTypes
{
    [TestClass]
    public class Multiply
    {
        [TestMethod]
        public void MultiplyTest()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Tests.TestFunctions(i, j, (a, b) => a * b, Multiply.Bitwise);
                }
            }
        }

        private static int Bitwise(int a, int b)
        {
            int result = 0;

            while(b > 0)
            {
                if ((b & 1) == 1)
                    result = Multiply.Add(result, a);
                b >>= 1;
                a <<= 1;
            }

            return result;
        }

        private static int Add(int a, int b)
        {
            if (b == 0)
                return a;

            return Multiply.Add(a ^ b, (a & b) << 1);
        }
    }
}
