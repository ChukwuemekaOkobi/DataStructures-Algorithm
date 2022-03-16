using System;
using System.Collections.Generic;

namespace Patterns._4_MergeIntervals
{
    /// <summary>
    /// Given two lists of intervals, find the intersection of these two lists. Each list consists of disjoint intervals sorted on their Start time.

    //Example 1:

    //Input: arr1=[[1, 3], [5, 6], [7, 9]], arr2=[[2, 3], [5, 7]]
    //Output: [2, 3], [5, 6], [7, 7]
    //Explanation: The output list contains the common intervals between the two lists.
    //Example 2:

    //Input: arr1=[[1, 3], [5, 7], [9, 12]], arr2=[[5, 10]]
    //Output: [5, 7], [9, 10]
    //Explanation: The output list contains the common intervals between the two lists.
    /// </summary>
    public class IntervalsIntersection
    {

        public static Interval[] Merge(Interval[] arr1, Interval[] arr2)
        {
            List<Interval> result = new List<Interval>();
            int i = 0, j = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                // check if the interval arr[i] intersects with arr2[j]
                // check if one of the interval's Start time lies within the other interval
                if ((arr1[i].Start >= arr2[j].Start && arr1[i].Start <= arr2[j].End)
                    || (arr2[j].Start >= arr1[i].Start && arr2[j].Start <= arr1[i].End))
                {
                    // store the intersection part
                    int end = Math.Min(arr1[i].End, arr2[j].End);
                    int start = Math.Max(arr1[i].Start, arr2[j].Start);

                    result.Add(new Interval(start, end));
                }

                // move next from the interval which is finishing first
                if (arr1[i].End < arr2[j].End)
                    i++;
                else
                    j++;
            }

            return result.ToArray();
        }

    }
}
