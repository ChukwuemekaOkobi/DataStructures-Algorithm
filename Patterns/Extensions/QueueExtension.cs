using System.Collections.Generic;

namespace Patterns
{
    //Extends 
    public static class QueueExtension
    {
        public static void Remove<T,U> (this PriorityQueue<T,U> item, T element)
        {
            var list = new List<(T, U)>();

            while (item.Count != 0)
            {
                if(item.Peek().Equals(element))
                {
                    item.Dequeue();
                    break;
                }
                else
                {
                    item.TryDequeue(out T elem, out U priority);

                    list.Add((elem, priority));
                }
            }
            int i = 0; 
            while(i < list.Count)
            {
                item.Enqueue(list[i].Item1, list[i].Item2);
                i++;
            }
        }

        public static bool IsEmpty<T,U>(this PriorityQueue<T, U> item)
        {
            return item.Count == 0; 
        }

        
    }

}
