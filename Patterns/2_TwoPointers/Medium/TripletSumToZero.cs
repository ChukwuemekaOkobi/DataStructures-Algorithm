using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// QUESTION: Triplet Sum to Zero
    /// Given an array of unsorted numbers, find all unique triplets in it that add up to zero
    /**
     * Example 1:

    Input: [-3, 0, 1, 2, -1, 1, -2]
    Output: [-3, 1, 2], [-2, 0, 2], [-2, 1, 1], [-1, 0, 1]
    Explanation: There are four unique triplets whose sum is equal to zero.
    Example 2:

    Input: [-5, 2, -1, -2, 3]
    Output: [[-5, 2, 3], [-2, -1, 3]]
    Explanation: There are two unique triplets whose sum is equal to zero.
    */
    /// </summary>
    public class TripletSumToZero
    {

        public static List<List<int>> SearchTriplets(int[] arr)
        {
            Array.Sort(arr);
            var list = new List<List<int>>();

            for(int i = 0; i<arr.Length-2; i++)
            {
                int item = arr[i]; 
                if(i>0 && item == arr[i - 1])
                {  //skip if there are duplicates 
                    continue;
                   
                }
                //search the rest on the array 
                Search(-item, arr, i + 1, list);
            }

            return list; 
        }

        public static void Search(int target, int[] array, int leftPointer, List<List<int>> list)
        {

            int rightPointer = array.Length - 1; 

            while(leftPointer < rightPointer)
            {
                int sum = array[leftPointer] + array[rightPointer]; 
                if(sum == target)
                {
                    //all three numbers
                    list.Add(new List<int> { -target, array[leftPointer], array[rightPointer] });
                    //check for duplicates and skip them 
                    leftPointer++; rightPointer--;
                    while(leftPointer < rightPointer && array[leftPointer] == array[leftPointer - 1])
                    {
                        leftPointer++;
                    }
                    while(leftPointer < rightPointer && array[rightPointer] == array[rightPointer + 1])
                    {
                        rightPointer--;
                    }

                }
                else if(sum < target)
                {
                    leftPointer++; //requires bigger sum
                }
                else
                {
                    rightPointer--; //requires lesser sums
                }
            }
        }
       
    }
}
