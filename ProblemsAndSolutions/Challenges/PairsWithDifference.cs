using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Challenges
{
    /// <summary>
    ///  Problem: 
    ///  Given an array of integers, count the number of UNIQUE pairs of 
    ///  integers that have difference k.
    ///  Input: [1, 7, 5, 9, 2, 12, 3] K=2 
    ///  Output: 4
    /// </summary>
    public class PairsWithDifference
    {
 

        /// <summary>
        /// implementing the using Sliding window O(nLogn)
        /// Requires the array to be sorted in increasing order
        /// 
        /// Assume numbers occur only once.  
        /// </summary>
        public int UsingSlidingWindow(int[] numbers, int diff)
        {
            int count = 0;

            Array.Sort(numbers); 

            int left = 0;
            int right = 0;
            while (right < numbers.Length)
            {
                if (numbers[right] - numbers[left] == diff)
                {
                    count++;
                    left++;
                    right++;
                }
                else if (numbers[right] - numbers[left] > diff)
                    left++;

                else
                    right++;
            }
            return count;

        }

        /// <summary>
        /// Uses HashTable to keep track of unique pair 
        /// O(n) works with duplicates
        /// </summary>
 
        public int UniquePairUsingHashTable(int[] values, int diff)
        {
            var dict = new Dictionary<int, int>();

            foreach (var num in values)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num] += 1;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }

            int count = 0;

            if (diff == 0)
            {
                foreach (var n in dict.Values)
                {
                    if (n > 1)
                    {
                        count++;
                    }
                }
                return count;
            }

            foreach (var num in dict.Keys)
            {
                if (dict.ContainsKey(num + diff))
                {
                    count++;
                }
            }

            return count;
        }



        /// <summary>
        /// Brute force approach
        /// O(n^2) this loops through all possible pair one after the other
        /// Does not handle duplicate pairs
        /// </summary>
        public int AbsolutePairUsingBruteForce(int[] values, int diff)
        {
            int count = 0;

            var numbers = values;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int shift = 1 + i;
                while (shift < numbers.Length)
                {
                    if (Math.Abs(numbers[i] - numbers[shift]) == diff)
                    {
                        count++;
                    }

                    shift++;
                }
            }
            return count;
        }
        /// <summary>
        /// Absolute Difference using Sliding Window
        /// </summary>

        static int AbsoluteDifferenceSlidingWindow(int[] nums, int k)
        {
            Array.Sort(nums);
            int count = 0;
            int i = 0;
            int j = nums.Length - 1;
            if (j == 0)
                return 0;
            while (j > 0)
            {
                if (nums[j] - nums[i] == k)
                {
                    count++;
                    i++;
                    continue;
                }
                else if (nums[j] - nums[i] < k)
                {
                    j--;
                    i = 0;
                    continue;
                }
                else
                    i++;
            }
            return count;
        }

        /// <summary>
        /// Count of pairs with Absolute Difference in an Array 
        /// </summary>
        /// <returns></returns>
        static int AbsoluteDifferenceUsingHashTable(int[] nums, int k)
        {

            var dict = new Dictionary<int, int>();

            int count = 0;
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num] += 1;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num + k))
                {
                    count += dict[num + k];
                }
            }
            return count;

        }
    }
}
