namespace Patterns._5_CyclicSort
{
    /// <summary>
    /// Find the Corrupt Pair (easy)#
    //    We are given an unsorted array containing ‘n’ numbers taken from the range 1 to ‘n’.
    //    The array originally contained all the numbers from 1 to ‘n’, but due to a data error,
    //    one of the numbers got duplicated which also resulted in one number going missing.Find both these numbers.

    //    Example 1:

    //    Input: [3, 1, 2, 5, 2]
    //Output: [2, 4]
    //Explanation: '2' is duplicated and '4' is missing.
    //    Example 2:


    //    Input: [3, 1, 2, 3, 6, 4]
    //Output: [3, 5]
    //Explanation: '3' is duplicated and '5' is missing.
    /// </summary>
    public class CorruptPair
    {
        public static int[] Find(int[] nums)
        {
            // TODO: Write your code here

            int duplicate = 0;
            int missing = 0;

            int i = 0;
            while (i < nums.Length)
            {

                if (nums[i] != i + 1 && nums[i] != nums[nums[i] - 1])
                {

                    FindMissingNumber.Swap(nums[i] - 1, i,nums);

                }
                else
                {
                    i++;
                }
            }

            for (int j = 0; j < nums.Length; j++)
            {

                if (nums[j] != j + 1)
                {
                    missing = j + 1;
                    duplicate = nums[j];
                    break;
                }
            }

            return new int[] { duplicate, missing };
        }
    }
}
