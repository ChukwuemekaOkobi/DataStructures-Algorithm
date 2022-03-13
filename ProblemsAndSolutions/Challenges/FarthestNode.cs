using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Challenges
{

    /// <summary>
    /// QUESTION: The Furtherest Node from in a Graph
    /// Given an array of edges find the distance of the furthest Node in 
    /// the graph .
    /// input ["b-a","c-e","b-c","d-c"]
    /// output 3
    /// </summary>
    public class Graph
    {
        private readonly Dictionary<string, Node> Nodes; //Hash Map

        public Graph() {
            Nodes = new Dictionary<string, Node>();
        }

        public void AddNode(string label)
        {
            if (!Nodes.ContainsKey(label))
            {
                Nodes.Add(label, new Node(label));
            }
        }

        public void AddEdge(string from, string to)
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
            fromNode.AddEdge(toNode);
            toNode.AddEdge(fromNode);

        }
       
        
        public int FarthestPath()
        {
            int maxLength = int.MinValue; 

            foreach(var n in Nodes)
            {
                maxLength = Math.Max(maxLength, DepthFirst(n.Key));
            }

            return maxLength; 
        }

        public int DepthFirst(string label)
        {
            if (!Nodes.TryGetValue(label, out Node labelNode))
            {
                return 0;
            }
           return TraverseDepth(labelNode, new HashSet<Node>());
        }

        private int TraverseDepth(Node node, ISet<Node> visited)
        {
            
            visited.Add(node);
            int count = 0; 

            foreach (var item in node.GetEdges())
            {
                if (!visited.Contains(item.To))
                {
                  count = Math.Max(count ,  TraverseDepth(item.To, visited) +1);
                }
            }

            return count;

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



            public void AddEdge(Node to)
            {
                Edges.Add(new Edge(this, to));
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

        

            public Edge(Node from, Node to)
            {
                To = to;
                From = from;
            }

            public override string ToString()
            {
                return From + " -> " + To;
            }
        }

    }


}
