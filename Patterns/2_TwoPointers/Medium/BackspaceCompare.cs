﻿namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// Comparing Strings containing Backspaces (medium)#
    //  Given two strings containing backspaces(identified by the character ‘#’), check if the two strings are equal.

    //    Example 1:
    //    Input: str1= "xy#z", str2= "xzz#"
    //    Output: true
    //    Explanation: After applying backspaces the strings become "xz" and "xz" respectively.

    //    Example 2:
    //    Input: str1= "xy#z", str2= "xyz#"
    //    Output: false
    //    Explanation: After applying backspaces the strings become "xz" and "xy" respectively.

    //    Example 3:
    //    Input: str1= "xp#", str2= "xyz##"
    //    Output: true
    //    Explanation: After applying backspaces the strings become "x" and "x" respectively.
    //    In "xyz##", the first '#' removes the character 'z' and the second '#' removes the character 'y'.
    /// </summary>
    public class BackspaceCompare
    {

        public static bool Compare(string str1, string str2)
        {

            return Delete(str1) == Delete(str2);

            static string Delete(string str)
            {

                int left = -1;
                int right = 0;

                while (right < str.Length)
                {

                    if (str[right] == '#' && left != -1)
                    {
                        str = str.Remove(left, 2);
                        
                        left--; right--;
                    }
                    else
                    {
                        left++; right++;
                    }

                }
                return str;
            }
        }
        public static bool Compare2(string str1, string str2)
        {
            // use two pointer approach to compare the strings
            int index1 = str1.Length - 1, index2 = str2.Length- 1;

            while (index1 >= 0 || index2 >= 0)
            {

                int i1 = getNextValidCharIndex(str1, index1);
                int i2 = getNextValidCharIndex(str2, index2);

                if (i1 < 0 && i2 < 0) // reached the end of both the strings
                    return true;

                if (i1 < 0 || i2 < 0) // reached the end of one of the strings
                    return false;

                if (str1[i1] != str2[i2]) // check if the characters are equal
                    return false;

                index1 = i1 - 1;
                index2 = i2 - 1;
            }

            return true;

            static int getNextValidCharIndex(string str, int index)
            {
                int backspaceCount = 0;
                while (index >= 0)
                {
                    if (str[index] == '#') // found a backspace character
                        backspaceCount++;
                    else if (backspaceCount > 0) // a non-backspace character
                        backspaceCount--;
                    else
                        break;

                    index--; // skip a backspace or a valid character
                }
                return index;
            }
        }

    }
}
