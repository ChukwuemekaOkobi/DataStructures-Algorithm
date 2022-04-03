using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._11_ModifiedBinarySearch
{
    /// <summary>
    /// Problem Statement #
    //    Given a sorted array of numbers, find if a given number ‘key’ is present in the array.
    //    Though we know that the array is sorted, we don’t know if it’s sorted in ascending or descending order.
    //    You should assume that the array can have duplicates.

    //    Write a function to return the index of the ‘key’ if it is present in the array, otherwise return -1.
    //    Example 1:
    //    Input: [4, 6, 10], key = 10
    //    Output: 2
    //    Example 2:
    //    Input: [1, 2, 3, 4, 5, 6, 7], key = 5
    //    Output: 4
    //    Example 3:
    //    Input: [10, 6, 4], key = 10
    //    Output: 0
    //    Example 4:
    //    Input: [10, 6, 4], key = 4
    //    Output: 2
    /// </summary>
    public class OrderAgnosticBinarySearchs
    {
        public static int Search(int[] arr, int key)
        {
            //find order 
            bool isAscending = arr[0] < arr[^1];


            int left = 0;
            int right = arr.Length - 1;


            //binary Search
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == key)
                {
                    return mid;
                }
                else if (isAscending)
                {
                    if (arr[mid] > key)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (arr[mid] > key)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

            }

            return -1;
        }

    }
}
