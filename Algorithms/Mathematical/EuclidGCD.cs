using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Mathematical
{
    public static class EuclidGCD
    {
        public static int Run(int a, int b)
        {
            if (b == 0)
                return a;

            return EuclidGCD.Run(b, a % b);
        }
    }
}
