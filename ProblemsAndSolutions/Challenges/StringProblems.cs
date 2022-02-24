using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// Reverse a string using loop
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

         /// <summary>
         /// Reverse a words in a sentence
         /// </summary>
        public static string ReverseWords (string sentence)
        {
            var words = sentence.Split(" ");

            StringBuilder builder = new StringBuilder(); 

            
            for(int i = words.Length-1; i>=0; i--)
            {
                builder.Append(words[i]);
                builder.Append(' ');
            }

            return builder.ToString().Trim(); 
        }    

        public static string ReverseWords2(string sentence)
        {
            var words = sentence.Split(" ");

            Array.Reverse(words);

            return string.Join(" ", words);
        }

        public static string RemoveDuplicateCharacters(string word)
        {
            var set = new HashSet<char>(word);

            StringBuilder builder = new StringBuilder(); 
            foreach(var item in set)
            {
                builder.Append(item);
            }

            return builder.ToString();
        }

        /// <summary>
        ///  Working with Characters
        /// </summary>

        public static string CapitalizeFirstCharacterInWords(string sentence)
        {
            var array = Regex.Replace(sentence.Trim(), " +", " ").ToLower().Split(" ");

            int i = 0; 
            foreach(var word in array)
            {
               var newWord = word.ToLower().ToCharArray();

                if (newWord[0] <= 122 && newWord[0] >= 87)
                {
                    newWord[0] -= (char)32;
                }

                array[i++] = string.Join("",newWord);

            }

            return string.Join(" ", array);

        }

        /// <summary>
        /// Working with string objects
        /// </summary>
  
        public static string CapitalizeFirstCharacterInWords2(string sentence)
        {
            var array = Regex.Replace(sentence.Trim()," +"," ").ToLower().Split(" ");

            for(int i = 0; i<array.Length; i++)
            {
                array[i] = array[i].Replace(" ","");
                array[i] = array[i].Substring(0, 1).ToUpper() + array[i][1..];
            }

            return string.Join(" ", array);
        }
        

        /// <summary>
        /// using string methods 
        /// </summary>
        public static bool IsAnagram(string word1, string word2)
        {
            if (word2.Length != word1.Length)
            {
                return false;
            }

            foreach (var ch in word1)
            {
                if (word2.Contains(ch))
                {
                  word2 = word2.Remove(word2.IndexOf(ch), 1);
                }
            }

            return word2.Length == 0 ; 
        }
        /// <summary>
        /// Using Array method comparision
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public static bool IsAnagram2(string word1, string word2)
        {
            var w1 = word1.ToCharArray();
            var w2 = word2.ToCharArray();

            Array.Sort(w1);
            Array.Sort(w2);

         return IsEqual(w1, w2);
        }


        /// <summary>
        /// Using pointers from the start and end towards to middle
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome(string x)
        {
            if (x.Length == 1)
            {
                return true;
            }
            int j = x.Length - 1;

            for (int i = 0; i < x.Length; i++)
            {
                if (!(x[i] == x[j--]))
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Using string reversal
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome2(string x)
        {
            var b = x.Reverse();

            var s = string.Join("", b);

            return s == x;
        }
        public static char MostRepeatedCharacter(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new InvalidOperationException();
            }
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            var cha = ' ';
            var highestFrequency = 0;

            foreach (var ch in word)
            {
                if (charCount.ContainsKey(ch))
                {
                    charCount[ch] += 1;
                   
                }
                else
                {
                    charCount.Add(ch, 1);
                }

                if (highestFrequency < charCount[ch])
                {
                    cha = ch;
                    highestFrequency = charCount[ch];
                }
            }

            return cha;
        }
        public static bool IsRotatedStringSimple(string item1, string item2)
        {
            return (item1.Length == item2.Length) && (item1 + item1).Contains(item2);
        }

        public static bool IsRotatedStringLooping(string item1, string item2)
        {
            if(item1.Length != item2.Length)
            {
                return false;
            }
            var array1 = item1.ToCharArray();
            var array2 = item2.ToCharArray();

            int i = 0; 
            while(i <= array1.Length)
            {
                if(IsEqual(array1, array2))
                {
                    return true; 
                }
                ShiftArray(array1);
                i++;
            }


           return false;
        }

        private static bool IsEqual(char[] array1, char[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }
            for (int i = 0; i<array1.Length; i++)
            {
                if(array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true; 
        }

        private static void ShiftArray(char[] array)
        {
            int i = array.Length-1;
            var current = array[^1];

            while(i>=1)
            {
                array[i] = array[i-1];

                i--;
            }

            array[0] = current;
        }
        
    }
    
}
