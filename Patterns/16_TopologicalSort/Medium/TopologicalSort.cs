using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patterns._16_TopologicalSort
{
    /// <summary>
    /// Topological Sort of a directed graph (a graph with unidirectional edges) is a linear ordering of its vertices 
    /// such that for every directed edge (U, V) from vertex U to vertex V, U comes before V in the ordering.
    //  Given a directed graph, find the topological ordering of its vertices.
    //  Example 1:
    //  Input: Vertices= 4, Edges=[3, 2], [3, 0], [2, 0], [2, 1]
    //  Output: Following are the two valid topological sorts for the given graph:
    //  1) 3, 2, 0, 1
    //  2) 3, 2, 1, 0

    /// Example 2:

    // Input: Vertices=5, Edges=[4, 2], [4, 3], [2, 0], [2, 1], [3, 1]
    // Output: Following are all valid topological sorts for the given graph:
    //1) 4, 2, 3, 0, 1
    //2) 4, 3, 2, 0, 1
    //3) 4, 3, 2, 1, 0
    //4) 4, 2, 3, 1, 0
    //5) 4, 2, 0, 3, 1
    /// </summary>
    public class TopologicalSort
    {
        public static List<int> Sort(int vertices, int[][] edges)
        {
            List<int> sorted = new List<int>();

            if(vertices <= 0)
            {
                return sorted; 
            }

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            Dictionary<int, int> inNodes = new Dictionary<int, int>(); 

             //initalize graph
            for(int i = 0; i< vertices; i++)
            {
                graph.Add(i, new List<int>());
                inNodes.Add(i, 0); 
            }

            //build graph 
            for(int i = 0; i< edges.Length; i++)
            {
                int parent = edges[i][0], child = edges[i][1];
                graph[parent].Add(child);

                inNodes[child]++;
            }

            //sort
            Queue<int> sources = new Queue<int>(); 

            //get the source as starting point
            foreach(var n in inNodes)
            {
                if(n.Value == 0)
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

            if(sorted.Count != vertices)
            {
                return new List<int>(); 
            }

            return sorted; 

        }
   
    
        public static List<int> SortOrder(int vertices, int[][] edges)
        {
            List<int> sorted = new List<int>();

            if (vertices <= 0)
            {
                return sorted;
            }

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            //build graph
            for(int i = 0; i< edges.Length; i++)
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

            Stack<int> stack  = new Stack<int>(); 

            foreach(var node in graph.Keys)
            {
                SortRecursive(node, graph, visited, stack); 
            }

            while(stack.Count != 0)
            {
                sorted.Add(stack.Pop()); 
            }

            return sorted; 
        }


        private static void SortRecursive(int node, Dictionary<int,List<int>> graph, HashSet<int> visited, Stack<int> sort)
        {
            if (visited.Contains(node))
            {
                return; 
            }

            visited.Add(node); 

            foreach(var n in graph[node])
            {
                SortRecursive(n, graph, visited, sort); 
            }

            sort.Push(node); 
        }

    }
}
