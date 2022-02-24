using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Searching
{
    /// <summary>
    /// uses a sorted list 
    /// sort first then search
    /// we keep dividing and conquer
    /// </summary>
    public class BinarySearch
    {
        public static int ContainsIteration(int[] items, int item)
        {
            Array.Sort(items);

            int left = 0;
            int right = items.Length - 1; 

         

            while (left<= right)
            {
                var pointer = (left + right) / 2;

                if (items[pointer] == item)
                {
                    return pointer;
                }
                else if(items[pointer] > item)
                {
                    right = pointer - 1; 
                }
                else
                {
                    left = pointer + 1; 
                }

            }

            return -1; 
        }
        public static int ContainsRecursion(int[] items, int item)
        {
            Array.Sort(items);
            
            return Contains(items, item, 0, items.Length -1); 
        }


        public static int Contains(int[] items, int item, int left, int right)
        {
            if(right < left)
            {
                return -1; 
            }
            
            int pointer = (left + right) / 2; 

            if( items[pointer] == item)
            {
                return pointer; 
            }

            if(item > items[pointer])
            {
               return Contains(items, item, pointer + 1, right);
            }
            return Contains(items, item, left, pointer-1); 
        }

      
    }
}
