using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._12_BitwiseXOR
{
    /// <summary>
    /// In a non-empty array of integers, every number appears twice except for one, find that single number.
    /// Example 1:

    //Input: 1, 4, 2, 1, 3, 2, 3
    //Output: 4
    //Example 2:

    //Input: 7, 9, 7
    //Output: 9
    /// </summary>
    public class SingleNumber
    {
        /// <summary>
        /// using XOR , a number XOR with itself is 0 
        /// a number XOR with 0 is that number
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindBitWise(int[] nums)
        {

            int num = 0; 

            for(int i = 0; i<nums.Length; i++)
            {
                num ^= nums[i];
            }

            return num;
        }


        public static int FindHashMap(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>(); 

            for(int i = 0; i<nums.Length; i++)
            {
                if (!dict.TryAdd(nums[i], 1))
                {
                    dict.Remove(nums[i]);
                }
            }
            
                      
            return dict.Keys.First();
        }
    }

    
    //solutions 
    /* sort and use binary search, NlogN + logN 
     * sort and use pointer NlogN + O(N)
     */
}
