﻿namespace Patterns._11_ModifiedBinarySearch
{
    /// <summary>
    /// Ceiling of a Number 
    /// Given an array of numbers sorted in an ascending order, find the ceiling of a given number ‘key’.
    /// The ceiling of the ‘key’ will be the smallest element in the given array greater than or equal to the ‘key’.
    /// Write a function to return the index of the ceiling of the ‘key’. If there isn’t any ceiling return -1. 
    /// Given an array of numbers sorted in an ascending order, find the ceiling of a given number ‘key’. The ceiling of the ‘key’ 
    /// will be the smallest element in the given array greater than or equal to the ‘key’.

    //Write a function to return the index of the ceiling of the ‘key’. If there isn’t any ceiling return -1.

    //Example 1:

    //Input: [4, 6, 10], key = 6
    //Output: 1
    //Explanation: The smallest number greater than or equal to '6' is '6' having index '1'.
    //Example 2:

    //Input: [1, 3, 8, 10, 15], key = 12
    //Output: 4
    //Explanation: The smallest number greater than or equal to '12' is '15' having index '4'.
    //Example 3:

    //Input: [4, 6, 10], key = 17
    //Output: -1
    //Explanation: There is no number greater than or equal to '17' in the given array.
    //Example 4:

    //Input: [4, 6, 10], key = -1
    //Output: 0
    //Explanation: The smallest number greater than or equal to '-1' is '4' having index '0'. 
    /// </summary>

    public class CeilingNumber
    {

        public static int Find(int[] array, int key)
        {

            int left = 0;
            int right = array.Length - 1;

            if (key > array[right])
            {
                return -1;
            }

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (key == array[mid])
                {
                    return mid;
                }

                if (key > array[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }
    }


    /// <summary>
    /// Given an infinite sorted array (or an array with unknown size), find if a given number ‘key’ is present in the array.
    /// Write a function to return the index of the ‘key’ if it is present in the array, otherwise return -1.
    //    Since it is not possible to define an array with infinite(unknown) size, you will be provided with an
    //    interface ArrayReader to read elements of the array.ArrayReader.get(index) will return the number at index;
    //    if the array’s size is smaller than the index, it will return Integer.MAX_VALUE.

    //  Example 1:

    //Input: [4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30], key = 16
    //Output: 6
    //Explanation: The key is present at index '6' in the array.
    //Example 2:

    //Input: [4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30], key = 11
    //Output: -1
    //Explanation: The key is not present in the array.
    //Example 3:

    //Input: [1, 3, 8, 10, 15], key = 15
    //Output: 4
    //Explanation: The key is present at index '4' in the array.
    //Example 4:

    //Input: [1, 3, 8, 10, 15], key = 200
    //Output: -1
    //Explanation: The key is not present in the array.
    /// </summary>
    public class InfiniteArray
    {
        
    }

}