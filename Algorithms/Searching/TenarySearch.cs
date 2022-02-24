using System;

namespace Algorithms.Searching
{
    /// <summary>
    /// Dividing the list into 3 parts
    /// </summary>

    public class TenarySearch
    {
        public static int Contains(int[] items, int item)
        {
            Array.Sort(items);
            return Ternary(items, item, 0, items.Length -1); 
        }


        private static int Ternary(int[] items, int item, int left, int right)
        {
            if(left > right)
            {
                return -1; 
            }
            int partitionSize = (right - left) / 3;
            int mid1 = left + partitionSize;
            int mid2 = right- partitionSize; 

            if(items[mid1] == item)
            {
                return mid1; 
            }
            if(items[mid2] == item)
            {
                return mid2; 
            }

            if(item < items[mid1])
            {
                return Ternary(items, item, left, mid1 - 1);
            }
            if(item > items[mid2])
            {
                return Ternary(items, item, mid2 + 1, right); 
            }

            return Ternary(items, item, mid1+1, mid2-1); 
        }
    }
}
