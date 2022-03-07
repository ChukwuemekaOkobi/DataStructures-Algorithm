using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._1_SlidingWindow
{
    /// <summary>
    /// You are visiting a farm to collect fruits. The farm has a single row of fruit trees. You will be given two baskets, and your goal is to pick as many fruits as possible to be placed in the given baskets.

    /*You will be given an array of characters where each character represents a fruit tree.The farm has following restrictions:

    Each basket can have only one type of fruit.There is no limit to how many fruit a basket can hold.
    You can start with any tree, but you can’t skip a tree once you have started.
    You will pick exactly one fruit from every tree until you cannot, i.e., you will stop when you have to pick from a third fruit type.
    Write a function to return the maximum number of fruits in both baskets */
    ///Input: Fruit=['A', 'B', 'C', 'A', 'C']
    /// Output: 3
    /// Explanation: We can put 2 'C' in one basket and one 'A' in the other from the subarray['C', 'A', 'C']


    ///Input: Fruit=['A', 'B', 'C', 'B', 'B', 'C']
    ///    Output: 5
    ///  Explanation: We can put 3 'B' in one basket and two 'C' in the other basket.
    /// This can be done if we start with the second letter: ['B', 'C', 'B', 'B', 'C']
    /// 
    /// 
    /// Find the length longest SubString with two distinct Characters
    /// Longest Substring with at most 2 distinct characters
    /// </summary>
    public class FruitBasket
    {
        public static int MaxNumberOfFruits(char[] arr)
        {

            int length = 0;

            int start = 0;

            Dictionary<char, int> Fruits = new Dictionary<char, int>();

          //  'A', 'B', 'C', 'B', 'B', 'C'
            for (int end = 0; end < arr.Length; end++)
            {
                if (!Fruits.TryAdd(arr[end], 1))
                {
                    Fruits[arr[end]] += 1;
                }
          
                if(Fruits.Count > 2)
                {
                    Fruits[arr[start]]--;

                    if(Fruits[arr[start]] == 0)
                    {
                        Fruits.Remove(arr[start]);
                    }

                    start++;
 
                }

                length = Math.Max(length, end - start+1);
            }


            return length; 

        }
    
    
    }
}
