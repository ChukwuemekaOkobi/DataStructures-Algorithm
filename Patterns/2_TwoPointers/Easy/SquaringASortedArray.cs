using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// Given a sorted array, create a new array containing squares of all the numbers of the input array in the sorted order.
    //Example 1:

    //Input: [-2, -1, 0, 2, 3]
    //Output: [0, 1, 4, 4, 9]
    //Example 2:

    //Input: [-3, -1, 0, 1, 2]
    //Output: [0, 1, 1, 4, 9]
    /// </summary>
    public class SquaringASortedArray
    {
        /// <summary>
        ///  since squares are all positive numbers and 0 
        ///  insert starting from the largest to the least
        /// </summary>

        public static int[] MakeSquares(int [] arr)
        {
            int[] squares = new int[arr.Length];
            int n = arr.Length - 1;
            int left = 0, right= n ,index =n;
          

            while (left < right)
            {
                int leftS =(int) Math.Pow(arr[left], 2);
                int rightS = (int)Math.Pow(arr[right], 2); 

                if(leftS > rightS)
                {
                    squares[index--] = leftS;
                    left++;
                }
                else if(leftS < rightS)
                {
                    squares[index--] = rightS;
                    right--;
                }
                else
                {
                    squares[index--] = leftS;
                    squares[index--] = rightS;
                    right--;
                    left++;
                }

            }
            return squares;
        }
  

    }
}
