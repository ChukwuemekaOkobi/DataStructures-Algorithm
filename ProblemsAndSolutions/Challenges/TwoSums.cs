using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Challenges
{
    /// <summary>
    /// Find the Index of two items in an array that sum up to a given value k
    /// Solution Uses a Hash Tam
    /// </summary>
    class TwoSums
    {
        /// <summary>
        /// Check for all possible pairs 
        /// O(n^2)
        /// </summary>

        public (int, int) BruteForce(int[] nums, int k)
        {
            for(int i = 0; i< nums.Length - 1; i++)
            {
                int shift = 1 + i;
                while (shift < nums.Length)
                {
                    if (nums[i] + nums[shift] == k)
                    {
                        return (i, shift);
                    }

                    shift++;
                }
            }

            return (-1, -1);
        }


        /// <summary>
        /// Using a Dictionary to Keep the Value of the difference between K and the 
        /// numbers in the array 
        /// O(n)
        /// </summary>
        public (int, int) HashTable(int[] nums, int k)
        {

            var dict = new Dictionary<int, int>();

            for (var num = 0; num < nums.Length; num++)
            {
                if (!dict.ContainsKey(k - nums[num]))
                {
                    dict.Add(k - nums[num], num);
                }
            }

            for (var i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    return (i, dict[nums[i]]);
                }
            }

            return (-1, -1);

        }

      
    }
}
