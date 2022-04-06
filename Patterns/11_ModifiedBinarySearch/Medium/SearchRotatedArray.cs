namespace Patterns._11_ModifiedBinarySearch
{
    /// <summary>
    /// Search Rotated Array
    /// </summary>
    public class SearchRotatedArray
    {

         // O(n) + Log(N)
        public static int Find(int[] arr, int key)
        {
            int maxIndex = -1;
            int max = -1;
            for (int i = 0; i < arr.Length - 1; i++)
            {

                if (max < arr[i])
                {
                    maxIndex = i;
                    max = arr[i];
                }
            }

            int first = Bsearch(arr, key, 0, maxIndex);

            if (first != -1)
            {
                return first;
            }
            return Bsearch(arr, key, maxIndex + 1, arr.Length - 1);

        }


        private static int Bsearch(int[] arr, int key, int start, int end)
        {
            while (start <= end)
            {

                int mid = start + (end - start) / 2;

                if (arr[mid] == key)
                {
                    return mid;
                }

                if (arr[mid] > key)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }

            }

            return -1;
        }


        public static int Search(int[] arr, int key)
        {
            int start = 0, end = arr.Length - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (arr[mid] == key)
                    return mid;

                if (arr[start] <= arr[mid])
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