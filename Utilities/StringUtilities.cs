using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class StringUtilities
    {
        public static string CreateRandomString(int length)
        {
            Random random = new Random();
            char[] data = new char[length];
            for (int k = 0; k < data.Length; k++)
                data[k] = (char)((int)'a' + random.Next(0, 27));

            return new string(data);
        }
    }
}
