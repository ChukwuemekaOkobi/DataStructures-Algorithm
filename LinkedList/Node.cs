namespace LinkedList
{
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
