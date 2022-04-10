using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// find the max sum sub array s
    /// </summary>
    public class MaxSumSubArray
    {
        //[-2, 1, -3, 4, -1, 2, 1, -5,4]
        // (n ^ 3)
        public static int BruteForce(int[] array)
        {
            int max = 0;

            int left = 0;

            int k = 1;  

            while (k <= array.Length)
            {
                while (left + k  <= array.Length)
                {
                    int sum = 0;
                    for (int i = left; i < left + k; i++)
                    {
                        sum += array[i];
                    }
                    max = Math.Max(max, sum);
                    left++;
                }
                k++;
                left = 0;
            }

            return max; 
        }


        /// <summary>
        /// Divide the array into two half recursively and calculate the max sum 
        ///  (nlogn)
        /// </summary>
 
        public static int DivideAndConquer(int[] array)
        {
            int max = MaxSubarraySum(array, 0, array.Length-1);

            return max; 
        }
        private static int MaxSubarraySum(int[] A, int low, int high)
        {
            if (low == high)
                return A[low];
         
            int mid = low + (high - low) / 2;
            int left_sum = MaxSubarraySum(A, low, mid);
            int right_sum = MaxSubarraySum(A, mid + 1, high);
            int crossing_Sum = MaxCrossingSum(A, low, mid, high);


            return Math.Max(left_sum, Math.Max(right_sum, crossing_Sum));
             
        }


        private static int MaxCrossingSum(int[] A, int l, int mid, int r)
        {
            int sum = 0;
            int lsum = int.MinValue; 
               for (int i = mid; i >= l; i--)
                {
                    sum += A[i];

                    lsum = Math.Max(sum, lsum); 
                }

            sum = 0;
            int rsum = int.MinValue;

            for (int i = mid + 1; i <= r; i++)
            {
                sum += A[i];
                rsum = Math.Max(sum, rsum);
            }
            return (lsum + rsum);
        }
        public static int KadaneAlogrithm (int[] array)
        {
            int max = array[0];

            for(int i = 1; i< array.Length; i++)
            {
                array[i] = Math.Max(array[i], array[i] + array[i - 1]);

                max = Math.Max(array[i], max);
            }

            return max; 
        }
    }


    public class MinInsertion
    {

        public static int Find(int[] array, int[] pattern)
        {
            int num = 0;

            return num; 
        }
    }
}
