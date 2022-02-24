using System;

namespace Algorithms.Searching
{
    /// <summary>
    /// Expand the range of values where the target item exist 
    /// perform a binary search on that bounded array
    /// </summary>
    public class ExponentialSearch
    {
        public static int Contains(int[] items, int item)
        {
            Array.Sort(items);

            int bound = 1;

            while (items[bound] < item && bound < items.Length) {
                bound *= 2;
            }

            int left = bound / 2;
            int right = Math.Min(bound, items.Length - 1);


            return BinarySearch.Contains(items, item, left, right);

        }
    }

}
