using System.Collections.Generic;
using System.Text;

namespace Patterns._10_SubSet
{
    public class UniqueGeneralizedAbbreviations
    {
        public static List<string> GenerateGeneralizedAbbreviation(string word)
        {
            int wordLen = word.Length;
            List<string> result = new ();
            Queue<AbbreviatedWord> queue = new ();
            queue.Enqueue(new AbbreviatedWord(new StringBuilder(), 0, 0));
            while (queue.Count != 0)
            {
                AbbreviatedWord abWord = queue.Dequeue();
                if (abWord.Start == wordLen)
                {
                    if (abWord.Count != 0)
                        abWord.Str.Append(abWord.Count);
                    result.Add(abWord.Str.ToString());
                }
                else
                {
                    // continue abbreviating by incrementing the current abbreviation count
                    queue.Enqueue(new AbbreviatedWord(new StringBuilder(abWord.Str.ToString()), abWord.Start + 1, abWord.Count + 1));

                    // restart abbreviating, append the count and the current character to the string
                    if (abWord.Count != 0)
                        abWord.Str.Append(abWord.Count);
                    queue.Enqueue(
                        new AbbreviatedWord(new StringBuilder(abWord.Str.ToString()).Append(word[abWord.Start]), abWord.Start + 1, 0));
                }
            }

            return result;
        }

        public static List<string> GenerateGeneralizedAbbreviation2(string word)
        {
            List<string> result = new ();
            GenerateAbbreviationRecursive(word, new StringBuilder(), 0, 0, result);
            return result;
        }

        private static void GenerateAbbreviationRecursive(string word, StringBuilder abWord, int start, int count,
            List<string> result)
        {

            if (start == word.Length)
            {
                if (count != 0)
                    abWord.Append(count);
                result.Add(abWord.ToString());
            }
            else
            {
                // continue abbreviating by incrementing the current abbreviation count
                GenerateAbbreviationRecursive(word, new StringBuilder(abWord.ToString()), start + 1, count + 1, result);

                // restart abbreviating, append the count and the current character to the string
                if (count != 0)
                    abWord.Append(count);
                GenerateAbbreviationRecursive(word, new StringBuilder(abWord.ToString()).Append(word[start]), start + 1, 0, result);
            }
        }
        class AbbreviatedWord
        {
            public StringBuilder Str { get; set; }
            public int Start { get; set; }
            public int Count { get; set; }

            public AbbreviatedWord(StringBuilder str, int start, int count)
            {
                Str = str;
                Start = start;
                Count = count;
            }
        }
    }
}