using DataStructures;
using DataStructures.LinkedList;
using DataStructures.Stacks;
using System.Collections.Generic;
using System.Text;
using System;
using DataStructures.Queues;
using DataStructures.HashTable;
using System.Linq;
using System.Diagnostics;
using DataStructures.Tree;
using DataStructures.Trees;
using DataStructures.Graphs;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {

            var newGraph = new WeightedGraph();

            newGraph.AddNode("X");
            newGraph.AddNode("A");
            newGraph.AddNode("B");
            newGraph.AddNode("P");

            newGraph.AddEdge("X", "A",1);

            newGraph.AddEdge("X", "B",7);

            newGraph.AddEdge("A", "P",5);

            newGraph.AddEdge("B", "P",2);


            newGraph.Print();


        }

    }
}
