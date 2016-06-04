using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    public static class RodCutting
    {
        public static int[] MaximumRevenues(int[] prices)
        {
            int[] revenues = new int[prices.Length];

            for(int i = 1; i < prices.Length; i++)
            {
                revenues[i] = prices[i];

                for(int j = 0; j < i; j++)
                    revenues[i] = Math.Max(revenues[i], prices[j] + revenues[i - j]);
            }

            return revenues;
        }
    }
}
