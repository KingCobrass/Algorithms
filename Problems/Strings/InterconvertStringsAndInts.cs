using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Strings
{
    [TestClass]
    public class InterconvertStringsAndInts
    {
        [TestMethod]
        public void TestInterconvertStringsAndInts()
        {
            Func<int, string>[] toStringFuncs = new Func<int, string>[]
            {
                InterconvertStringsAndInts.IntToString,
                i => i.ToString()
            };

            Func<string, int>[] toIntFuncs = new Func<string, int>[]
            {
                InterconvertStringsAndInts.StringToInt,
                s => int.Parse(s)
            };

            for(int i = -100; i <= 100; i++)
            {
                Tests.TestFunctions(i, toStringFuncs);
                Tests.TestFunctions(i.ToString(), toIntFuncs);
            }
        }

        private static string IntToString(int x)
        {
            bool isNegative = false;
            if(x < 0)
            {
                isNegative = true;
                x = -x;
            }

            StringBuilder sb = new StringBuilder();

            do
            {
                sb.Insert(0, x % 10);
                x /= 10;
            }
            while (x > 0);

            if (isNegative)
                sb.Insert(0, '-');

            return sb.ToString();
        }

        private static int StringToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int result = 0;
            bool isNegative = false;

            foreach(char c in s) 
            {
                if (c == '-')
                    isNegative = true;
                else
                    result = result * 10 + (c - '0');
            }

            return isNegative ? -result : result;
        }
    }
}
