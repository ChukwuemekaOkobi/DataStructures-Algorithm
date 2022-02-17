using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public class AVLTree
    {
        public Node Root { get; set; }

        public int Count { get; set; }

        public AVLTree()
        {

        }

        public void Insert(int item)
        {
           Root = Insert(Root, item);
        }

        private Node Insert(Node node, int item)
        {
            if(node == null)
            {
               Count++;
               return new Node(item);
            }

            if (item > node.Value)
              node.RightChild =  Insert(node.RightChild, item);
              
            else
              node.LeftChild =   Insert(node.LeftChild, item);

            node.Height = Height(node);

            return Balance(node); 
            
        }

        private Node Balance(Node node)
        {

            if(IsLeftHeavy(node))
            {
                if (BalanceFactor(node.LeftChild) < 0)
                    node.LeftChild  = LeftRotate(node.LeftChild);

               return RightRotate(node);
            }
            else if(IsRightHeavy(node))
            {
                if (BalanceFactor(node.RightChild) > 0)
                   node.RightChild = RightRotate(node.RightChild);
               return LeftRotate(node);
            }

            return node; 
        }

        private Node LeftRotate(Node node)
        {
            var newRoot = node.RightChild;

            node.RightChild = newRoot.LeftChild;

            newRoot.LeftChild = node;

            node.Height = Height(node);

            newRoot.Height = Height(newRoot);

            return newRoot; 
        }
        
        private Node RightRotate(Node node)
        {
            var newRoot = node.LeftChild;

            node.LeftChild = newRoot.RightChild;

            newRoot.RightChild = node;

            node.Height = Height(node); 
            newRoot.Height = Height(newRoot);

            return newRoot; 
        }



        private bool IsRightHeavy(Node node)
        {
            return BalanceFactor(node) < -1;
        }

        private bool IsLeftHeavy(Node node)
        {
            return BalanceFactor(node) > 1;
        }

        private int BalanceFactor(Node node)
        {
            if(node == null)
            {
                return 0; 
            }
 
            return Height(node.LeftChild) - Height(node.RightChild); 
        }

      

        public int Height()
        {
            return Root.Height;
        }

        private int Height(Node root)
        {
            if (root == null)
            {
                return -1;
            }
            return 1 + Math.Max(RHeight(root.LeftChild), RHeight(root.RightChild));
        }



        private int RHeight(Node root)
        {
            if(root == null)
            {
                return -1; 
            }

            return root.Height; 
        }


    


        public int Size()
        {
            return Size(Root);
        }

        private int Size(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Size(node.LeftChild) + Size(node.RightChild);
        }


        public bool Contains(int item)
        {
            return Contains(Root, item);
        }
        private bool Contains(Node node, int item)
        {
            if (node is null)
            {
                return false;
            }

            if (node.Value == item)
            {
                return true;
            }

            return node.Value > item ? Contains(node.LeftChild, item) : Contains(node.RightChild, item);

        }

        public int Min()
        {
            return Min(Root);
        }

        private int Min(Node root)
        {
            if (root == null)
            {
                return int.MaxValue;
            }
            if (IsLeafNode(root))
            {
                return root.Value;
            }
            var left = Min(root.LeftChild);
            var right = Min(root.RightChild);

            return Math.Min(Math.Min(left, right), root.Value);
        }

      
        private static bool IsLeafNode(Node node)
        {
            return node.LeftChild == null && node.RightChild == null;
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(Root);
        }
        private void TraversePreOrder(Node root)
        {
            if (root is null)
            {
                return;
            }
            Console.Write(root.Value + ", ");
            TraversePreOrder(root.LeftChild);
            TraversePreOrder(root.RightChild);

        }
        
        public void TraverseInOrder()
        {
            TraverseInOrder(Root);
        }
        private void TraverseInOrder(Node root)
        {
            if (root is null)
            {
                return;
            }
            TraverseInOrder(root.LeftChild);

            Console.Write(root.Value + ", ");

            TraverseInOrder(root.RightChild);
        }
        public void TraversePostOrder()
        {
            TraversePostOrder(Root);
        }
        private void TraversePostOrder(Node root)
        {
            if (root is null)
            {
                return;
            }
            TraversePostOrder(root.LeftChild);

            TraversePostOrder(root.RightChild);

            Console.Write(root.Value + ", ");
        }

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


        public override string ToString()
        {
            return $"Node = {Value}";
        }
    }


}
