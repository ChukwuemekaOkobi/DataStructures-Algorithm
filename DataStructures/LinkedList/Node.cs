namespace DataStructures
{ 
    /// <summary>
    /// LinkedListNode Reference of the Linked List
    /// </summary>
    public class LinkedListNode
    {
        //reference to the next LinkedListNode in sequence 
        public LinkedListNode Next;
        public LinkedListNode Previous; 
        public int Value { get; private set; }

        public LinkedListNode(int data)
        {
            Value = data;
            Next = null;
            Previous = null; 
        }
    }





}
