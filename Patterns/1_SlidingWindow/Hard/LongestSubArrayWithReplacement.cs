using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    /// QUESTION: Longest Subarray with Ones after Replacement (hard)
    /// Given an array containing 0s and 1s, if you are allowed to replace no more than ‘k’ 0s with 1s, 
    /// find the length of the longest contiguous subarray having all 1s.
    /// 
    /// Input: Array=[0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1], k=2
    /// Output: 6
    /// Explanation: Replace the '0' at index 5 and 8 to have the longest contiguous subarray of 1s having length 6.
    /// 
    /// Input: Array=[0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1], k=3
    /// Output: 9
    /// Explanation: Replace the '0' at index 6, 9, and 10 to have the longest contiguous subarray of 1s having length 9.
    /// 
    /// 
    /// Check for the frequency of one in any window and match the required zeros to be converted
    /// </summary>
    public class LongestSubArrayWithReplacement
    {
        public static int Length( int k, params int[] arr)
        {
            int length = 0;
            int frequency = 0;
            int start = 0; 

            for(int end = 0; end < arr.Length; end++)
            {
                if(arr[end] == 1)
                {
                    frequency++; 
                }

                //check for the number of 0s that can to be turned to 1
                //in a particular window

                int windowLength = end - start + 1;

                //shrink window when size exceed required number
                if((windowLength-frequency) > k)
                {
                    if (arr[start] == 1)
                    {
                        frequency--;
                    }
                        start++;

                    
                }

                length = Math.Max(length, end-start+1);
            }

            return length; 
        }
    }

}
