using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    /// Given an array of positive numbers and a positive number ‘S,’ find the length of the smallest 
    /// contiguous subarray whose sum is greater than or equal to ‘S’. Return 0 if no such subarray exists.
    /// 
    /// Input: [2, 1, 5, 2, 3, 2], S=7 
    /// Output: 2
    /// Explanation: The smallest subarray with a sum greater than or equal to '7' is [5, 2].
    /// 
    /// Input: [2, 1, 5, 2, 8], S=7 
    /// Output: 1
    /// Explanation: The smallest subarray with a sum greater than or equal to '7' is [8].
    /// 
    /// Input: [3, 4, 1, 1, 6], S=8 
    /// Output: 3
    /// Explanation: Smallest subarrays with a sum greater than or equal to '8' are[3, 4, 1]
    /// or[1, 1, 6].
    /// </summary>
    public class SmallestSubarrayWithAGreaterSum
    {

        public static int SlidingWindow(int[] array , int s)
        {
            int length = int.MaxValue;

            int left = 0;
            int right = 0;
            int sum = array[right];

            int tempLength = 1; 

            while(true)
            {
                if (sum >= s)
                {
                    if (tempLength < length)
                    {
                        length = tempLength;
                    }
                    --tempLength;
                    sum -= array[left++];
                }
                else
                {
                    right++;
                    tempLength++;
                    if (right == array.Length)
                    {
                        break;
                    }

                    sum += array[right];

                }
            }


            return length; 
        }

        public static int SlidingWindow2(int[] array, int s)
        {
            int length = int.MaxValue;

            int sum = 0;
            int start = 0;

            for(int end = 0; end < array.Length; end++)
            {
                sum += array[end]; 

                while(sum >= s)
                {
                    length = Math.Min(length, end - start + 1);
                    sum -= array[start++];
                }
            }

            return length; 
        }
    }
}
