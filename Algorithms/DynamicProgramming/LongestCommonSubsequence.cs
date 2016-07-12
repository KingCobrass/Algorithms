using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    public static class LongestCommonSubsequence
    {
        public static string GetLongestCommonSubsequence(string a, string b)
        {
            int[,] lengths = new int[a.Length + 1, b.Length + 1];

            for(int i = 1; i <= a.Length; i++)
            {
                for(int j = 1; j <= b.Length; j++)
                {
                    if (a[i - 1] == b[j - 1])
                        lengths[i, j] = lengths[i - 1, j - 1] + 1;
                    else
                        lengths[i, j] = Math.Max(lengths[i, j - 1], lengths[i - 1, j]);
                }
            }

            StringBuilder sb = new StringBuilder();

            int k = a.Length;
            int l = b.Length;

            while (k > 0 && l > 0)
            {
                if (a[k - 1] == b[l - 1])
                {
                    sb.Insert(0, a[k - 1]);
                    k--;
                    l--;
                }
                else if (lengths[k, l - 1] < lengths[k - 1, l])
                    k--;
                else
                    l--;
            }

            return sb.ToString();
        }
    }
}
