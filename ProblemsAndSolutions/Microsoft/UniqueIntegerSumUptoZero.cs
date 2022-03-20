namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// Given an integer n, return any array containing n unique integers such that they add up to 0.
    /// </summary>
    public class UniqueIntegerSumUptoZero
    {

        public static int[] Find(int n)
        {
            int[] ans = new int[n];

            int mid = n / 2;

            bool isEven = n % 2 == 0;

            int index = 0;
            for (int i = -mid; i <= mid; i++)
            {

                if (i == 0 && isEven)
                {
                    continue;
                }

                ans[index++] = i;

            }

            return ans;
        }
    }

}

