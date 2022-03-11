﻿namespace Patterns._3_FastAndSlowPointers
{
    /// <summary>
    /// QUESTION: Is Cycle In a Circluar Array (HARD) 
    /// 
    /// We are given an array containing positive and negative numbers. Suppose the array contains a number ‘M’ at a particular index. Now, if ‘M’ is positive we will move forward ‘M’ indices and if ‘M’ is negative move backwards ‘M’ indices. You should assume that the array is circular which means two things:

    // If, while moving forward, we reach the end of the array, we will jump to the first element to continue the movement.
    // If, while moving backward, we reach the beginning of the array, we will jump to the last element to continue the movement.
    // Write a method to determine if the array has a cycle.The cycle should have more than one element and should follow one
    // direction which means the cycle should not contain both forward and backward movements.

    /* Example 1:
        Input: [1, 2, -1, 2, 2]
        Output: true
        Explanation: The array has a cycle among indices: 0 -> 1 -> 3 -> 0
        Example 2:

        Input: [2, 2, -1, 2]
        Output: true
        Explanation: The array has a cycle among indices: 1 -> 3 -> 1
        Example 3:

        Input: [2, 1, -1, -2]
        Output: false
        Explanation: The array does not have any cycle.
     */
    /// </summary>

    public class CycleInArray
    {
        public static bool LoopExist(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                bool isForward = arr[i] >= 0; // if we are moving forward or not
                int slow = i, fast = i;

                // if slow or fast becomes '-1' this means we can't find cycle for this number
                do
                {
                    slow = FindNextIndex(arr, isForward, slow); // move one step for slow pointer
                    fast = FindNextIndex(arr, isForward, fast); // move one step for fast pointer
                    if (fast != -1)
                        fast = FindNextIndex(arr, isForward, fast); // move another step for fast pointer
                } while (slow != -1 && fast != -1 && slow != fast);

                if (slow != -1 && slow == fast)
                    return true;
            }

            return false;
        }

        private static int FindNextIndex(int[] arr, bool isForward, int currentIndex)
        {
            bool direction = arr[currentIndex] >= 0;
            if (isForward != direction)
                return -1; // change in direction, return -1

            int nextIndex = (currentIndex + arr[currentIndex]) % arr.Length;
            if (nextIndex < 0)
                nextIndex += arr.Length; // wrap around for negative numbers

            // one element cycle, return -1 
            if (nextIndex == currentIndex)
                nextIndex = -1;

            return nextIndex;
        }
    }
}