namespace BinaryTree
{
    /// <summary>
    /// Binary Tree Nodes Reference 
    /// holds reference of the left and right nodes of the tree
    /// </summary>
    public class Node
    {
        //holds the value of the node
        public int Value;

        //holds the reference to the next tree value
        public Node Left, Right;

        public Node(int value)
        {
            Value = value;
            Left = Right = null; 
        }
    }
}
