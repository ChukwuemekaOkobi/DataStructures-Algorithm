using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// Given a positive number n find the number of trailin Zeros in n! (n factorial) 
    /// n! = n * n-1 * n-2 * n-3 ....... * 1; 
    /// 
    /// Solution must be in logrithmic time s
    /// </summary>
    public class TrailingZeros
    {
        /// <summary>
        /// Logrithm Approach
        /// Count the numbers of occuring 5's in the sequence 
        /// </summary>
        public static int ZeroInFactorial(int num)
        {
            int de = 5;
            int count = 0;

            while (true)
            {
                int value = (int) Math.Floor((double)num / de); 

                if(value < 1)
                {
                    break;
                }

                count += value;
                de *= 5;

            }

            return count; 

        }
   
    
        public static int ZeroInFactorialBruteForce(int num)
        {
            int count = 0;

            int factorial = 1; 

            while(num > 1)
            {
                factorial *= num--;
            }

          
            while(true)
            {
                if(factorial%10 == 0)
                {
                    count++;
                    factorial /= 10;
                }
                else
                {
                    break;
                }
            }

            return count; 
        }
    }
}
