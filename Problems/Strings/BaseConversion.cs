using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Strings
{
    // EOPI 7.2
    [TestClass]
    public class BaseConversion
    {
        private static string digits = "0123456789ABCDEF";
        [TestMethod]
        public void BaseConversionTest()
        {
            Func<string, int, int, string>[] functions = new Func<string, int, int, string>[]
            {
                BaseConversion.Convert
            };

            for(int n = 0; n < 50; n++)
            {
                for (int b1 = 2; b1 < 16; b1++)
                {
                    for (int b2 = 2; b2 < 16; b2++)
                    {
                        string s = BaseConversion.ToString(n, b1);
                        Assert.AreEqual(BaseConversion.ToInt(s, b1), n);

                        string s2 = BaseConversion.Convert(s, b1, b2);
                        Assert.AreEqual(BaseConversion.Convert(s2, b2, b1), s);

                        int n2 = BaseConversion.ToInt(s2, b2);
                        Assert.AreEqual(BaseConversion.ToString(n2, b2), s2);
                    }
                }
            }
        }

        private static string Convert(string s, int b1, int b2)
        {
            return BaseConversion.ToString(BaseConversion.ToInt(s, b1), b2);
        }

        private static int ToInt(string s, int b)
        {
            int n = 0;

            for (int i = 0; i < s.Length; i++)
            {
                n *= b;
                n += BaseConversion.digits.IndexOf(s[i]);
            }

            return n;
        }

        private static string ToString(int n, int b)
        {
            StringBuilder sb = new StringBuilder();

            while (n > 0)
            {
                sb.Insert(0, BaseConversion.digits[n % b]);
                n /= b;
            }

            return sb.ToString();
        }
    }
}
