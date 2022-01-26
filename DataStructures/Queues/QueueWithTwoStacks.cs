using DataStructures.Stacks;

namespace DataStructures.Queues
{
    /// <summary>
    /// Queue with two Stacks 
    /// one Stack is for enqueue and the other is for Dequeues
    /// </summary>
    public class QueueWithTwoStacks
    {
        ArrayStack addStack;
        readonly ArrayStack removeStack; 

        public QueueWithTwoStacks()
        {
            addStack = new ArrayStack();
            removeStack = new ArrayStack(); 
        }

        public int Count => addStack.Count + removeStack.Count;

        public void Enqueue(int item)
        {
            addStack.Push(item);

        }

        public int Dequeue()
        {
            if (removeStack.IsEmpty())
            {
                while (!addStack.IsEmpty())
                {
                    removeStack.Push(addStack.Pop());
                }
            }

            return removeStack.Pop();
        }

        public int Peek()
        {
            if (removeStack.IsEmpty())
            {
                while (!addStack.IsEmpty())
                {
                    removeStack.Push(addStack.Pop());
                }
            }

            return removeStack.Peek();
        }

        public void Reverse()
        {

            removeStack.Reverse();

            addStack.Reverse();

            while (!addStack.IsEmpty())
            {
                removeStack.Push(addStack.Pop());
            }

            addStack = new ArrayStack(); 

        }


        public override string ToString()
        {
            return removeStack.ToString() + addStack.ToString();

        }
    }
}
