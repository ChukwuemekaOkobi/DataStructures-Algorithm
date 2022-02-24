using System;

namespace Algorithms.Searching
{
    /// <summary>
    /// Divides array into blocks of size root or length
    /// checks which block the items can be founds
    /// </summary>
    public class JumpSearch
    {

        public static int Contains (int[] items, int item) 
        {
            Array.Sort(items); 

            int blockSize = (int)Math.Sqrt(items.Length);

            int start = 0;
            int next = blockSize; 

            while(start < items.Length && items[next-1]< item)
            {
                start = next;
    
                next += blockSize; 

                if(next > items.Length)
                {
                    next = items.Length; 
                }
            }

            for(var i = start; i< next; i++)
            {
                if(items[i] == item)
                {
                    return i; 
                }
            }

            return -1; 
        }
    }
}
