using System;
using System.Collections.Generic;

namespace ProblemsAndSolutions.Microsoft
{
    /*/
     * Given a string containing just the characters '(' and ')', find the length of the 
     * longest valid (well-formed) parentheses substring.
     
        Example 1:
     *  Input: s = "(()"
        Output: 2
        Explanation: The longest valid parentheses substring is "()".
        Example 2:

        Input: s = ")()())"
        Output: 4
        Explanation: The longest valid parentheses substring is "()()".
        Example 3:

        Input: s = ""
        Output: 0
    /*/
    public class LongestValidParenthesis
    {

        // O(n ^ 2)
        public static int LengthUsingBruteForce(string s)
        {
           
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int count = 0;
                for (int j = i; j < s.Length; j++)
                {
                    if (s[j] == '(')
                    {
                        count++;
                    }
                    else
                    {
                        count--;
                    }
                    if (count < 0)
                    {
                        break;

                    }
                    if (count == 0)
                    {
                        max = Math.Max(j - i + 1, max);
                    }
                }
                if(s.Length-i < max)
                {
                    break;
                }
            }
            return max;
        }


        // O(n)
        public static int LengthUsingStack(string s)
        {
            int maxans = 0;
            Stack<int> stack = new();
            stack.Push(-1);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxans = Math.Max(maxans, i - stack.Peek());
                    }
                }
            }
            return maxans;
        }
       
       //O(n) 
        public static int LengthUsingDynamicProgramming(string s)
        {
            int maxans = 0;
            int[] dp = new int[s.Length];

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ')')
                {
                    if (s[i - 1] == '(')
                    {
                        dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                    }
                    else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                    {
                        dp[i] = dp[i - 1] + ((i - dp[i - 1]) >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
                    }
                    maxans = Math.Max(maxans, dp[i]);
                }
            }
            return maxans;

        }

        // O(n)
        public static int LengthUsingTransversal(string s)
        {
            int left = 0, right = 0, maxlength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    left++;
                }
                else
                {
                    right++;
                }
                if (left == right)
                {
                    maxlength = Math.Max(maxlength, 2 * right);
                }
                else if (right >= left)
                {
                    left = right = 0;
                }
            }
            left = right = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '(')
                {
                    left++;
                }
                else
                {
                    right++;
                }
                if (left == right)
                {
                    maxlength = Math.Max(maxlength, 2 * left);
                }
                else if (left >= right)
                {
                    left = right = 0;
                }
            }
            return maxlength;
        }
    }

}

