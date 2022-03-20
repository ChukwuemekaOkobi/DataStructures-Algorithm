using System;

namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// QUESTION: First and Minimum Missing positive Integer 
    /// Given an unsorted integer array nums, return the smallest missing positive integer.
    /// You must implement an algorithm that runs in O(n) time and uses constant extra space.
    /// Example 1:

    //    Input: nums = [1,2,0]
    //    Output: 3
    //Example 2:

    //Input: nums = [3,4,-1,1]
    //    Output: 2
    //Example 3:

    //Input: nums = [7,8,9,11,12]
    //    Output: 1
    /// </summary>

    public class MinimumMissingPositiveInteger
    {
        /// <summary>
        /// Sorts the Array, then loops through the sorted array
        /// to find the missing number
        /// O(N*LogN) time
        /// O(N) space
        /// </summary>
  
        public static int FirstMissingPositive(int[] nums)
        {

            Array.Sort(nums);

            int i = 0;

            int count = 1;

            while (i < nums.Length)
            {

                int value = nums[i];

                if (value <= 0)
                {
                    i++;
                }

                else
                {

                    while (i + 1 != nums.Length && value == nums[i + 1])
                    {
                        value = nums[i + 1];
                        i++;
                    }
                    if (value != count)
                    {
                        break;
                    }
                    i++;
                    count++;
                }



            }

            return count;
        }

        /// <summary>
        /// numbers expected in the array should be [1-length]
        /// we swap numbers based on the index in the array to sort the 
        /// and if the value is in the rang i - length
        /// numbers properly
        /// O(n)
        /// </summary>
  
        public static int FirstMissingPositive2(int [] nums)
        {
            int n = nums.Length;
            int i = 0;

            while (i < n)
            {
                if (nums[i] > 0 && nums[i] <= n && nums[i] - 1 != i && nums[nums[i] - 1] != nums[i])
                {

                    Swap(nums, i, nums[i] - 1);
                }
                else
                    ++i;
            }

            for (int j = 0; j < n; ++j)
            {
                if (nums[j] != j + 1)
                    return j + 1;
            }

            return n + 1;

        }

     

 

        private static void Swap (int [] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp; 
        }
    }
}
