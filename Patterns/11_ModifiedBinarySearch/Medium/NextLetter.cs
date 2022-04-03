namespace Patterns._11_ModifiedBinarySearch
{
    /// <summary>
    /// Given an array of lowercase letters sorted in ascending order, find the smallest letter in the given array greater than a given ‘key’.

    //    Assume the given array is a circular list, which means that the last letter is assumed
    //    to be connected with the first letter.This also means that the smallest letter in the given array is greater than the last letter of the array and is also the first letter of the array.
    //    Write a function to return the next letter of the given ‘key’.

    //    Example 1:
    //    Input: ['a', 'c', 'f', 'h'], key = 'f'
    //    Output: 'h'
    //Explanation: The smallest letter greater than 'f' is 'h' in the given array.
    //    Example 2:
    //    Input: ['a', 'c', 'f', 'h'], key = 'b'
    //    Output: 'c'
    //Explanation: The smallest letter greater than 'b' is 'c'.
    //Example 3:
    //    Input: ['a', 'c', 'f', 'h'], key = 'm'
    //    Output: 'a'
    //Explanation: As the array is assumed to be circular, the smallest letter greater than 'm' is 'a'.
    //Example 4:
    //    Input: ['a', 'c', 'f', 'h'], key = 'h'
    //    Output: 'a'
    //Explanation: As the array is assumed to be circular, the smallest letter greater than 'h' is 'a'.
    /// </summary>

    public class NextLetter
    {
        public static char SearchNextLetter(char[] array, char key)
        {
            int left = 0;
            int right = array.Length - 1;

            if(key >= array[^1])
            {
                return array[left];
            }

            while(left <= right)
            {
                int mid = left + (right - left) / 2;

                if(array[mid] == key)
                {
                    return array[mid + 1];
                }

                if(array[mid] < key)
                {
                    left = mid + 1; 
                }
                else
                {
                    right = mid - 1; 
                }
            }

            return array[left];
        }
    }
}
