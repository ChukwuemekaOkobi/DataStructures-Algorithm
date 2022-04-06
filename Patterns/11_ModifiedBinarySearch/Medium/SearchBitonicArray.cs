namespace Patterns._11_ModifiedBinarySearch
{
    /// <summary>
    /// Given a Bitonic array, find if a given ‘key’ is present in it. An array is considered bitonic if it is 
    /// monotonically increasing and then monotonically decreasing. Monotonically increasing or 
    /// decreasing means that for any index i in the array arr[i] != arr[i+1].
    // Write a function to return the index of the ‘key’. If the ‘key’ appears more than once,
    // return the smaller index.If the ‘key’ is not present, return -1.
    //Example 1:

    //Input: [1, 3, 8, 4, 3], key=4
    //Output: 3
    //Example 2:

    //Input: [3, 8, 3, 1], key=8
    //Output: 1
    //Example 3:

    //Input: [1, 3, 8, 12], key=12
    //Output: 3
    //Example 4:

    //Input: [10, 9, 8], key=10
    //Output: 0
    /// </summary>
    public class SearchBitonicArray
    {

        public static int Search(int[] arr, int key)
        {

            int start = 0;
            int end = arr.Length - 1;

            // find maxpoint in the array 
            while (start < end)
            {
                int mid = start + (end - start) / 2;

                if (arr[mid] > arr[mid + 1])
                {
                    end = mid;

                }
                else
                {
                    start = mid + 1;
                }
            }
            //start = end 
            //search lower 
            int lower = Bsearch(arr, 0, start, key, true);
            int higher = Bsearch(arr, start, arr.Length - 1, key, false);

            if (lower != -1)
            {
                return lower;
            }
            else if (higher != -1)
            {
                return higher;
            }
            return -1;
        }

        private static int Bsearch(int[] arr, int start, int end, int key, bool isLower)
        {

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (arr[mid] == key)
                {
                    return mid;
                }
                else if (isLower)
                {
                    if (arr[mid] < key)
                    {
                        start = mid + 1;
                    }
                    else if (arr[mid] > key)
                    {
                        end = mid - 1;
                    }
                }
                else
                {
                    if (arr[mid] < key)
                    {
                        end = mid - 1;
                    }
                    else if (arr[mid] > key)
                    {
                        start = mid + 1;
                    }
                }
            }
            return -1;
        }


    }
}
