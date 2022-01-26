namespace DataStructures.Stacks
{
    /// <summary>
    /// Implementation of Stack to get the minimum value in O9i) time 
    /// Transversing the entire Stack to find the minimum value will be O(n) time
    /// This requires uisng Two Stacks, one to hold the actual values and the other to 
    /// hold the minimum value at each time.
    /// </summary>
    public class MinStack
    {

        private readonly ArrayStack Values;
        private readonly ArrayStack Minimum;


        public MinStack()
        {
            Values = new();
            Minimum = new ();
        }



        public void Push(int item)
        {

            if(Values.Count == 0)
            {
                Minimum.Push(item);
            }
            Values.Push(item); 

            if(item < Minimum.Peek())
            {
                Minimum.Push(item);
            }
            else
            {
                Minimum.Push(Minimum.Peek());
            }
 
        }

        public int Pop()
        {
            Minimum.Pop();
            return Values.Pop();
        }

        public int Peek()
        {
            return Values.Peek();
        }

        public int GetMin()
        {
            return Minimum.Peek();
        }

        public bool IsEmpty()
        {
            return Values.IsEmpty();
        }


        public override string ToString()
        {
            return Values.ToString();
        }

    }
}
