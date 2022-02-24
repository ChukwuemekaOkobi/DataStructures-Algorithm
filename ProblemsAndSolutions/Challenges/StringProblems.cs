using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Challenges
{
   public class StringProblems
    {
        public static int NoOfVowels(string word) 
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return 0; 
            }
            var vowels  =  new HashSet<char>(new []{ 'a','e','i','o','u'});
           
            var count = 0; 
            foreach(var ch in word.ToLower())
            {
                if (vowels.Contains(ch))
                {
                    count++;
                }
            }

            return count; 
        }


        /// <summary>
        /// Reverse a String Using Stack
        /// </summary>
        public static string ReverseStack(string item)
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

            while (stack.Count != 0)
                builder.Append(stack.Pop());

            return builder.ToString();
        }


        public static string ReverseLoop(string item)
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                return null;
            }

            StringBuilder builder = new StringBuilder();
            for(int i = item.Length-1 ; i>=0; i--)
            {
                builder.Append(item[i]);
            }

            return builder.ToString();
        }

    }
    
}
