using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    ///   Maximum Sum Subarray of Size K (easy)
    ///   Given an array of positive numbers and a positive number ‘k,’ find the maximum sum of any contiguous subarray of size ‘k’
    ///  Input: [2, 1, 5, 1, 3, 2], k=3 
    ///  Output: 9
    ///  Explanation: Subarray with maximum sum is [5, 1, 3].
    ///  
    ///  Input: [2, 3, 4, 1, 5], k=2 
    ///  Output: 7
    ///  Explanation: Subarray with maximum sum is [3, 4].
    /// 
    /// </summary>

    public class MaximumSumSubarray
    {
        /// <summary>
        /// Sum all sub array of size k 
        /// Time Complexity = O(n * k) 
        /// </summary>
        public static int BruteForce (int[] array, int k)
        {
            int max = -1; 

            for(int i = 0; i< array.Length - (k-1);  i++)
            {
                int sum = 0; 

                for(int j = i; j<i+k; j++)
                {
                    sum += array[j];
                }

                if(max < sum)
                {
                    max = sum; 
                }
            }

            return max; 
        }

        /// <summary>
        ///  Reuse previous sum in the next calculation 
        ///  and move the sliding window to the next
        /// </summary>

        public static int SlidingWindow(int[] array, int k)
        {
            int max = -1;
            int sum = 0;
            int windowstart = 0; 

            for(int i = 0; i< array.Length; i++)
            {
                sum += array[i]; 

                if(i >= k - 1)
                {
                    if(max < sum)
                    {
                        max = sum; 
                    }
                    sum -= array[windowstart++];
                }
            }
            return max;
        }
    }
}
