using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public class BinaryTree
    {
        private Node Root { get; set; }
        public BinaryTree()
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
        

        public List<int> GetAncestors(int item)
        {
            List<int> list = new List<int>();

            GetAncestor(Root, item, list);

            return list;
        }

        private bool GetAncestor(Node node, int item, List<int> array)
        {
            if(node == null)
            {
                return false;
            }

            if(node.Value == item)
            {
                return true; 
            }

            if(GetAncestor(node.LeftChild, item, array) || GetAncestor(node.RightChild, item, array))
            {
                array.Add(node.Value);
                return true;
            }

            return false;


        }



        public bool AreSibling(int left, int right)
        {
            return IsParent(Root, left, right);
        }

        private bool IsParent (Node node, int left, int right)
        {
            if(node == null)
            {
                return false; 
            }
            if (!IsLeafNode(node))
            {
                if((node.LeftChild.Value == left && node.RightChild.Value == right) 
                    || (node.RightChild.Value == left && node.LeftChild.Value == right))
                {
                    return true;
                } 
            }

            if(node.LeftChild!= null)
            {
                return IsParent(node.LeftChild, left, right);
            }

            if (node.RightChild != null)
            {
                return IsParent(node.RightChild, left, right);
            }

            return false;

        }


        public int Leaves()
        {
            return Leaves(Root);
        }
        private int Leaves(Node node)
        {
            if(node == null)
            {
                return 0;
            }
            if (IsLeafNode(node))
            {
                return 1;
            }

            return Leaves(node.LeftChild) + Leaves(node.RightChild);
        }
        public int Size()
        {
            return Size(Root);
        }

        private int Size (Node node)
        {
            if(node == null)
            {
                return 0; 
            }
            
            return 1 + Size(node.LeftChild) + Size(node.RightChild); 
        }


        /// <summary>
        /// Checks if a value is in a tree using loops
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Checks if a item in the Tree using Recursion
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(int item)
        {
            return Contains(Root, item);
        }
        private bool Contains(Node node, int item)
        {
            if(node is null)
            {
                return false;
            }

            if(node.Value == item)
            {
                return true; 
            }

            return node.Value > item ? Contains(node.LeftChild, item) : Contains(node.RightChild, item);

        }
       
        /// <summary>
        /// Traversing Tree in different Orders using Recursion
        /// </summary>
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

       

     

        /// <summary>
        /// Check is this three is a binary search tree
        /// </summary>
        /// <returns></returns>
        public bool IsBinarySearchTree()
        {
            return IsBST(Root, int.MinValue, int.MaxValue);
        }

        private bool IsBST(Node node, int Min, int Max)
        {

            if (node is null)
            {
                return true;
            }

            if (node.Value < Min || node.Value > Max)
            {
                return false;
            }

            return IsBST(node.LeftChild, Min, node.Value - 1) && IsBST(node.RightChild, node.Value + 1, Max);
        }

        public void Swap()
        {
            var temp = Root.LeftChild;
            Root.LeftChild = Root.RightChild;
            Root.RightChild = temp;
        }

        
        /// <summary>
        /// Minimum in a BST using loop
        /// </summary>
        /// <returns></returns>

        public int MinBinarySearchTree()
        {
            if(Root == null)
            {
                throw new ArgumentNullException();
            }

            var current = Root;
            var last = new Node(0);

            while(current != null)
            {
                last = current;
                current = current.LeftChild;
            }

            return last.Value;
        }

        /// <summary>
        /// Max in a BST using Recursion
        /// </summary>
        /// <returns></returns>
        public int MaxBinarySearchTree()
        {
            if (Root == null)
            {
                throw new ArgumentNullException();
            }

            return MaxRecursion(Root);
        }

        private int MaxRecursion(Node node)
        {
            if(node == null)
            {
                return int.MinValue; 
            }

            return Math.Max(node.Value, MaxRecursion(node.RightChild)); 
        }

        public int Min()
        {
            return Min(Root);
        }

        private int Min(Node root)
        {
            if(root == null)
            {
                return int.MaxValue;
            }
            if (IsLeafNode(root))
            {
                return root.Value;
            }
            var left =  Min(root.LeftChild);
            var right = Min(root.RightChild); 

            return  Math.Min(Math.Min(left,right), root.Value);
        }
        
        /// <summary>
        /// Checks if two threes are equal
        /// </summary>

        public bool Equal(BinaryTree tree)
        {
            return IsEqual(Root, tree.Root);
        }

        private bool IsEqual(Node first, Node second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first != null & second != null)
            {
                return (first.Value == second.Value) && IsEqual(first.LeftChild, second.LeftChild) && IsEqual(first.RightChild, second.RightChild);
            }

            return false;
        }

        /// <summary>
        /// Finds the height of the three
        /// </summary>
        /// <returns></returns>
        public int Height()
        {
            return Height(Root);
        }


        private int Height(Node root)
        {
            if (root == null)
            {
                return -1;
            }
            if (IsLeafNode(root))
            {
                return 0;
            }

            return 1 + Math.Max(Height(root.LeftChild), Height(root.RightChild));
        }
        private static bool IsLeafNode(Node node)
        {
            return node.LeftChild == null && node.RightChild == null;
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
