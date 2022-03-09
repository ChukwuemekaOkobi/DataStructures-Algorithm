using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// QUESTION: 
    /// </summary>
    public class RemoveTargetKey
    {
        /// <summary>
        ///  iterate through the array using right pointer to find 
        ///  the value != key and move that to the next space marked by 
        ///  the left pointer
        /// </summary>

        public static int Remove(int[] arr, int key)
        {
          
            int right = 0;
            int left = 0; 

            while (right < arr.Length)
            {
                if (arr[right] != key)
                {
                    arr[left++] = arr[right];
                }
                right++;
            }

            return left; 
        }
    }
}
