using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Arrays
{
    [TestClass]
    public class MultiplyInteger
    {
        [TestMethod]
        public void MultiplyIntegerTest()
        {
            Func<int[], int[], int[]>[] functions = new Func<int[], int[], int[]>[]
            {
                MultiplyInteger.Convert,
                MultiplyInteger.ToArray
            };

            for(int x = -20; x <= 20; x++)
            {
                for(int y = -20; y <= 20; y++)
                {
                    int[][] results = new int[functions.Length][];

                    for(int k = 0; k < functions.Length; k++)
                    {
                        results[k] = functions[k](MultiplyInteger.ToArray(x), MultiplyInteger.ToArray(y));
                        Assert.IsTrue(ArrayUtilities.AreEqual(results[0], results[k]));
                    }
                }
            }
        }

        private static int[] Convert(int[] x, int[] y)
        {
            return MultiplyInteger.ToArray(MultiplyInteger.ToInt(x) * MultiplyInteger.ToInt(y));
        }

        private static int ToInt(int[] x)
        {
            if (x.Length == 0)
                return 0;

            bool negative = (x[0] < 0);
            x[0] = Math.Abs(x[0]);
            int result = 0;

            for(int i = 0; i < x.Length; i++)
            {
                result *= 10;
                result += x[i];
            }

            if (negative)
                result *= -1;

            return result;
        }

        private static int[] ToArray(int x)
        {
            bool negative = x < 0;
            x = Math.Abs(x);

            List<int> list = new List<int>();

            while(x > 0)
            {
                list.Insert(0, x % 10);
                x /= 10;
            }

            if (negative)
                list[0] *= -1;

            return list.ToArray();
        }

        private static int[] ToArray(int[] x, int[] y)
        {
            if(x.Length == 0 || y.Length == 0)
                return new int[] { };

            bool negative = (x[0] > 0) ^ (y[0] > 0);
            x[0] = Math.Abs(x[0]);
            y[0] = Math.Abs(y[0]);

            List<int> result = new List<int>(new int[x.Length + y.Length]);

            for(int i = x.Length - 1; i >= 0; i--)
            {
                for(int j = y.Length - 1; j >= 0; j--)
                {
                    result[i + j + 1] += x[i] * y[j];
                    result[i + j] += result[i + j + 1] / 10;
                    result[i + j + 1] %= 10;
                }
            }

            while (result.Count > 0 && result[0] == 0)
                result.RemoveAt(0);

            if (negative && result.Count > 0)
                result[0] *= -1;

            return result.ToArray();
        }
    }
}
