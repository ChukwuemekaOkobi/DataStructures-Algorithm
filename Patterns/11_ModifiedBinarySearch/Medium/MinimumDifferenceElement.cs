using System;

namespace Patterns._11_ModifiedBinarySearch
{
    /// <summary>
    /// Given an array of numbers sorted in ascending order, find the element in the array that has the minimum difference with the given ‘key’.

    //Example 1:

    //Input: [4, 6, 10], key = 7
    //Output: 6
    //Explanation: The difference between the key '7' and '6' is minimum than any other number in the array
    //Example 2:

    //Input: [4, 6, 10], key = 4
    //Output: 4
    //Example 3:

    //Input: [1, 3, 8, 10, 15], key = 12
    //Output: 10
    //Example 4:

    //Input: [4, 6, 10], key = 17
    //Output: 10
    /// </summary>
    public class MinimumDifferenceElement
    {

        public static int Search(int[] array, int key)
        {
            int left = 0;
            int right = array.Length - 1;

            int difference = int.MaxValue;
            int diffIndex = -1;
            if (key < array[left])
                return array[left];
            if (key > array[right])
                return array[right];

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (key == array[mid])
                {
                    return array[mid];
                }

                int newDiff = Math.Abs(key - array[mid]);

                if (key > array[mid])
                {
                   left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }

                if (difference > newDiff)
                {
                    difference = newDiff;
                    diffIndex = mid;
                }
            }

            return array[diffIndex];

        }
    }



}
