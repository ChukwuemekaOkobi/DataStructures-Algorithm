namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// Write a function that given an array A of N integers and an integer K, 
    //    returns an integer denoting the minimal amplitude that can be obtained
    //    after the removal of K consecutive elements from A.

    //    Examples :
    //a.Given A = [5, 3, 6, 1, 3] and K = 2, the function should return 2. You can remove the third and fourth elements to obtain the following array: [5,3,3]. Its maximal elements is 5 and its minimal element is 3, so the amplitude is 2.
    //b.Given A = [8, 8, 4, 3] and K = 2, the function should return 0. You can remove the third and fourth elements to obtain the array [8,8], whose amplitude is equal to 0.
    //c.Given A = [3, 5, 1, 3, 9, 8] and K = 4, the function should return 1. You can remove the first, second , third and fourth elements to obtain the array [9,8], whose amplitude equals

    /// </summary>

    public class MinAmplitude
    {
        public static int AfterKRemovalBruteForce(int[] nums, int k)
        {
            //get minimums of each array 
            int min = int.MaxValue;

            int left = 0;
            int right = left + k - 1;

            for(int i = 0; i< nums.Length; i++)
            {
                int j = 0; 
                while (j < nums.Length)
                {
                    
                }

            }

            return min;
        }
    }
}

