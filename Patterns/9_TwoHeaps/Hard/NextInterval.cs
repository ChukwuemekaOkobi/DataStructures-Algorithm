using Patterns._4_MergeIntervals;
using System.Collections.Generic;

namespace Patterns._9_TwoHeaps
{
    /// <summary>
    /// Given an array of intervals, find the next interval of each interval. In a list of intervals, for an interval ‘i’ its next interval ‘j’ will have the smallest ‘start’ greater than or equal to the ‘end’ of ‘i’.

    //    Write a function to return an array containing indices of the next interval of each input interval.If there is no next interval of a given interval, return -1. It is given that none of the intervals have the same start point.

    //    Example 1:


    //    Input: Intervals[[2, 3], [3,4], [5,6]]
    //Output: [1, 2, -1]
    //    Explanation: The next interval of[2, 3] is [3,4] having index ‘1’. Similarly, the next interval of[3, 4] is [5,6] having index ‘2’. There is no next interval for [5,6] hence we have ‘-1’.

    //Example 2:

    //Input: Intervals[[3, 4], [1,5], [4,6]]
    //Output: [2, -1, -1]
    //    Explanation: The next interval of[3, 4] is [4,6] which has index ‘2’. There is no next interval for [1,5] and[4, 6].
    /// </summary>

    public class NextInterval
    {
        public static int[] FindNextInterval(Interval[] intervals)
        {
            int n = intervals.Length;
            // heap for finding the maximum start
            PriorityQueue<int, int> maxStartHeap = new(n, new MaxComparer()); 
            // heap for finding the minimum end
            PriorityQueue<int, int> maxEndHeap = new(n, new MaxComparer()); 
            int[] result = new int[n];
            for (int i = 0; i < intervals.Length; i++)
            {
                maxStartHeap.Enqueue(i, intervals[i].Start);
                maxEndHeap.Enqueue(i, intervals[i].End);
            }

            // go through all the intervals to find each interval's next interval
            for (int i = 0; i < n; i++)
            {
                int topEnd = maxEndHeap.Dequeue(); // let's find the next interval of the interval which has the highest 'end' 
                result[topEnd] = -1; // defaults to -1
                if (intervals[maxStartHeap.Dequeue()].Start >= intervals[topEnd].End)
                {
                    int topStart = maxStartHeap.Dequeue();
                    // find the the interval that has the closest 'start'
                    while (!maxStartHeap.IsEmpty() && intervals[maxStartHeap.Peek()].Start >= intervals[topEnd].End)
                    {
                        topStart = maxStartHeap.Dequeue();
                    }
                    result[topEnd] = topStart;
                    maxStartHeap.Enqueue(topStart, intervals[topStart].Start); // put the interval back as it could be the next interval of other intervals
                }
            }
            return result;
        }
    }
}