using System;
using System.Collections.Generic;

namespace Patterns._16_TopologicalSort
{
    /// <summary>
    /// There are ‘N’ tasks, labeled from ‘0’ to ‘N-1’. Each task can have some prerequisite tasks which need to be completed before it can be scheduled. Given the number of tasks and a list of prerequisite pairs, write a method to find the ordering of tasks we should pick to finish all tasks.

    //    Example 1:

    //Input: Tasks=3, Prerequisites=[0, 1], [1, 2]
    //    Output: [0, 1, 2]
    //    Explanation: To execute task '1', task '0' needs to finish first.Similarly, task '1' needs
    //    to finish before '2' can be scheduled.A possible scheduling of tasks is: [0, 1, 2]
    //Example 2:


    //    Input: Tasks= 3, Prerequisites=[0, 1], [1, 2], [2, 0]
    //Output: []
    //Explanation: The tasks have a cyclic dependency, therefore they cannot be scheduled.
    //    Example 3:


    //    Input: Tasks= 6, Prerequisites=[2, 5], [0, 5], [0, 4], [1, 4], [3, 2], [1, 3]
    //Output: [0 1 4 3 2 5]
    //Explanation: A possible scheduling of tasks is: [0 1 4 3 2 5]
    /// </summary>
    public class AllTaskSchedulingOrder
    {
        public static List<List<int>>  AllSchedulingOrder(int tasks, int[] [] edges)
        {
        
            // TODO: Write your code here
            List<int> sorted = new List<int>();

       

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            Dictionary<int, int> inNodes = new Dictionary<int, int>();

            //build graph
            for (int i = 0; i < edges.Length; i++)
            {
                int parent = edges[i][0];
                int child = edges[i][1];

                if (!graph.ContainsKey(parent))
                {
                    graph.Add(parent, new List<int>());
                    inNodes.Add(parent, 0);
                }

                if (!graph.ContainsKey(child))
                {
                    graph.Add(child, new List<int>());
                    inNodes.Add(child, 0);
                }

                graph[parent].Add(child);
                inNodes[child]++;

            }

            //sort
            Queue<int> sources = new Queue<int>();

            //get the source as starting point
            foreach (var n in inNodes)
            {
                if (n.Value == 0)
                {
                    sources.Enqueue(n.Key);
                }
            }

            PrintAllTopologicalSorts(graph, inNodes, sources, sorted);

    


            return new(); 
        }

        private static void PrintAllTopologicalSorts(Dictionary<int, List<int>> graph, Dictionary<int, int> inDegree, Queue<int> sources, List<int> sortedOrder)
        {
            if (sources.Count != 0)
            {
                foreach (int vertex in sources)
                {
                    sortedOrder.Add(vertex);
                    Queue<int> sourcesForNextCall = CloneQueue(sources);
                    // only remove the current source, all other sources should remain in the queue for the next call
                    sourcesForNextCall.Remove(vertex);
                    List<int> children = graph[vertex]; // get the node's children to decrement their in-degrees
                    foreach (int child in children)
                    {
                        inDegree[child]--;
                        if (inDegree[child] == 0)
                            sourcesForNextCall.Enqueue(child); // save the new source for the next call
                    }

                    // recursive call to print other orderings from the remaining (and new) sources
                    PrintAllTopologicalSorts(graph, inDegree, sourcesForNextCall, sortedOrder);

                    // backtrack, remove the vertex from the sorted order and put all of its children back to consider 
                    // the next source instead of the current vertex
                    sortedOrder.Remove(vertex);
                    foreach (int child in children)
                        inDegree[child]++;
                }
            }

            // if sortedOrder doesn't contain all tasks, either we've a cyclic dependency between tasks, or 
            // we have not processed all the tasks in this recursive call
            if (sortedOrder.Count == inDegree.Count)
            {
                foreach(var n in sortedOrder)
                {
                    Console.Write(n + " ");
                }

                Console.WriteLine(); 
            }
               
        }

        // makes a deep copy of the queue
        private static Queue<int> CloneQueue(Queue<int> queue)
        {
            Queue<int> clone = new ();
            foreach (int num in queue)
                clone.Enqueue(num);
            return clone;
        }
    }
}
