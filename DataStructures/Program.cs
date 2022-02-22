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

            Graph graph = new Graph();

            graph.AddNode("a");
            graph.AddNode("b");
            graph.AddNode("c");
            graph.AddNode("d");

            graph.AddEdge("a", "b");

            graph.AddEdge("b", "d");

            graph.AddEdge("d", "c");

            graph.AddEdge("a", "c");

            var newGraph = new Graph();

            newGraph.AddNode("X");
            newGraph.AddNode("A");
            newGraph.AddNode("B");
            newGraph.AddNode("P");

            newGraph.AddEdge("X", "A");

            newGraph.AddEdge("X", "B");

            newGraph.AddEdge("A", "P");

            newGraph.AddEdge("B", "P");

            newGraph.AddEdge("P", "A");

            Console.WriteLine(string.Join(", ", newGraph.TopologicalSort()));

            Console.WriteLine(newGraph.HasCycle());


        }

    }
}
