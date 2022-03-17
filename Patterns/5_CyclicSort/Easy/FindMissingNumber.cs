using System;

namespace Patterns._5_CyclicSort
{
    /// <summary>
    /// We are given an array containing n distinct numbers taken from the range 0 to n. 
    /// Since the array has only n numbers out of the total n+1 numbers, find the missing number.

    // Example 1:

    //Input: [4, 0, 3, 1]
    //    Output: 2
    //Example 2:

    //Input: [8, 3, 5, 2, 4, 6, 0, 1]
    //    Output: 7
    /// </summary>
    public class FindMissingNumber
    {
        /// <summary>
        /// Time Complexity is O(NLogN)
        /// </summary>

        public static int Find(int[] nums)
        {
            Array.Sort(nums);



            for (int i = 0; i < nums.Length; i++)
            {

                if (nums[i] != i)
                {
                    return i;
                }

            }
            return nums.Length;
        }

        /// <summary>
        ///  Time Complexity O(n)
        /// </summary>

        public static int Inplace(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {

                if (nums[i] < nums.Length && nums[i] != i)
                {
                    Swap(i, nums[i], nums);
                }
                else
                {
                    i++;
                }
            }

            for (i = 0; i < nums.Length; i++)
                if (nums[i] != i)
                    return i;

            return nums.Length;
        }


        public static void Swap(int i, int j, int[] nums)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }


   
}
