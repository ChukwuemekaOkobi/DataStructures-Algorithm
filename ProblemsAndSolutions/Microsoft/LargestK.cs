using System;
using System.Collections.Generic;

namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// Given an array A of N integers, returns the largest integer K > 0 such that 
    /// both values K and -K exist in array A. If there is no such integer, the function should return 0.

    //    Example 1:
    //Input:[3, 2, -2, 5, -3]
    //    Output: 3
    //Example 2:
    //Input:[1, 2, 3, -4]
    //    Output: 0
    /// </summary>
    public class LargestK
    {
        public static int Find (int[] nums)
        {
            //sort the array 
            Array.Sort(nums);

            int max = int.MinValue; 

            int left = 0;
            int right = nums.Length - 1; 

            while(left < right)
            {
                int value = nums[left] + nums[right];

                if(value == 0)
                {
                    max = Math.Max(max, nums[right]);
                    return max; 
                }
                else if(value < 0)
                {
                    left++;
                }
                else
                {
                    right--; 
                }

            }

            return 0;
        }

        public static int FindUsingSet (int[] nums)
        {
            HashSet<int> set = new();

            int max = 0; 

            foreach(var n in nums)
            {
                if (set.Contains(-n))
                {
                    max = Math.Max(max, Math.Abs(n));
                }
                else
                {
                    set.Add(n);
                }
            }

            return max; 
        }
    }
}

