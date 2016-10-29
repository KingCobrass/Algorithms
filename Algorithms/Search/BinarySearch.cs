using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Search
{
    public static class BinarySearch
    {
        public static int Find<T>(T[] data, T item)
            where T : IComparable<T>
        {
            int low = 0;
            int high = data.Length - 1;

            while(low <= high)
            {
                int mid = low + (high - low) / 2;
                int compare = item.CompareTo(data[mid]);

                if (compare == 0)
                    return mid;
                else if (compare > 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }
    }
}
