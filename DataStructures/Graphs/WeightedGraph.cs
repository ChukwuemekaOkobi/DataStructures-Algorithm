using DataStructures.Queues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    /// <summary>
    /// This is a undirected Weighted Graph
    /// With Adjacency List  added to the Node Object
    /// </summary>
    public class WeightedGraph
    {
        private readonly Dictionary<string, Node> Nodes;
       
        
        public WeightedGraph()
        {
            Nodes = new Dictionary<string, Node>();
          
        }

        public void AddNode(string label)
        {
            if (!Nodes.ContainsKey(label))
            {

                Nodes.Add(label, new Node(label));

            }
        }

        public void AddEdge( string from, string to, int weight)
        {
            if (!Nodes.TryGetValue(from, out Node fromNode))
            {
                return;
            }

            if (!Nodes.TryGetValue(to, out Node toNode))
            {
                return;
            }

            //Add to the Adjacency list
            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);

        }


        /// <summary>
        /// Using Distra shortest path algorithm
        /// </summary>
        /// <returns></returns>
        public int ShortestDistance(string from, string to)
        {
            if(!Nodes.TryGetValue(from, out Node fromNode))
            {
                return  0; 
            }

            if(!Nodes.TryGetValue(to, out Node toNode))
            {
                return 0; 
            }

            if (fromNode.GetEdges().Count == 0)
            {
                return 0;
            }

            var queue = new PriorityQueue<Node, int>();

            var distances = new Dictionary<Node, int>();
           
            var visited = new HashSet<Node>();

            foreach (var node in Nodes.Values)
            {
                distances.Add(node, int.MaxValue); 
            }

            distances[fromNode] = 0;
         
            queue.Enqueue(fromNode, 0);

            //Breath First Traversal
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                visited.Add(current); 

                foreach(var edge in current.GetEdges())
                {
                    if (!visited.Contains(edge.To))
                    {
                        var newDistance = distances[current] + edge.Weight; 
                        if(newDistance < distances[edge.To])
                        {
                            distances[edge.To] = newDistance;
                            queue.Enqueue(edge.To, newDistance); 
                        }
                      
                    }

                }
            }

            return distances[toNode]; 
        }

        public Path ShortestPath(string from , string to)
        {
            if (!Nodes.TryGetValue(from, out Node fromNode))
            {
                return null;
            }

            if (!Nodes.TryGetValue(to, out Node toNode))
            {
                return null;
            }

            
            if(fromNode.GetEdges().Count == 0)
            {
                return null; 
            }

            var queue = new PriorityQueue<Node, int>();

            var distances = new Dictionary<Node, int>();

            var previousNodes = new Dictionary<Node, Node>();

            var visited = new HashSet<Node>();

            foreach (var node in Nodes.Values)
            {
                distances.Add(node, int.MaxValue);
            }

            distances[fromNode] = 0;

            queue.Enqueue(fromNode, 0);

            //Breath First Traversal
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                visited.Add(current);

                foreach (var edge in current.GetEdges())
                {
                    if (!visited.Contains(edge.To))
                    {
                        var newDistance = distances[current] + edge.Weight;
                        if (newDistance < distances[edge.To])
                        {
                            distances[edge.To] = newDistance;

                            previousNodes[edge.To] = current;
                            
                            queue.Enqueue(edge.To, newDistance);
                        }

                    }

                }
            }

            var previous = previousNodes[toNode];
            var path = new Path();

            path.Add(toNode.Label);

            while (previous != null)
            {
                path.Add(previous.Label);
                previous = previousNodes.ContainsKey(previous) ? previousNodes[previous] : null;
            }

            path.Reverse();
            return path;
        }
        
        public bool HasCycle()
        {
            var visited = new HashSet<Node>(); 

            foreach(var node in Nodes.Values)
            {
                if(!visited.Contains(node) && HasCycle(node, null, visited))
                {
                    return true; 
                }
            }

            return false;
        }

        private bool HasCycle(Node node, Node parent, ISet<Node> visited)
        {
            visited.Add(node); 
            foreach(var edge in node.GetEdges())
            {
                if(edge.To == parent)
                {
                    continue;
                }
                if (visited.Contains(edge.To) || HasCycle(edge.To, node, visited))
                {
                    return true;
                }
            }

            return false;
        }
        
        public WeightedGraph MinimumSpaningTree()
        {
            var tree = new WeightedGraph();

            var queue = new PriorityQueue<Edge, int>();

            var firstNode = Nodes.Values.First();

            foreach(var edge in firstNode.GetEdges())
            {
                queue.Enqueue(edge, edge.Weight); 
            }

            tree.AddNode(firstNode.Label);

           

            while(tree.Nodes.Count < Nodes.Count && queue.Count != 0)
            {
                var minEdge = queue.Dequeue();
                var nextNode = minEdge.To; 

                if (tree.ContainsNode(nextNode.Label))
                {
                    continue; 
                }
                 
                tree.AddNode(nextNode.Label);
                tree.AddEdge(minEdge.From.Label, nextNode.Label, minEdge.Weight);

                foreach (var edge in nextNode.GetEdges())
                {
                    if (!tree.ContainsNode(edge.To.Label))
                    {
                        queue.Enqueue(edge, edge.Weight); 
                    }

                }
            }

            return tree;
        }

        public bool ContainsNode(string label)
        {
            return Nodes.ContainsKey(label); 
        }

        public void PrintNodes()
        {
            Console.WriteLine("[" + string.Join(",", Nodes.Keys) + "]");
        }
 
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var node in Nodes.Values)
            {
                builder.Append(node + " is connected to [" + string.Join(",", node.GetEdges()) + "]\n");
            }
            return builder.ToString();
        }
        
        private class Node
        {
            public string Label { get; private set; }

            private readonly HashSet<Edge> Edges; 
            public Node(string label)
            {
                Label = label;

                Edges = new HashSet<Edge>(); 
            }



            public void AddEdge(Node to, int weight)
            {
                Edges.Add(new Edge(this, to, weight));
            }

            public ICollection<Edge> GetEdges()
            {
                return Edges; 
            }
          

            public override string ToString()
            {
                return $"{Label}";
            }
            
        }
        private class Edge
        {
            public Node To { get; private set; }
            public Node From { get; private set; }

            public int Weight { get; private set; }

            public Edge (Node from, Node to,int  weight)
            {
                To = to;
                From = from;
            
                Weight = weight; 
            }

            public override string ToString()
            {
                return From + " -> " + To; 
            }
        }


    }

    public class Path
    {
        private List<string> nodes; 

        public Path()
        {
            nodes = new List<string>();
        }

        public void Add(string node)
        {
            nodes.Add(node); 
        }

        public void Reverse()
        {
            nodes.Reverse(); 
        }

        public override string ToString()
        {
            return "["+ string.Join(",",nodes)+"]";
        }
    }


}
