using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public class Tree
    {
        public Node Root { get; set; }
        public Tree()
        {
           
        }

        public void Insert(int item)
        {
            var newNode = new Node(item);
            if(Root == null)
            {
                Root = newNode; 
                return; 
            }

            var current = Root;


            while (current != null)
            {
                if (item > current.Value)
                {
                    if(current.RightChild == null)
                    {
                        current.RightChild = newNode;
                        return;
                    }
                        current = current.RightChild;
                    
                
                }
                    
                else if (item < current.Value)
                {
                    if (current.LeftChild == null)
                    {
                        current.LeftChild = newNode;
                        return;
                    }
                        current = current.LeftChild;
                   
                }
                    
            }

        }

        public bool Find(int item)
        {
            var current = Root;

            while (current != null)
            {
                if(item == current.Value)
                {
                    return true; 
                }
                if (item > current.Value)
                {
                    current = current.RightChild;
                    continue;
                }
                else if (item < current.Value)
                {
                    current = current.LeftChild;
                }
            }

            return false; 
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            var current = Root; 

            while (current!= null)
            {
                builder.Append(current.Value);
                builder.Append(", ");
                current = current.LeftChild; 
            }

            return builder.ToString(); 
        }
    }
}
