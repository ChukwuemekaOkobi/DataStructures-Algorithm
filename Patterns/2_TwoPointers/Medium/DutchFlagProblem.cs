namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// Given an array containing 0s, 1s and 2s, sort the array in-place. 
    /// You should treat numbers of the array as objects, 
    /// hence, we can’t count 0s, 1s, and 2s to recreate the array.

    /// The flag of the Netherlands consists of three colors: red, white and blue; 
    /// and since our input array also consists of three different numbers 
    /// that is why it is called Dutch National Flag problem.
    /// 
    /// Input: [1, 0, 2, 1, 0]
    /// Output: [0, 0, 1, 1, 2]

    /// 
    /// Input: [2, 2, 0, 1, 2, 0]
    /// Output: [0, 0, 1, 2, 2, 2,]
    /// </summary>
    public class DutchFlagProblem
    {
        public static void Sort(int[] arr)
        {
            int low = 0, high = arr.Length - 1;
            for (int i = 0; i <= high;)
            {
                if (arr[i] == 0)
                {
                    Swap(ref arr[i],ref arr[low]);
                    // increment 'i' and 'low'
                    i++;
                    low++;
                }
                else if (arr[i] == 1)
                {
                    i++;
                }
                else
                { // the case for arr[i] == 2
                    Swap(ref arr[i], ref arr[ high]);
                    // decrement 'high' only, after the swap the number at index 'i' could be 0, 1 or 2
                    high--;
                }
            }


            static void Swap(ref int i, ref int j)
            {
                int temp = i;
                i = j;
                j = temp;
            }
        }
    }
}
