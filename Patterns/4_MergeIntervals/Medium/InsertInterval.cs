using System;
using System.Collections.Generic;

namespace Patterns._4_MergeIntervals
{
    /// <summary>
    /// Given a list of non-overlapping intervals sorted by their Start time, 
    /// insert a given interval at the correct position and merge all necessary 
    /// intervals to produce a list that has only mutually exclusive intervals.

    //Example 1:

    //Input: Intervals=[[1,3], [5,7], [8,12]], New Interval =[4, 6]
    //Output: [[1,3], [4,7], [8,12]]
    //Explanation: After insertion, since[4, 6] overlaps with[5, 7], we merged them into one[4, 7].
    //Example 2:

    //Input: Intervals=[[1,3], [5,7], [8,12]], New Interval =[4, 10]
    //Output: [[1,3], [4,12]]
    //Explanation: After insertion, since[4, 10] overlaps with[5, 7] & [8,12], we merged them into[4, 12].
    //Example 3:

    //Input: Intervals=[[2,3],[5,7]], New Interval =[1, 4]
    //Output: [[1,4], [5,7]]
    //Explanation: After insertion, since[1, 4] overlaps with[2, 3], we merged them into one[1, 4].

    /// </summary>

    public class InsertInterval
    {
        public static List<Interval> Insert(List<Interval> intervals, Interval newInterval)
        {
            List<Interval> mergedIntervals = new();

            bool inserted = false;
            int End = 0;
            int Start = 0;

            for (int i = 0; i < intervals.Count; i++)
            {
                var interval = intervals[i];
                if (!inserted)
                {
                    //insert
                    if (newInterval.Start <= interval.Start)
                    {
                        intervals.Insert(i, newInterval);
                        inserted = true;

                        if (i != 0 && newInterval.Start < intervals[i - 1].End)
                        {
                            // there is an over lap 
                            Start = intervals[i - 1].Start;
                            End = intervals[i - 1].End;
                        }
                        else
                        {   //set the Start to newInterval
                            Start = newInterval.Start;
                            End = newInterval.End;
                        }

                    }
                    else
                    {
                        mergedIntervals.Add(new Interval(interval.Start, interval.End));
                    }
                }

                else
                {
                    if (interval.Start <= End)
                    {
                        End = Math.Max(interval.End, End);
                        // overlapping Intervals add the End;
                    }
                    else
                    {
                        //non over lapping intervals 
                        //add current interval
                        mergedIntervals.Add(new Interval(Start, End));
                        Start = interval.Start;
                        End = interval.End;
                    }


                }
            }

            mergedIntervals.Add(new Interval(Start, End));

            return mergedIntervals;
        }

        public static List<Interval> insert(List<Interval> intervals, Interval newInterval)
        {
            List<Interval> mergedIntervals = new();

            if (intervals == null || intervals.Count == 0)
            {
                mergedIntervals.Add(newInterval);
                return mergedIntervals;
            }




            int i = 0;
            // skip (and add to output) all intervals that come before the 'newInterval'
            while (i < intervals.Count && intervals[i].End < newInterval.Start)
                mergedIntervals.Add(intervals[i++]);

            // merge all intervals that overlap with 'newInterval'
            while (i < intervals.Count && intervals[i].Start <= newInterval.End)
            {
                newInterval.Start = Math.Min(intervals[i].Start, newInterval.Start);
                newInterval.End = Math.Max(intervals[i].End, newInterval.End);
                i++;
            }

            // insert the newInterval
            mergedIntervals.Add(newInterval);

            // add all the remaining intervals to the output
            while (i < intervals.Count)
                mergedIntervals.Add(intervals[i++]);

            return mergedIntervals;
        }
    }
}
