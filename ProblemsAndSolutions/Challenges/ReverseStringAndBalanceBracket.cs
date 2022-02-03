using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Challenges
{
    /// <summary>
    /// This Class contains problems involving stacks 
    /// </summary>
    public class ReverseStringAndBalanceBracket
    {
        /// <summary>
        /// Find if a sentence has balanced brackets
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsBalanced(string item)
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                return false;
            }
            string openbrackets = "[{<(";
            string closebrackets = "]}>)";

            Stack<char> stacks = new();

            foreach (var c in item)
            {
                if (openbrackets.Contains(c))
                {
                    stacks.Push(c);
                }

                if (closebrackets.Contains(c))
                {
                    if (stacks.Count <= 0)
                    {
                        return false;
                    }
                    char b = stacks.Pop();

                    if (openbrackets.IndexOf(b) == closebrackets.IndexOf(c))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            return stacks.Count == 0;
        }

        /// <summary>
        /// Reverse a String
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string Reversed(string item)
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                return null;
            }
            Stack<char> stack = new();

            foreach (var n in item)
            {
                stack.Push(n);
            }

            StringBuilder builder = new();

            while (stack.Count!=0)
                builder.Append(stack.Pop());

            return builder.ToString();
        }
    }
}
