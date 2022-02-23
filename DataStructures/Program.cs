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

            newGraph.AddNode("A");
            newGraph.AddNode("B");
            newGraph.AddNode("C");
            newGraph.AddNode("D");

            newGraph.AddEdge("A", "B", 3);

            newGraph.AddEdge("B", "D", 4);

            newGraph.AddEdge("C", "D", 5);
            newGraph.AddEdge("A", "C", 1);
            newGraph.AddEdge("B", "C", 2);




            Console.WriteLine(newGraph.ShortestDistance("A", "D"));

            Console.WriteLine(newGraph.ShortestPath("A", "D"));

            Console.WriteLine(newGraph.MinimumSpaningTree());


        }

    }
}
