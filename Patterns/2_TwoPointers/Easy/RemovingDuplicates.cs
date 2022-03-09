using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// QUESTION: Remove Duplicates (easy) 
    /// Given an array of sorted numbers, remove all duplicates from it. 
    /// You should not use any extra space; after removing the duplicates 
    /// in-place return the length of the subarray that has no duplicate in it.

    /* Example 1:

        Input: [2, 3, 3, 3, 6, 9, 9]
        Output: 4
        Explanation: The first four elements after removing the duplicates will be [2, 3, 6, 9].
        Example 2:

        Input: [2, 2, 2, 11]
        Output: 2
        Explanation: The first two elements after removing the duplicates will be [2, 11].
     * 
     */
    /// </summary>
    public class RemovingDuplicates
    {
        /// <summary>
        /// Shifting the values
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int Remove(int[] arr)
        {
            int nextNonDuplicate = 1; // index of the next non-duplicate element
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[nextNonDuplicate - 1] != arr[i])
                {
                    arr[nextNonDuplicate++] = arr[i];

                }
            }

            return nextNonDuplicate;
        }
        /// <summary>
        ///  insert the next non-duplicate number(right pointer) next to the 
        ///  current non-duplicate number(left pointer)
        /// </summary>

        public static int Remove2(int[] arr)
        {
            int left = 0;
            int right = 0;

            int count = 1;
            while (right < arr.Length)
            {
                if (arr[left] != arr[right])
                {
                    arr[++left] = arr[right];
                    count++;
                }
                right++;
            }
            
            return count; 
        }

       
     
    }
}
