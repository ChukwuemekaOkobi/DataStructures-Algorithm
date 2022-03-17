using System;
using System.Collections.Generic;

namespace Patterns._4_MergeIntervals
{
    /// <summary>
    /// We are given a list of Jobs. Each job has a Start time, an End time, and a CPU load 
    /// when it is running. Our goal is to find the maximum CPU load at any time
    /// if all the jobs are running on the same machine.

    //Example 1:

    //Jobs: [[1,4,3], [2,5,4], [7,9,6]]
    //Output: 7
    //Explanation: Since[1, 4, 3] and[2, 5, 4] overlap, their maximum CPU load(3+4=7) will be when both the
    // jobs are running at the same time i.e., during the time interval(2,4).
    //Example 2:

    //Jobs: [[6,7,10], [2,4,11], [8,12,15]]
    //Output: 15
    //Explanation: None of the jobs overlap, therefore we will take the maximum load of any job which is 15.
    //Example 3:

    //Jobs: [[1,4,2], [2,4,1], [3,6,5]]
    //Output: 8
    //Explanation: Maximum CPU load will be 8 as all jobs overlap during the time interval[3, 4]. 
    /// </summary>

    public class MaxCPULoad
    {
        public static int MaxLoad(List<Job> jobs)
        {
            if (jobs == null || jobs.Count == 0)
                return 0;

            // sort the meetings by start time
            jobs.Sort();

            int MaxLoad = 0;
            int current = 0; 

            PriorityQueue<Job, int> minHeap = new PriorityQueue<Job, int>();

            foreach (Job job in jobs)
            {
                // remove all meetings that have ended
                while (minHeap.Count != 0 && job.Start >= minHeap.Peek().End)
                    current-=minHeap.Dequeue().Load;
                // add the current meeting into the minHeap
                minHeap.Enqueue(job, job.End);
                current += job.Load;
                // all active meeting are in the minHeap, so we need rooms for all of them.
                MaxLoad = Math.Max(current, MaxLoad);
            }
            return MaxLoad;
        }
    
           
        public class Job: Interval
        {
            public int Load { get; set; }
            public Job (int start, int end, int load) : base(start, end)
            {
                Load = load; 
            }
        }
    }

}
