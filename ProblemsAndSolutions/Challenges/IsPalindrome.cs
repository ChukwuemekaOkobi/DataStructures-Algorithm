using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Challenges
{
    public class Palindrome
    {

        /// <summary>
        /// Using pointers from the start and end towards to middle
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
       public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            string num = x.ToString();

            int j = num.Length - 1;

            for (int i = 0; i < num.Length; i++)
            {
                if (!(num[i] == num[j--]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
