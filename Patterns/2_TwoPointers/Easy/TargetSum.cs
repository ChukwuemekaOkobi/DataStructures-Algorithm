using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// QUESTION: Pair to A Target Sum 
    /// Given an array of sorted numbers and a target sum, find a pair in the array whose sum is equal to the given target.
    /// Write a function to return the indices of the two numbers (i.e. the pair) such that they add up to the given target.

    //Example 1:

    //Input: [1, 2, 3, 4, 6], target = 6
    //Output: [1, 3]
    //Explanation: The numbers at index 1 and 3 add up to 6: 2+4=6
    //Example 2:

    //Input: [2, 5, 9, 11], target=11
    //Output: [0, 2]
    //Explanation: The numbers at index 0 and 2 add up to 11: 2+9=11
    /// </summary>
    public class TargetSum
    {
       
        /// <summary>
        /// Looping through the array and using linear search O(N * N) 
        /// using binary search O(N LogN) 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<int> BruteForce(int [] numbers , int target)
        {
            var list = new List<int>();
            bool found = false; 

            for(int i = 0;i< numbers.Length-1; i++)
            {
                for(int j = 0; j<numbers.Length; j++)
                {
                    if(numbers[i]+numbers[j] == target)
                    {
                        list.Add(i);
                        list.Add(j);
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }

            return list; 

        }

        /// <summary>
        /// Two pointers starting at both ends 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<int> TwoPointers(int [] numbers, int target)
        {
            var list = new List<int>();

            int left = 0;
            int right = numbers.Length - 1; 

            while(left<right && right< numbers.Length)
            {
                int value = numbers[left] + numbers[right]; 

                if(value == target)
                {
                    list.Add(left);
                    list.Add(right); 
                    break;
                }
                else if(value < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }

            }
            return list;
        }

        /// <summary>
        ///  Check in the hash table of a key value which has the value (target - number)
        /// </summary>

        public static int[] HashTable(int[] numbers, int target)
        {
            var table = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (table.ContainsKey(target - numbers[i]))
                {
                    return new int[] { table.GetValueOrDefault(target - numbers[i]), i };
                }
                else
                {
                    table.Add(numbers[i], i);
                }
            }

            return new int[] { -1, -1 };
        }

        /// <summary>
        /// Store the value of the different of the target and numbers in the array 
        /// loop through the harsh map value to find the value
        /// O(n + n +n);
        /// Not efficient
        /// </summary>

        public static int[] HashTable2(int [] numbers, int target)
        {
            var table = new Dictionary<int, int>(); 

            foreach(var n in numbers)
            {
                table.Add(target-n, n);
            }

            for(int i = 0; i< numbers.Length; i++)
            {
                if (table.ContainsKey(numbers[i]))
                {
                   var value = table[numbers[i]];

                    var ad = Array.IndexOf(numbers, value); //problem
                   
                    return new int[] { i, ad };
                }
            }

            return new int[] { -1, -1 };
        }

 
    }
}
