using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    public static class MatrixMultiplication
    {
        public static int MinimumOperations(int[] sizes)
        {
            int count = sizes.Length - 1;
            int[,] counts = new int[sizes.Length, sizes.Length];

            for(int len = 2; len <= sizes.Length; len++)
            {
                for(int start = 0; start <= sizes.Length - len - 1; start++)
                {
                    int min = int.MaxValue;
                    int end = start + len - 1;

                    for (int mid = start; mid < end; mid++)
                        min = Math.Min(min, counts[start, mid] + counts[mid + 1, end] + sizes[start] * sizes[mid + 1] * sizes[end + 1]);

                    counts[start, end] = min;
                }
            }

            return counts[0, count - 1];
        }
    }
}
