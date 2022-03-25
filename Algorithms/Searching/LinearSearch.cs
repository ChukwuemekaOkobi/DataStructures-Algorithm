using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Searching
{
    /// <summary>
    /// Iterate through all the value in the array 
    /// and return the index or -1 if not found
    /// O(n)
    /// </summary>
    public class LinearSearch
    {
        public static int Contains(int[] items, int item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (item == items[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }

}
