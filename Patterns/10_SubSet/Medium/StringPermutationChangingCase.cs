using System.Collections.Generic;
using System.Text;

namespace Patterns._10_SubSet
{
    /// <summary>
    /// Example 1:

    //    Input: "ad52"
    //Output: "ad52", "Ad52", "aD52", "AD52" 
    //Example 2:

    //Input: "ab7c"
    //Output: "ab7c", "Ab7c", "aB7c", "AB7c", "ab7C", "Ab7C", "aB7C", "AB7C"
    /// </summary>

    public class StringPermutationChangingCase
    {
        public static List<string> Find(string str)
        {
            List<string> permutations = new List<string>();

            permutations.Add(string.Empty);

            foreach (char ch in str)
            {
                var n = permutations.Count;

                if (char.IsDigit(ch))
                {
                    for (int i = 0; i < n; i++)
                    {
                        permutations[i] += ch;
                    }
                }
                else
                {
                    List<string> tempString = new();

                    for (int i = 0; i < n; i++)
                    {
                        var lower = permutations[i] + char.ToLower(ch);
                        var higher = permutations[i] + char.ToUpper(ch);

                        tempString.Add(lower);
                        tempString.Add(higher);
                    }

                    permutations = new List<string>(tempString);
                }
            }
            return permutations;
        }


        public static List<string> Find2(string str)
        {
            List<string> permutations = new();
            if (string.IsNullOrWhiteSpace(str))
                return permutations;

            permutations.Add(str);
            // process every character of the string one by one
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                { // only process characters, skip digits
                  // we will take all existing permutations and change the letter case appropriately
                    int n = permutations.Count;
                    for (int j = 0; j < n; j++)
                    {

                        char[] chs = permutations[j].ToCharArray();
                        // if the current character is in upper case change it to lower case or vice versa
                        if (char.IsUpper(chs[i]))
                            chs[i] = char.ToLower(chs[i]);
                        else
                            chs[i] = char.ToUpper(chs[i]);

                        var builder = new StringBuilder();
                        foreach(var ch in chs)
                        {
                            builder.Append(ch);
                        }
                        permutations.Add(builder.ToString() ) ;
                    }
                }
            }
            return permutations;
        }
    }
}
