using System.Collections.Generic;

namespace Patterns._16_TopologicalSort
{
    /// <summary>
    /// There are ‘N’ tasks, labeled from ‘0’ to ‘N-1’. Each task can have some prerequisite tasks which need to be completed before it can be scheduled. Given the number of tasks and a list of prerequisite pairs, find out if it is possible to schedule all the tasks.

    //    Example 1:

    //Input: Tasks=3, Prerequisites=[0, 1], [1, 2]
    //    Output: true
    //Explanation: To execute task '1', task '0' needs to finish first.Similarly, task '1' needs
    //to finish before '2' can be scheduled.One possible scheduling of tasks is: [0, 1, 2]
    //Example 2:

    //Input: Tasks= 3, Prerequisites=[0, 1], [1, 2], [2, 0]
    //Output: false
    //Explanation: The tasks have a cyclic dependency, therefore they cannot be scheduled.
    //Example 3:

    //Input: Tasks= 6, Prerequisites=[2, 5], [0, 5], [0, 4], [1, 4], [3, 2], [1, 3]
    //Output: true
    //Explanation: A possible scheduling of tasks is: [0 1 4 3 2 5]
    /// </summary>
    public class TaskScheduling
    {
        public static bool IsSchedulingPossible(int tasks, int[][] edges)
        {
            // TODO: Write your code here
            List<int> sorted = new List<int>();

            if (tasks <= 0)
            {
                return false;
            }

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

            while (sources.Count != 0)
            {
                int vertex = sources.Dequeue();
                sorted.Add(vertex);

                List<int> children = graph[vertex]; // get the node's children to decrement their in-degrees
                foreach (int child in children)
                {
                    inNodes[child]--;

                    if (inNodes[child] == 0)
                        sources.Enqueue(child);
                }
            }

            return sorted.Count==tasks;
        }
  
    
        public static bool IsSchedulingPossibleOrder(int task, int[][] edges)
        {

            if (task <= 0)
            {
                return false;
            }

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            //build graph
            for (int i = 0; i < edges.Length; i++)
            {
                int parent = edges[i][0];
                int child = edges[i][1];

                if (!graph.ContainsKey(parent))
                {
                    graph.Add(parent, new List<int>());
                }

                if (!graph.ContainsKey(child))
                {
                    graph.Add(child, new List<int>());
                }

                graph[parent].Add(child);

            }

            HashSet<int> visited = new HashSet<int>();

            HashSet<int> visiting = new HashSet<int>();

            Stack<int> stack = new Stack<int>();

            foreach (var node in graph.Keys)
            {
                SortRecursive(node, graph, visited, visiting, stack);
            }


            return visiting.Count == 0;

        }


        private static void SortRecursive(int node, Dictionary<int, List<int>> graph, HashSet<int> visited, HashSet<int> visiting, Stack<int> sort)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visiting.Add(node);
            visited.Add(node);

            foreach (var n in graph[node])
            {
                if (visiting.Contains(n))
                {
                    return;
                }
                SortRecursive(n, graph, visited, visiting, sort);
            }

            visiting.Remove(node);

            sort.Push(node);
        }


        public static List<int> SchedulingOrder(int tasks,int[][] edges)
        {
            List<int> sorted = new List<int>();

            if (tasks <= 0)
            {
                return sorted;
            }

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

            while (sources.Count != 0)
            {
                int vertex = sources.Dequeue();
                sorted.Add(vertex);

                List<int> children = graph[vertex]; // get the node's children to decrement their in-degrees
                foreach (int child in children)
                {
                    inNodes[child]--;

                    if (inNodes[child] == 0)
                        sources.Enqueue(child);
                }
            }

            return sorted.Count == tasks ? sorted : new List<int>();
        }
    }
}
