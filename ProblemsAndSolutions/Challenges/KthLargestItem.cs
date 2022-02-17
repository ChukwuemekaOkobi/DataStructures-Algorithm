using DataStructures.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Challenges
{
    /// <summary>
    /// Find the Kth LargestItem in an array
    /// </summary>
    public class KthLargestItem
    {

        /// <summary>
        /// Using a Heap 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int FindKthItem (int[] array, int k)
        {
            var heap = new Heap();

            foreach(var item in array)
            {
                heap.Insert(item); 
            }

            int i = 1;
            var value = 0; 
            while (i < k)
            {
                value = heap.Remove();
                i++;
            }

            return value; 
        }
    }
}
