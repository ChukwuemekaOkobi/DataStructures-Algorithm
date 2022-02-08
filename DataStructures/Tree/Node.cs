namespace DataStructures.Tree
{
    public class Node
    {
        public int Value { get; private set; }

        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public Node(int item)
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
