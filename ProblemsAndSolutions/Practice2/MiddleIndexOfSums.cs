namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// Given a 
    /// </summary>
    public class MiddleIndexOfSums
    {

        public static int FindMiddleIndex(int[] nums)
        {
            int s = 0;
            int l = nums.Length;
            foreach (int i in nums)
            {
                s += i;
            }
            int curr_sum = 0;
            for (int i = 0; i < l; i++)
            {
                curr_sum += nums[i];
                int r_sum = s - (curr_sum);
                int l_sum = curr_sum - nums[i];
                if (r_sum == l_sum)
                {
                    return i;
                }
            }
            return -1;
        }
    }




}

