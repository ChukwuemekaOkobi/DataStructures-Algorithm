using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._4_MergeIntervals
{
    /// <summary>
    /// Given a list of intervals, merge all the overlapping intervals to produce a list that has only mutually exclusive intervals.

    //Example 1:

    //Intervals: [[1,4], [2,5], [7,9]]
    //Output: [[1,5], [7,9]]
    //Explanation: Since the first two intervals[1, 4] and[2, 5] overlap, we merged them into
    //one[1, 5].

    //Example 2:

    //Intervals: [[6,7], [2,4], [5,9]]
    //Output: [[2,4], [5,9]]
    //Explanation: Since the intervals[6, 7] and[5, 9] overlap, we merged them into one[5, 9].

    //Example 3:

    //Intervals: [[1,4], [2,6], [3,5]]
    //Output: [[1,6]]
    //Explanation: Since all the given intervals overlap, we merged them into one
    /// </summary>
    public class MergeIntervals
    {
        //merge
        public static List<Interval> Merge(List<Interval> intervals)
        {
            if (intervals.Count < 2)
            {
                return intervals;
            }
            List<Interval> mergedIntervals = new List<Interval>();

            intervals.Sort();

            int End = intervals[0].End;
            int Start = intervals[0].Start;

            for (int i = 1; i < intervals.Count; i++)
            {
                var interval = intervals[i];
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

            mergedIntervals.Add(new Interval(Start, End));

            return mergedIntervals;
        }

        //find OverLap
        public static bool HasOverLap(List<Interval> intervals)
        {
            if (intervals.Count < 2)
            {
                return false;
            }

            intervals.Sort();

            int End = intervals[0].End;


            for (int i = 1; i < intervals.Count; i++)
            {
                var interval = intervals[i];

                if (interval.Start <= End)
                {
                    return true;
                }
                else
                {
                    End = interval.End;
                }

            }

            return false;
        }
    }
    public class Interval : IComparable<Interval>
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }
        public int CompareTo(Interval y)
        {
            return Start - y.Start;
        }

        public override string ToString()
        {
            return $"[{Start}-{End}]";
        }
    }

    class SortCompare : IComparer<Interval>
    {
        public int Compare(Interval x, Interval y)
        {
            return x.Start - y.Start;
        }

    }
}
