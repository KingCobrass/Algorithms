using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problems.Arrays
{
    [TestClass]
    public class IncrementInteger
    {
        [TestMethod]
        public void TestIncrementInteger()
        {
            Action<List<int>>[] actions = new Action<List<int>>[]
            {
                IncrementInteger.Convert,
                IncrementInteger.SinglePass
            };

            int digits = 0;
            for (int i = 0; i <= 1000; i++)
            {
                if (i % 10 == 0)
                    digits++;

                for(int j = 0; j < actions.Length; j++)
                {
                    List<int> list = new List<int>();
                    for (int k = 0; k < digits; k++)
                        list.Insert(0, 0);

                    IncrementInteger.ToList(i, list);
                    actions[j](list);
                    Assert.AreEqual(IncrementInteger.ToInt(list), i + 1);
                }
            }
        }

        private static void Convert(List<int> number)
        {
            int result = IncrementInteger.ToInt(number);
            result++;
            IncrementInteger.ToList(result, number);
        }

        private static void SinglePass(List<int> number)
        {
            int i = number.Count - 1;
            number[i]++;

            while(i > 0 && number[i] == 10)
            {
                number[i] = 0;
                i--;
                number[i]++;
            }

            if(number[0] == 10)
            {
                number[0] = 0;
                number.Insert(0, 1);
            }
        }

        private static int ToInt(List<int> number)
        {
            int result = 0;
            for (int i = 0; i < number.Count; i++)
            {
                result *= 10;
                result += number[i];
            }

            return result;
        }

        private static void ToList(int x, List<int> number)
        {
            for (int i = number.Count - 1; i >= 0; i--)
            {
                number[i] = x % 10;
                x /= 10;
            }

            if (x > 0)
                number.Insert(0, x);
        }
    }
}
