using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Microsoft
{
    public class MinNumberOfDeletions
    {
        /// <summary>
        /// Given a string with only characters X and Y. Find the minimum number of characters to 
        /// remove from the string such that there is no interleaving of character X and Y and all the Xs appear before any Y
        /// Input:YXXXYXY
        /// Input:YYXYXX
        /// Output: 2
        /// </summary>

        public static int MinDeletionXY(string str)
        {
            int charX = 'x';
            int numY = 0;
            int minDel = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (charX == str[i])
                {
                    minDel = Math.Min(numY, minDel + 1);
                }
                else
                {
                    numY++;
                }
            }
            return minDel;
        }

        ///<summary>
        ///Given an integer(+ve or -ve) consisting of at least one 5 in its digits(can have more than one 5). 
        //    Return the maximum value by deleting exactly one 5 from its digit.
        // Ex: N = 1598 => result = 198(remove the only 5 from the sequence)
        //N = 150,958 => result = 15,098(we wanna return the maximum value 15,098 > 10,958)
        //N = -5859 => result = -589 ( -589>- 859)
        /// </summary>
        


        public static int SingleDeletionOf5(int num)
        {

            bool isPositive = num > 0;

            int max = isPositive ? 0 : int.MinValue;

            var str = Math.Abs(num).ToString();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '5')
                {
                    int temp =  int.Parse(str.Remove(i, 1));

                    temp = isPositive ? temp : -temp;
                  
                    max = Math.Max(temp, max);

                }
            }

            return max;

        }

        ///Maximum possible value by inserting '5'
        //    examples:
        //input: 1234 -> output: 51234
        //input: 7643 -> output 76543
        //input: 0 -> output 50
        //input: -661 -> output -5661

        public static int MaxValueInserting5(int num)
        {
            bool isPositive = num > 0;

            var str = Math.Abs(num).ToString();

            for (int i = 0; i< str.Length; i++)
            {
                if (str[i] <= '5' && isPositive)
                {
                    string temp = str.Insert(i, "5");

                    return int.Parse(temp); 
                }
                else if(str[i] >='5' && !isPositive)
                {
                    string temp = str.Insert(i, "5");
                    return -int.Parse(temp);
                }
            }

              str =  str.Insert(str.Length, "5");

            return isPositive ? int.Parse(str) : -int.Parse(str);
        }


    }

    
}
