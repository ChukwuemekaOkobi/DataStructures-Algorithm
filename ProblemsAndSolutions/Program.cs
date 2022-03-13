using ProblemsAndSolutions.Challenges;
using System;

namespace ProblemsAndSolutions
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] array = new string[] {  "b-a","c-e","b-c","d-c"};

            Graph graph = new Graph(); 

            foreach(var str in array)
            {
                var ar = str.Split("-");

                graph.AddNode(ar[0]);
                graph.AddNode(ar[1]);

                graph.AddEdge(ar[0], ar[1]);
            }


            Console.WriteLine(graph.FarthestPath());



           


        }
    }
}
