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
        


            graph.TraverseBreathFirst("a");
        }

    }
}
