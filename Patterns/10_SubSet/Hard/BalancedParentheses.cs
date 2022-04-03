
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Patterns._10_SubSet
{
    /// <summary>
    /// For a given number ‘N’, write a function to generate all combination of ‘N’ pairs of balanced parentheses.

    //Example 1:

    //Input: N=2
    //Output: (()), () ()
    // Example 2:

    //Input: N=3
    //Output: ((())), (()()), (()) (), () (()), () () ()
    /// </summary>
    public class BalancedParentheses
    {
    
            public static List<string> GenerateValidParentheses(int num)
            {
                List<string> result = new ();
                Queue<ParenthesesString> queue = new();
                queue.Enqueue(new ParenthesesString("", 0, 0));
                while (queue.Count !=0)
                {
                    ParenthesesString ps = queue.Dequeue();
                    // if we've reached the maximum number of open and close parentheses, add to the result
                    if (ps.OpenCount == num && ps.CloseCount == num)
                    {
                        result.Add(ps.Str);
                    }
                    else
                    {
                        if (ps.OpenCount < num) // if we can add an open parentheses, add it
                            queue.Enqueue(new ParenthesesString(ps.Str + "(", ps.OpenCount + 1, ps.CloseCount));

                        if (ps.OpenCount > ps.CloseCount) // if we can add a close parentheses, add it
                            queue.Enqueue(new ParenthesesString(ps.Str + ")", ps.OpenCount, ps.CloseCount + 1));
                    }
                }
                return result;
            }

        public static List<string> GenerateValidParentheses2(int num)
        {
            List<string> result = new ();
            char[] parenthesesString = new char[2 * num];
            GenerateValidParenthesesRecursive(num, 0, 0, parenthesesString, 0, result);
            return result;
        }

        private static void GenerateValidParenthesesRecursive(int num, int openCount, int closeCount,
            char[] parenthesesString, int index, List<string> result)
        {

            // if we've reached the maximum number of open and close parentheses, add to the result
            if (openCount == num && closeCount == num)
            {
                result.Add(new string(parenthesesString));
            }
            else
            {
                if (openCount < num)
                { // if we can add an open parentheses, add it
                    parenthesesString[index] = '(';
                    GenerateValidParenthesesRecursive(num, openCount + 1, closeCount, parenthesesString, index + 1, result);
                }

                if (openCount > closeCount)
                { // if we can add a close parentheses, add it
                    parenthesesString[index] = ')';
                    GenerateValidParenthesesRecursive(num, openCount, closeCount + 1, parenthesesString, index + 1, result);
                }
            }
        }
        class ParenthesesString
        {
            public string Str { get; set; }
            public int OpenCount { get; set; } // open parentheses count
            public int CloseCount { get; set; }// close parentheses count

            public ParenthesesString(string s, int openCount, int closeCount)
            {
                Str = s;
                OpenCount = openCount;
                CloseCount = closeCount;
            }
        }


    }
}