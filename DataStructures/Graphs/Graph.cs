using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    public class Graph
    {

        private Dictionary<string, Node> Nodes;
        public Graph()
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
    }


    public class Node
    {
        public string Label { get; private set; }

        public Node(string label)
        {
            Label = label;
        }

    }
}
