namespace Patterns._11_ModifiedBinarySearch
{
    /// <summary>
    /// How do we search in a sorted and rotated array that also has duplicates?

    //The code above will fail in the following example!

    //Example 1:

    //Input: [3, 7, 3, 3, 3], key = 7
    //Output: 1
    //Explanation: '7' is present in the array at index '1'.
    /// </summary>
    public class SearchRotatedArrayDuplicate
    {
        public static int Search(int [] arr, int key)
        {
            int start = 0, end = arr.Length - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (arr[mid] == key)
                    return mid;

                // the only difference from the previous solution,
                // if numbers at indexes start, mid, and end are same, we can't choose a side
                // the best we can do, is to skip one number from both ends as key != arr[mid]
                if ((arr[start] == arr[mid]) && (arr[end] == arr[mid]))
                {
                    ++start;
                    --end;
                }
                else if (arr[start] <= arr[mid])
                { // left side is sorted in ascending order
                    if (key >= arr[start] && key < arr[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    { //key > arr[mid]
                        start = mid + 1;
                    }
                }
                else
                { // right side is sorted in ascending order
                    if (key > arr[mid] && key <= arr[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }

            // we are not able to find the element in the given array
            return -1;
        }
    }
}