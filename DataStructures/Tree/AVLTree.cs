using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public class AVLTree
    {

    }


    public class AVLNode
    {
        public AVLNode LeftChild { get; set; }
        public AVLNode RightChild { get; set; }

        public int Value { get; set; }


        public AVLNode(int item)
        {
            Value = item;

            LeftChild = null;
            RightChild = null; 
        }
    }
}
