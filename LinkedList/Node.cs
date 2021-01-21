namespace LinkedList
{
    /// <summary>
    /// Node Reference of the Linked List
    /// </summary>
    public class Node
    {
        //reference to the next node in sequence 
        public Node Next;
        public int Value;

        public Node(int data)
        {
            Value = data;
            Next = null;
        }
    }


}
