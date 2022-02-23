using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Directed Graph using HashTables from Node list and 
    /// AdjacencyList 
    /// 
    /// Can use List<> or Adjacency Matrix
    /// </summary>
    public class DirectedGraph
    {

        private readonly Dictionary<string, Node> Nodes;
        private readonly Dictionary<Node, HashSet<Node>> AdjacencyList; 
        public DirectedGraph()
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


        /// <summary>
        /// This method uses a stack to iteratively traverse the graph
        /// </summary>
        public void TraverseDepthFirstIteration(string label)
        {
            if (!Nodes.TryGetValue(label, out Node labelNode))
            {
                return;
            }

            Stack<Node> stack = new Stack<Node>();
            ISet<Node> visited = new HashSet<Node>();

            stack.Push(labelNode); 
            while (stack.Count != 0)
            {
                var current = stack.Pop();

                if (!visited.Contains(current))
                {
                    Console.WriteLine(current);
                    visited.Add(current);

                    foreach (var item in AdjacencyList[current])
                    {
                        if (!visited.Contains(item))
                        {
                           stack.Push(item);
                        }
                    }
                }

               
            }
        }

        /// <summary>
        /// This method uses a queue to iteratively traverse the graph
        /// </summary>

        public void TraverseBreathFirstIteration (string label)
        {
            if(!Nodes.TryGetValue(label, out Node labelNode))
            {
                return; 
            }

            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(labelNode);

            ISet<Node> visited = new HashSet<Node>(); 

            while(queue.Count != 0)
            {
                var current = queue.Dequeue();


                if (!visited.Contains(current))
                {
                    Console.WriteLine(current);
                    visited.Add(current); 

                    foreach(var item in AdjacencyList[current])
                    {
                        if (!visited.Contains(item))
                        {
                            queue.Enqueue(item); 
                        }
                    }
                }
                  
            }
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

        public void TraverseBreathFirst(string label)
        {
            if (!Nodes.TryGetValue(label, out Node labelNode))
            {
                return;
            }

            var queue = new Queue<Node>();
            queue.Enqueue(labelNode); 

            TraverseBreath( new HashSet<Node>(), queue);
        }

        private void TraverseBreath( ISet<Node> visited, Queue<Node> queue)
        {
            if(queue.Count == 0)
            {
                return;
            }

            var current = queue.Dequeue();
           
            if (!visited.Contains(current))
            {
                Console.WriteLine(current);
                visited.Add(current);

                foreach (var item in AdjacencyList[current])
                {
                    if (!visited.Contains(item))
                    {
                        queue.Enqueue(item);
                    }
                }
                TraverseBreath(visited, queue);
            }

        }
        
        public List<string> TopologicalSort()
        {
            var stack = new Stack<Node>();
            var visited = new HashSet<Node>(); 

            foreach(var item in Nodes.Values)
            {
                TopologicalSort(item, visited, stack); 
            }

            var sorted = new List<string>(); 

            while(stack.Count != 0)
            {
                sorted.Add(stack.Pop().Label);
            }

            return sorted;  
        }

        private void TopologicalSort(Node node, ISet<Node> visited, Stack<Node> stack)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node); 

            foreach(var item in AdjacencyList[node])
            {
                TopologicalSort(item, visited, stack); 
            }

            stack.Push(node); 
        }

        public bool HasCycle()
        {
            var nodes = Nodes.Values.ToHashSet();
            var visiting = new HashSet<Node>();

           
            var visited = new HashSet<Node>(); 


            while(nodes.Count != 0)
            {
                var current = nodes.First();

                if(HasCycle(current, nodes, visiting, visited))
                {
                    return true;
                }
            }

            return false; 
        }

        private bool HasCycle(Node node, ISet<Node> all, ISet<Node> visiting, ISet<Node> visited)
        {
            all.Remove(node);
            visiting.Add(node); 

            foreach(var item in AdjacencyList[node])
            {
                if (visited.Contains(item))
                {
                    continue;
                }

                if (visiting.Contains(item))
                {
                    return true; 
                }

                if(HasCycle(item, all, visiting, visited))
                {
                    return true;
                }
            }

            visiting.Remove(node);
            visited.Add(node);

            return false;
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
        

        private class Node
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


    
}
