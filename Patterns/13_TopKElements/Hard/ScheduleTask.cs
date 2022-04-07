using System.Collections.Generic;

namespace Patterns._13_TopKElements
{
    /// <summary>
    /// You are given a list of tasks that need to be run, in any order, on a server. 
    /// Each task will take one CPU interval to execute but once a task has finished, 
    /// it has a cooling period during which it can’t be run again. If the cooling period for all tasks is ‘K’ intervals, 
    /// find the minimum number of CPU intervals that the server needs to finish all tasks.

    //If at any time the server can’t execute any task then it must stay idle.

    //Example 1:

    //Input: [a, a, a, b, c, c], K=2
    //Output: 7
    //Explanation: a -> c -> b -> a -> c -> idle -> a
    //Example 2:

    //Input: [a, b, a], K=3
    //Output: 5
    //Explanation: a -> b -> idle -> idle -> a
    /// </summary>
    public class ScheduleTask
    {
        public static int ScheduleTasks(char[] tasks, int k)
        {
            Dictionary<char, int> dict = new(); 

            foreach(var ch in tasks)
            {
                if (!dict.TryAdd(ch, 1))
                {
                    dict[ch]++;
                }
            }

            PriorityQueue<Pair, int> maxHeap = new PriorityQueue<Pair, int>(new MyComparer());

            

            foreach(var item in dict)
            {
                maxHeap.Enqueue(new Pair(item.Key, item.Value), item.Value);
            }

            int cpuCycles = 0;

           

            while (!maxHeap.IsEmpty())
            {
                Queue<Pair> queue = new();
                int n = k + 1; // try to execute as many as 'k+1' tasks from the max-heap
                for (; n > 0 && !maxHeap.IsEmpty(); n--)
                {
                    var currentEntry = maxHeap.Dequeue();
                    cpuCycles++;
                    
                    if (currentEntry.Value > 1)
                    {
                        currentEntry.Value--;
                        queue.Enqueue(currentEntry);
                    }
                }
                // put all the waiting list back on the heap
                while (queue.Count != 0)
                {
                    var e = queue.Dequeue();
                    maxHeap.Enqueue(e, e.Value);
                }
            
                if (!maxHeap.IsEmpty())
                    cpuCycles += n; // we'll be having 'n' idle intervals for the next iteration

            }



            return cpuCycles;
        }

    }
}
