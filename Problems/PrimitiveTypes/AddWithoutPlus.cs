using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.PrimitiveTypes
{
    [TestClass]
    public class AddWithoutPlus
    {
        [TestMethod]
        public void AddWithoutPlusTest()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Tests.TestFunctions(i, j, (a, b) => a + b, AddWithoutPlus.Bitwise, AddWithoutPlus.Recursive);
                }
            }
        }

        private static int Recursive(int a, int b)
        {
            if (b == 0)
                return a;

            return AddWithoutPlus.Recursive(a ^ b, (a & b) << 1);
        }

        private static int Bitwise(int a, int b)
        {
            int result = 0;
            bool carry = false;
            int digit = 0;

            while(a > 0 || b > 0 || carry)
            {
                bool b1 = (a & 1) > 0;
                bool b2 = (b & 1) > 0;

                if (b1 ^ b2 ^ carry)
                    result |= (1 << digit);

                carry = b1 ? (b2 || carry) : (b2 && carry);

                a >>= 1;
                b >>= 1;
                digit++;
            }

            return result;
        }
    }
}
