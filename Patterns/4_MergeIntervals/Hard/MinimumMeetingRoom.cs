using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._4_MergeIntervals
{
    /// <summary>
    /// Minimum Meeting Rooms (hard)#
    //Given a list of intervals representing the start and end time of ‘N’ meetings, find the minimum number of rooms required to hold all the meetings.
    //Example 1:

    //Meetings: [[1,4], [2,5], [7,9]]
    //Output: 2
    //Explanation: Since[1, 4] and[2, 5] overlap, we need two rooms to hold these two meetings. [7, 9] can
    //occur in any of the two rooms later.
    //Example 2:

    //Meetings: [[6,7], [2,4], [8,12]]
    //Output: 1
    //Explanation: None of the meetings overlap, therefore we only need one room to hold all meetings.
    //Example 3:

    //Meetings: [[1,4], [2,3], [3,6]]
    //Output:2
    //Explanation: Since[1, 4] overlaps with the other two meetings[2, 3] and[3, 6], we need two rooms to
    //hold all the meetings.

    //Example 4:

    //Meetings: [[4,5], [2,3], [2,4], [3,5]]
    //Output: 2
    //Explanation: We will need one room for [2,3] and[3, 5], and another room for [2,4] and[4, 5].

    //Here is a visual representation of Example 4:
    /// </summary>
    public class MinimumMeetingRoom
    {
        public static int FindMinimumMeetingRooms(List<Interval> meetings)
        {
            if (meetings == null || meetings.Count == 0)
                return 0;

            // sort the meetings by start time
            meetings.Sort();

            int minRooms = 0;

            PriorityQueue<Interval,int> minHeap = new PriorityQueue<Interval,int>();
               
            foreach (Interval meeting in meetings)
            {
                // remove all meetings that have ended
                while (minHeap.Count!=0 && meeting.Start >= minHeap.Peek().End)
                    minHeap.Dequeue();
                // add the current meeting into the minHeap
                minHeap.Enqueue(meeting, meeting.End);
                // all active meeting are in the minHeap, so we need rooms for all of them.
                minRooms = Math.Max(minRooms, minHeap.Count);
            }
            return minRooms;
        }

        /// <summary>
        /// Given a list of intervals, find the point where the maximum number of intervals overlap.
        /// </summary>

        public static int PointOfMaxOverLap(List<Interval> list)
        {

            return 0; 
        }

        ///<summary>
        ///Problem 2: Given a list of intervals representing the arrival and departure 
        ///times of trains to a train station, our goal is to find the minimum number 
        ///of platforms required for the train station so that no train has to wait.
        ///</summary>
        
        public static int MinPlatform(List<Interval> list)
        {
            return FindMinimumMeetingRooms(list);
        }
    }

    /// <summary>
    /// For ‘K’ employees, we are given a list of intervals representing the working hours of each employee.
    /// Our goal is to find out if there is a free interval that is common to all employees. 
    /// You can assume that each list of employee working hours is sorted on the start time.
    /// 
    /// Example 1:
    //    Input: Employee Working Hours=[[[1,3], [5,6]], [[2,3], [6,8]]]
    //Output: [3,5]
    //    Explanation: Both the employees are free between[3, 5].
    //Example 2:

    //Input: Employee Working Hours=[[[1,3], [9,12]], [[2,4]], [[6,8]]]
    //Output: [4,6], [8,9]
    //    Explanation: All employees are free between[4, 6] and[8, 9].
    //Example 3:

    //Input: Employee Working Hours=[[[1,3]], [[2,4]], [[3,5], [7,9]]]
    //Output: [5,7]
    //    Explanation: All employees are free between[5, 7].
    /// </summary>

    public class EmployeeFreeTime
    {
        public static List<Interval> FindEmployeeFreeTime(List<List<Interval>> schedule)
        {
            List<Interval> result = new ();
            // TODO: Write your code here
            return result;
        }
    }
}
