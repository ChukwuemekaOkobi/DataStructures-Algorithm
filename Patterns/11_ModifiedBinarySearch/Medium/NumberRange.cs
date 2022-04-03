namespace Patterns._11_ModifiedBinarySearch
{
    /// <summary>
    /// Given an array of numbers sorted in ascending order, find the range of a given number ‘key’. The range of the ‘key’ will be the first and last position of the ‘key’ in the array.

    //    Write a function to return the range of the ‘key’. If the ‘key’ is not present return [-1, -1].

    //Example 1:

    //Input: [4, 6, 6, 6, 9], key = 6
    //Output: [1, 3]
    //    Example 2:

    //Input: [1, 3, 8, 10, 15], key = 10
    //Output: [3, 3]
    //    Example 3:

    //Input: [1, 3, 8, 10, 15], key = 12
    //Output: [-1, -1]
    /// </summary>
    public class NumberRange
    {
        public static int[] FindRange(int[] arr, int key)
        {
            int[] result = new int[] { -1, -1 };
            
            if(key > arr[^1])
            {
                return result; 
            }

            result[0] = Search(arr, key, false);

            if (result[0] != -1) // no need to search, if 'key' is not present in the input array
                result[1] = Search(arr, key, true);

            return result;
        }

        private static int Search(int [] arr, int key, bool findMaxIndex)
        {
            int keyIndex = -1;
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == key)
                {
                    keyIndex = mid;
                    if (findMaxIndex)
                        left = mid + 1; // search ahead to find the last index of 'key'
                    else
                        right = mid - 1;
                }

                if (arr[mid] > key)
                {
                    right = mid - 1;
                }
                else if (arr[mid] < key)
                {
                    left = mid + 1;
                }
            }
            return keyIndex;
        }
    }
}
