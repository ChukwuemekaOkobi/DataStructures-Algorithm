using System;
using System.Collections.Generic;

namespace Patterns._16_TopologicalSort
{
    /// <summary>
    /// Given a sequence originalSeq and an array of sequences, write a method to find if originalSeq can be uniquely reconstructed from the array of sequences.

    //    Unique reconstruction means that we need to find if originalSeq is the only sequence such that all sequences in the array are subsequences of it.

    //    Example 1:

    //Input: originalSeq: [1, 2, 3, 4], seqs: [[1, 2], [2, 3], [3, 4]]
    //Output: true
    //Explanation: The sequences[1, 2], [2, 3], and[3, 4] can uniquely reconstruct
    //[1, 2, 3, 4], in other words, all the given sequences uniquely define the order of numbers 
    //in the 'originalSeq'. 
    //Example 2:

    //Input: originalSeq: [1, 2, 3, 4], seqs: [[1, 2], [2, 3], [2, 4]]
    //Output: false
    //Explanation: The sequences[1, 2], [2, 3], and[2, 4] cannot uniquely reconstruct
    //[1, 2, 3, 4]. There are two possible sequences we can construct from the given sequences:
    //1) [1, 2, 3, 4]
    //2) [1, 2, 4, 3]
    //    Example 3:

    //Input: originalSeq: [3, 1, 4, 2, 5], seqs: [[3, 1, 5], [1, 4, 2, 5]]
    //Output: true
    //Explanation: The sequences[3, 1, 5] and[1, 4, 2, 5] can uniquely reconstruct
    //[3, 1, 4, 2, 5].
    /// </summary>
    public class RecreateSequence
    {
        public static bool CanConstruct(int[] originalSeq, int[][] sequences)
        {
            List<int> sortedOrder = new ();
            if (originalSeq.Length <= 0)
                return false;

            Dictionary<int, int> inDegree= new Dictionary<int, int>();

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            //initailize the graph
            foreach (int[] seq in sequences)
            {
                for (int i = 0; i < seq.Length; i++)
                {
                    inDegree.TryAdd(seq[i], 0);
                    graph.TryAdd(seq[i], new ());
                }
            }

            //build graph 

            foreach(int[] seq in sequences)
            {
                for(int i = 1; i<seq.Length; i++)
                {
                    int parent = seq[i - 1];
                    int child = seq[i];
                    graph[parent].Add(child);
                    inDegree[child]++; 

                }
            }

            if(inDegree.Count != originalSeq.Length)
            {
                return false;
            }

            // c. Find all sources i.e., all vertices with 0 in-degrees
            Queue<int> sources = new ();
            foreach (var entry in inDegree)
            {
                if (entry.Value == 0)
                    sources.Enqueue(entry.Key);
            }

            // d. For each source, add it to the sortedOrder and subtract one from all of its children's in-degrees
            // if a child's in-degree becomes zero, add it to the sources queue
            while (!sources.IsEmpty())
            {
                if (sources.Count > 1)
                    return false; // more than one sources mean, there is more than one way to reconstruct the sequence
                if (originalSeq[sortedOrder.Count] != sources.Peek())
                    return false; // the next source (or number) is different from the original sequence

                int vertex = sources.Dequeue();
                sortedOrder.Add(vertex);
                List<int> children = graph[vertex]; // get the node's children to decrement their in-degrees
                foreach (int child in children)
                {
                    inDegree[child]--;
                    if (inDegree[child] == 0)
                        sources.Enqueue(child);
                }
            }

            // if sortedOrder's size is not equal to original sequence's size, there is no unique way to construct  
            return sortedOrder.Count == originalSeq.Length;
        }
    }

    public class MinimumHeightTree
    {
        //O(E) + O(N * H)
        public static List<int> MinHeight(int[][] edges)
        {
            if(edges.Length == 0)
            {
                return new();
            }

            Dictionary<int, List<int>> graph = new(); 

            //O(E)
            foreach(int[] item in edges)
            {
                int first = item[0];
                int second = item[1];

                graph.TryAdd(first, new());
                graph.TryAdd(second, new());


                graph[first].Add(second);
                graph[second].Add(first); 

            }


            int minheight = int.MaxValue;

            Dictionary<int, int> minheightRoot = new();

            //O(N)
            foreach(var node in graph.Keys)
            {
                HashSet<int> visited = new();

                //O(H)
                int height = CalHeight(node, graph, visited);

                minheight = Math.Min(height, minheight);

                minheightRoot.Add(node, height); 
            }

            List<int> result = new(); 

            //O(N)
            foreach(var item in minheightRoot)
            {
                if(item.Value == minheight)
                {
                    result.Add(item.Key); 
                }

            }

            return result; 
        }

        private static int CalHeight(int node, Dictionary<int, List<int>> graph, HashSet<int> visited)
        {
            int height = 0; 
            
            if (visited.Contains(node))
            {
                return 0;
            }


            visited.Add(node); 

            List<int> children = graph[node];


            foreach(var child in children)
            {
               height = Math.Max(height, CalHeight(child, graph, visited)); 
            }

            return height + 1; 
        }

        public static List<int> findTrees(int nodes, int[][] edges)
        {
            List<int> minHeightTrees = new ();
            if (nodes <= 0)
                return minHeightTrees;

            // with only one node, since its in-degree will be 0, therefore, we need to handle it separately
            if (nodes == 1)
            {
                minHeightTrees.Add(0);
                return minHeightTrees;
            }

            // a. Initialize the graph
            Dictionary<int, int> inDegree = new (); // count of incoming edges for every vertex
            Dictionary<int, List<int>> graph = new(); // adjacency list graph
            for (int i = 0; i < nodes; i++)
            {
                inDegree.Add(i, 0);
                graph.Add(i, new ());
            }

            // b. Build the graph
            for (int i = 0; i < edges.Length; i++)
            {
                int n1 = edges[i][0], n2 = edges[i][1];
                // since this is an undirected graph, therefore, add a link for both the nodes
                graph[n1].Add(n2);
                graph[n2].Add(n1);
                // increment the in-degrees of both the nodes
                inDegree[n1]++;
                inDegree[n2]++; 
            }

            // c. Find all leaves i.e., all nodes with only 1 in-degree
            Queue<int> leaves = new ();
            foreach (KeyValuePair<int,int> entry in inDegree)
            {
                if (entry.Value == 1)
                    leaves.Enqueue(entry.Key);
            }

            // d. Remove leaves level by level and subtract each leave's children's in-degrees.
            // Repeat this until we are left with 1 or 2 nodes, which will be our answer.
            // Any node that has already been a leaf cannot be the root of a minimum height tree, because 
            // its adjacent non-leaf node will always be a better candidate.
            int totalNodes = nodes;
            while (totalNodes > 2)
            {
                int leavesSize = leaves.Count;
                totalNodes -= leavesSize;
                for (int i = 0; i < leavesSize; i++)
                {
                    int vertex = leaves.Dequeue();
                    List<int> children = graph[vertex];
                    foreach (int child in children)
                    {
                        inDegree[child]--;
                        if (inDegree[child] == 1) // if the child has become a leaf
                            leaves.Enqueue(child);
                    }
                }
            }

            minHeightTrees.AddRange(leaves);
            return minHeightTrees;
        }
    }
}
