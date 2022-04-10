using System;
using System.Collections.Generic;

namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// if continous subsequence is required look for sub array
    /// </summary>
    public class SubSequence
    {

        /// <summary>
        /// Check all possible subsequences 
        /// O(2 ^ N)
        /// </summary>

        public static int LongestIncreasingBruteforce(int[] array)
        {
            int length = 0;

            for(int i = 0; i< array.Length-1; i++)
            {
                int current = array[i];
                int subLength = 1;

                for (int j = i; j < array.Length; j++) 
                {
                    if(current < array[j])
                    {
                        current = array[j];
                        subLength++; 
                    }
                }

                length = Math.Max(length, subLength);
            }

            return length; 
        }

        /// <summary>
        ///  Find the alongest subsequence in each sub array 
        ///  and compare that to the next in array
        ///  O(N ^ 2)
        /// </summary>

        public static int LongestIncreasingDynamicProgramming(int [] array)
        {
            int[] dp = new int[array.Length];

            dp[0] = 1;
            int max = 1;

            for (int i = 1; i < array.Length; i++)
            {
           
                for (int j = 0; j < i; j++)
                {
                
                    if (array[j] < array[i])
                    {
                        dp[i] = Math.Max(dp[j] + 1, dp[i]);
                    }
                    else
                    {
                        dp[i] = Math.Max(dp[i], 1);
                    }
                    max = Math.Max(dp[i], max);
                }
            }

           

            return max;
        }

        /// <summary>
        /// Keep an list of increase value 
        /// Apply Binary search on this value 
        /// </summary>
 
        public static int LongestIncreasingBinarySearch(int [] array)
        {
        
            List<int> list = new();

            list.Add(array[0]);

            for(int i = 1; i< array.Length; i++)
            {
                int a = BinarySearch(list, array[i]);

                if(a == -1)
                {
                    list.Add(array[i]);
                }
                else
                {
                    list[a] = array[i];
                }
            }

            return  list.Count; 

        }


        //searching for the value least great than or value
        private static int BinarySearch(List<int> list, int value)
        {
            int left = 0, right = list.Count - 1, ans = int.MaxValue;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if(list[mid] >= value)
                {
                    ans = Math.Min(ans, mid);
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            if (ans != int.MaxValue) return ans; 

            return -1;
        }

    
    }
}
