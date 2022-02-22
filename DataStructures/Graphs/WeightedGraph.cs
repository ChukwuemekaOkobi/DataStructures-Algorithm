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

        public void AddEdge(string from, string to, int weight)
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

        public void PrintNodes()
        {
            Console.WriteLine("[" + string.Join(",", Nodes.Keys) + "]");
        }
        public void Print()
        {
            foreach (var node in Nodes.Values)
            {
                Console.WriteLine(node + " is connected to [" + string.Join(",", node.GetEdges()) + "]");
            }
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


}
