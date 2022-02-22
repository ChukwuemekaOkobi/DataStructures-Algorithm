using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Graph using HashTables from Node list and 
    /// AdjacencyList 
    /// 
    /// Can use List<> or Adjacency Matrix
    /// </summary>
    public class Graph
    {

        private readonly Dictionary<string, Node> Nodes;
        private readonly Dictionary<Node, HashSet<Node>> AdjacencyList; 
        public Graph()
        {
            Nodes = new Dictionary<string, Node>();

            AdjacencyList = new Dictionary<Node, HashSet<Node>>(); 
        }


        public void AddNode(string label)
        {
            if (!Nodes.ContainsKey(label))
            {
                var node = new Node(label);  
                Nodes.Add(label,node);
                AdjacencyList.Add(node, new HashSet<Node>());
            }
        }

        public void AddEdge(string  from , string to)
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
            AdjacencyList[fromNode].Add(toNode);
        }

        public  void RemoveNode (string label)
        {
            if (!Nodes.TryGetValue(label, out Node labelNode))
            {
                return;
            }

            //Remove all Connection 

            foreach(var source in AdjacencyList)
            {
                source.Value.Remove(labelNode);
            }

            AdjacencyList.Remove(labelNode);

            Nodes.Remove(label); 
        }

        public void RemoveEdge(string from, string to)
        {
            if (!Nodes.TryGetValue(from, out Node fromNode))
            {
                return;
            }

            if (!Nodes.TryGetValue(to, out Node toNode))
            {
                return;
            }


            AdjacencyList[fromNode].Remove(toNode);

        }


        

        public void TraverseDepthFirst(string label)
        {
            if(!Nodes.TryGetValue(label, out Node labelNode))
            {
                return;
            }
            TraverseDepth(labelNode, new HashSet<Node>());
        }

        private void TraverseDepth(Node node, ISet<Node> visited)
        {
            Console.WriteLine(node);
            visited.Add(node);

            foreach (var item in AdjacencyList[node])
            {
                if (!visited.Contains(item))
                {
                    TraverseDepth(item, visited); 
                }
            }

            
        }
        public void PrintNodes()
        {
            Console.WriteLine("[" +string.Join(",", Nodes.Keys) +"]");
        }
        public void Print()
        {
            foreach(var source in AdjacencyList)
            {
                if(source.Value.Count != 0)
                {
                    Console.WriteLine(source.Key  + " is connected to [" + string.Join(",", source.Value)+ "]");
                }
            }
        }
    }


    public class Node
    {
        public string Label { get; private set; }

        public Node(string label)
        {
            Label = label;
        }

        public override string ToString()
        {
            return $"{Label}";
        }

    }
}
