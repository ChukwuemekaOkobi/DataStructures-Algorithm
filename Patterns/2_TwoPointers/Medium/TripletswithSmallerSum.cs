using System;
using System.Collections.Generic;

namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// QUESTION: Triplets with Smaller Sum (medium)
    /// Given an array arr of unsorted numbers and a target sum, count all triplets in it such that arr[i] + arr[j] + arr[k] < target 
    /// where i, j, and k are three different indices. Write a function to return the count of such triplets.
    /// Example 1:

    /// Input: [-1, 0, 2, 3], target=3 
    /// Output: 2
    /// Explanation: There are two triplets whose sum is less than the target: [-1, 0, 3], [-1, 0, 2]
    /// Example 2:

    /// Input: [-1, 4, 2, 1, 3], target=5 
    /// Output: 4
    /// Explanation: There are four triplets whose sum is less than the target: 
    /// [-1, 1, 4], [-1, 1, 3], [-1, 1, 2], [-1, 2, 3]
    /// </summary>
    public class TripletswithSmallerSum
    {

        /// <summary>
        /// Time Complexity = (NlogN) + (N2)
        /// </summary>

        public static int SearchTripletCount(int[] arr, int target)
        {
            Array.Sort(arr);

            int count = 0;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                int left = i + 1;
                int right = arr.Length - 1;
                int hold = arr[i];

                while (left < right)
                {

                    int sum = hold + arr[left] + arr[right];

                    if (sum < target)
                    {
                        //trick here is if the sum is less than the target then every value 
                        //between left and right should give a sum less than the target

                        count += right - left;
                        left++;
                    }
                    else
                    {
                        right--; // we need a pair with a smaller sum
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Time Complexity  = (NlogN) + (N3)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<List<int>> SearchTripletList(int[] arr, int target)
        {

            var list = new List<List<int>>();

            for (int i = 0; i < arr.Length - 2; i++)
            {
                int left = i + 1;
                int right = arr.Length - 1;
                int hold = arr[i];

                while (left < right)
                {

                    int sum = hold + arr[left] + arr[right];

                    if (sum < target)
                    {
                        //trick here is if the sum is less than the target then every value 
                        //between left and right should give a sum less than the target
                        int count = right;
                        while (left < count)
                        {
                            //add all triplet to the list
                            list.Add(new List<int> { hold, arr[left], arr[count] });
                            count--;
                        }
                        left++;
                    }
                    else
                    {
                        right--; // we need a pair with a smaller sum
                    }
                }
            }

            return list;
        }
    }
}
