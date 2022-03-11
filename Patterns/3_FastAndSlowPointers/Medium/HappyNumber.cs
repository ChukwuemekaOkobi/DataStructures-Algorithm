using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._3_FastAndSlowPointers
{
    /// <summary>
    /// Any number will be called a happy number if, after repeatedly replacing 
    /// it with a number equal to the sum of the square of all of its digits, leads us to number ‘1’.
    /// All other (not-happy) numbers will never reach ‘1’. Instead, 
    /// they will be stuck in a cycle of numbers which does not include ‘1’.
    /// 
    /// Input: 23   
    /// Output: true (23 is a happy number)  
    /// 
    /// Input: 12
    /// Output: false (12 is not happy number)  

    /// </summary>
    public class HappyNumber
    {
        public static bool Find(int num)
        {
            // // TODO: Write your code here

            int sum = num;

            HashSet<int> Sums = new HashSet<int>();


            while (sum != 1 && !Sums.Contains(sum))
            {

                int temp = 0, digit;
                while (sum > 0)
                {
                    digit = sum % 10;
                    temp += digit * digit;
                    sum /= 10;
                }

                sum = temp;

                Sums.Add(sum);

            }

            return sum == 1;
        }

        public static bool Find2(int num)
        {
            int slow = num, fast = num;
            do
            {
                slow = FindSquareSum(slow); // move one step
                fast = FindSquareSum(FindSquareSum(fast)); // move two steps
            } while (slow != fast); // found the cycle

            return slow == 1; // see if the cycle is stuck on the number '1'

            static int FindSquareSum(int num)
            {
                int sum = 0, digit;
                while (num > 0)
                {
                    digit = num % 10;
                    sum += digit * digit;
                    num /= 10;
                }
                return sum;
            }
        }


    }
}