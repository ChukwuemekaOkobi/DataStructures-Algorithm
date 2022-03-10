using System;
using System.Collections.Generic;

namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// Quadruple Sum to Target (medium)#
    //    Given an array of unsorted numbers and a target number, find all unique quadruplets in it, whose sum is equal to the target number.

    //    Example 1:

    //Input: [4, 1, 2, -1, 1, -3], target=1
    //Output: [-3, -1, 1, 4], [-3, 1, 1, 2]
    //    Explanation: Both the quadruplets add up to the target.
    //    Example 2:

    //Input: [2, 0, -1, 1, -2, 2], target= 2
    //    Output: [-2, 0, 2, 2], [-1, 0, 1, 2]
    //Explanation: Both the quadruplets add up to the target.
    /// </summary>

    public class QuadrupleSumToTarget
    {
        public static List<List<int>> SearchQuadruplets(int[] arr, int target)
        {

            Array.Sort(arr);
            List<List<int>> quadruplets = new ();

            for (int i = 0; i < arr.Length - 3; i++)
            {

                if (i > 0 && arr[i] == arr[i - 1]) // skip same element to avoid duplicate quadruplets  
                    continue;

                int first = target - arr[i];

                for (int j = i + 1; j < arr.Length - 2; j++)
                {
                    if (j > i + 1 && arr[j] == arr[j - 1]) // skip same element to avoid duplicate quadruplets
                        continue;

                    int second = first - arr[j];

                    int left = j + 1;
                    int right = arr.Length - 1;

                    while (left < right)
                    {

                        if (second == arr[left] + arr[right])
                        {

                            quadruplets.Add(new List<int> { arr[i], arr[j], arr[left], arr[right] });
                            left++; right--;

                            while (left < right && arr[left] == arr[left - 1])
                                left++; // skip same element to avoid duplicate quadruplets
                            while (left < right && arr[right] == arr[right + 1])
                                right--;
                        }
                        else if (arr[left] + arr[right] < second)
                        {
                            left++; // we need a pair with a bigger sum
                        }
                        else
                        {
                            right--; // we need a pair with a smaller sum
                        }
                    }

                }

            }
            // TODO: Write your code here
            return quadruplets;
        }
    }
}
