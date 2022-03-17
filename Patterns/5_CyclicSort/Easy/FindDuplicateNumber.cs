using System.Collections.Generic;

namespace Patterns._5_CyclicSort
{
    /// <summary>
    /// Problem Statement#
    //    We are given an unsorted array containing ‘n+1’ numbers taken from the range 1 to ‘n’.
    //    The array has only one duplicate but it can be repeated multiple times.
    //    Find that duplicate number without using any extra space.You are, however, allowed to modify the input array.
    //   Example 1:
    //   Input: [1, 4, 4, 3, 2]
    //Output: 4
    //Example 2:

    //   Input: [2, 1, 3, 3, 5, 4]
    //Output: 3
    //Example 3:

    //   Input: [2, 4, 1, 4, 4]
    //Output: 4
    /// </summary>
    public class FindDuplicateNumber
    { 

        public static int Find(int[] nums)
        {
            // TODO: Write your code here

            int i = 0;
            while (i < nums.Length)
            {

                if (nums[i] != i + 1)
                {
                    
                    if(nums[nums[i]-1] != nums[i])
                       FindMissingNumber.Swap(i, nums[i] - 1, nums);

                    else // we have found the duplicate
                        return nums[i];
                }
                else
                {
                    i++;
                }
            }

            return i;
        }

        public static List<int> FindAllDuplicates(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {

                if (nums[i] != i + 1 && nums[i] != nums[nums[i] - 1])
                {

                    FindMissingNumber.Swap(i, nums[i] - 1, nums);
                   
                }
                else
                {
                    i++;

                }
            }
            List<int> duplicateNumbers = new List<int>();

            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                    duplicateNumbers.Add(nums[i]);
            }

            return duplicateNumbers;
        }

        public static int FindDuplicate(int[] arr)
        {
            int slow = 0, fast = 0;
            do
            {
                slow = arr[slow];
                fast = arr[arr[fast]];
            } while (slow != fast);

            // find cycle length
            int current = arr[slow];
            int cycleLength = 0;
            do
            {
                current = arr[current];
                cycleLength++;
            } while (current != arr[slow]);

            return FindStart(arr, cycleLength);
        }

        private static int FindStart(int[] arr, int cycleLength)
        {
            int pointer1 = arr[0], pointer2 = arr[0];
            // move pointer2 ahead 'cycleLength' steps
            while (cycleLength > 0)
            {
                pointer2 = arr[pointer2];
                cycleLength--;
            }

            // increment both pointers until they meet at the start of the cycle
            while (pointer1 != pointer2)
            {
                pointer1 = arr[pointer1];
                pointer2 = arr[pointer2];
            }

            return pointer1;
        }
    
       
    
    }
}
