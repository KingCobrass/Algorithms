using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Miscellaneous
{
    public class MaximumSubarray
    {
        public static int Run(int[] data)
        {
            int currentSum = 0;
            int maxSum = 0;

            foreach(int i in data)
            {
                currentSum += i;
                currentSum = Math.Max(currentSum, 0);
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }
    }
}
