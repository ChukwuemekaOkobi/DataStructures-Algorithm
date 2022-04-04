using System;

namespace Patterns._11_ModifiedBinarySearch
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

    public class SearchRotatedArray
    {
        public static int Find(int[] arr, int key)
        {
            int maxIndex = -1;
            int max = -1;
            for (int i = 0; i < arr.Length - 1; i++)
            {

                if (max < arr[i])
                {
                    maxIndex = i;
                    max = arr[i];
                }
            }

            int first = Bsearch(arr, key, 0, maxIndex);

            if (first != -1)
            {
                return first;
            }
            return Bsearch(arr, key, maxIndex + 1, arr.Length - 1);

        }


        private static int Bsearch(int[] arr, int key, int start, int end)
        {
            while (start <= end)
            {

                int mid = start + (end - start) / 2;

                if (arr[mid] == key)
                {
                    return mid;
                }

                if (arr[mid] > key)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }

            }

            return -1;
        }


        public static int Search(int[] arr, int key)
        {
            int start = 0, end = arr.Length - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (arr[mid] == key)
                    return mid;

                if (arr[start] <= arr[mid])
                { // left side is sorted in ascending order
                    if (key >= arr[start] && key < arr[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    { //key > arr[mid]
                        start = mid + 1;
                    }
                }
                else
                { // right side is sorted in ascending order       
                    if (key > arr[mid] && key <= arr[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }

            // we are not able to find the element in the given array
            return -1;
        }
    }
}