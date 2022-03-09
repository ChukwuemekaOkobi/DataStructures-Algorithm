using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// QUESTION: Triplet Sum Close to Target (medium)
    /// Given an array of unsorted numbers and a target number, find a triplet in the array whose sum is 
    /// as close to the target number as possible, return the sum of the triplet.
    /// If there are more than one such triplet, return the sum of the triplet with the smallest sum.

    //Example 1:

    //Input: [-2, 0, 1, 2], target=2
    //Output: 1
    //Explanation: The triplet[-2, 1, 2] has the closest sum to the target.
    //Example 2:

    //Input: [-3, -1, 1, 2], target=1
    //Output: 0
    //Explanation: The triplet[-3, 1, 2] has the closest sum to the target.
    //Example 3:

    //Input: [1, 0, 1, 1], target=100
    //Output: 3
    //Explanation: The triplet[1, 1, 1] has the closest sum to the target.
    /// </summary>
    public class TripletSumCloseToTarget
    {
        public static int SearchTriplet(int[] arr, int targetSum)
        {
            Array.Sort(arr); 

            int sum = int.MinValue;

           

            for (int i = 0; i < arr.Length - 2; i++)
            {
                int item = arr[i];
                //search the rest on the array 
               sum = Math.Max(sum, Search(targetSum-item, arr, i + 1,item));
            }

            return sum;
        }

        private static int Search(int target, int[] array, int leftPointer, int item)
        {
            int sudm = 0;
            int rightPointer = array.Length - 1;

            while (leftPointer < rightPointer)
            {
                int sum = array[leftPointer] + array[rightPointer];
                if (sum == target)
                {
                     rightPointer--;
                }
                else if (sum < target)
                {
                    leftPointer++; //requires bigger sum
                    sudm = Math.Max(sum + item , sudm);
                }
                else
                {
                    rightPointer--; //requires lesser sums
                }
            }

            return sudm; 
    
        }

        public static int SearchTriplet2(int[] arr, int targetSum)
        {
            if (arr == null || arr.Length < 3)
                throw new Exception();

            Array.Sort(arr);
            int smallestDifference = int.MaxValue;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                int left = i + 1, right = arr.Length - 1;
                while (left < right)
                {
                    // comparing the sum of three numbers to the 'targetSum' can cause overflow
                    // so, we will try to find a target difference
                    int targetDiff = targetSum - arr[i] - arr[left] - arr[right];
                    if (targetDiff == 0) //  we've found a triplet with an exact sum
                        return targetSum; // return sum of all the numbers

                    // the second part of the above 'if' is to handle the smallest sum when we have more than one solution
                    if (Math.Abs(targetDiff) < Math.Abs(smallestDifference)
                        || (Math.Abs(targetDiff) == Math.Abs(smallestDifference) && targetDiff > smallestDifference))
                        smallestDifference = targetDiff; // save the closest and the biggest difference  

                    if (targetDiff > 0)
                        left++; // we need a triplet with a bigger sum
                    else
                        right--; // we need a triplet with a smaller sum
                }
            }
            return targetSum - smallestDifference;
        }

    }
}
