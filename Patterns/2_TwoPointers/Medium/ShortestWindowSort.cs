using System;

namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// Minimum Window Sort (medium)#
    /// Given an array, find the length of the smallest subarray in it which when sorted will sort the whole array.

    //  Example 1:
    //  Input: [1, 2, 5, 3, 7, 10, 9, 12]
    //  Output: 5
    //  Explanation: We need to sort only the subarray[5, 3, 7, 10, 9] to make the whole array sorted

    //  Example 2:
    //  Input: [1, 3, 2, 0, -1, 7, 10]
    //  Output: 5
    //  Explanation: We need to sort only the subarray[1, 3, 2, 0, -1] to make the whole array sorted

    //  Example 3:
    //  Input: [1, 2, 3]
    //  Output: 0
    //  Explanation: The array is already sorted

    //  Example 4:
    //  Input: [3, 2, 1]
    //  Output: 3
    //  Explanation: The whole array needs to be sorted.
    /// </summary>
    public class ShortestWindowSort
    {

        public static int Sort(int[] arr)
        {
            int low = 0, high = arr.Length - 1;
            // find the first number out of sorting order from the beginning
            while (low < arr.Length - 1 && arr[low] <= arr[low + 1])
                low++;

            if (low == arr.Length - 1) // if the array is sorted
                return 0;

            // find the first number out of sorting order from the end
            while (high > 0 && arr[high] >= arr[high - 1])
                high--;

            // find the maximum and minimum of the subarray
            int subarrayMax = int.MinValue, subarrayMin = int.MaxValue;
            for (int k = low; k <= high; k++)
            {
                subarrayMax = Math.Max(subarrayMax, arr[k]);
                subarrayMin = Math.Min(subarrayMin, arr[k]);
            }

            // extend the subarray to include any number which is bigger than the minimum of the subarray 
            while (low > 0 && arr[low - 1] > subarrayMin)
                low--;
            // extend the subarray to include any number which is smaller than the maximum of the subarray
            while (high < arr.Length - 1 && arr[high + 1] < subarrayMax)
                high++;

            return high - low + 1;
        }

        public static int Sort2(int[] arr)
        {
            // TODO: Write your code here

            int left = 1;
            int right = arr.Length - 2;
            int startIndex = -1;
            int stopIndex = -1;

            while (left <= right)
            {

                if (arr[left] >= arr[left - 1] && startIndex == -1)
                {
                    left++;
                }
                else
                {
                    startIndex = left - 1;
                }

                if (arr[right] <= arr[right + 1] && stopIndex == -1)
                {
                    right--;
                }
                else
                {
                    stopIndex = right + 1;
                }

                if (startIndex != -1 && stopIndex != -1)
                {
                    break;
                }

            }
            if (stopIndex == -1 && startIndex == -1)
            {
                return 0;
            }

            //find min and max value 
            int min = int.MaxValue, max = int.MinValue; 

            for (int i = startIndex; i <= stopIndex; i++)
            {

                min = Math.Min(min, arr[i]);
                max = Math.Max(max, arr[i]);
            }

            //include values
            while (startIndex > 0 && arr[startIndex - 1] > min)
                startIndex--;
            // extend the subarray to include any number which is smaller than the maximum of the subarray
            while (stopIndex < arr.Length - 1 && arr[stopIndex + 1] < max)
                stopIndex++;


            return stopIndex - startIndex + 1;
        }
    }
}
