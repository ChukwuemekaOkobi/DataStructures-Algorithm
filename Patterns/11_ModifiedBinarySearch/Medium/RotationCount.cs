namespace Patterns._11_ModifiedBinarySearch
{
    /// <summary>
    /// Count the number of rotations
    /// </summary>

    public class RotationCount
    {
        //O(N)
        public static int CountRotations(int[] arr)
        {
            // TODO: Write your code here
            int index = -1;
            int max = -1;

            if (arr[0] < arr[^1])
            {
                return 0;
            }

            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] > max)
                {
                    max = arr[i];
                    index = i;
                }
            }


            return index + 1;
        }


        /// <summary>
        /// Log(N)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int CountRotations2(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;

            if (arr[start] < arr[end])
            {
                return 0;
            }

            while (start < end)
            {
                int mid = start + (end - start) / 2;

                if (arr[start] < arr[mid]) // left is sorted
                {
                    start = mid;
                }
                else
                {
                    end = mid;
                }
            }


            return start + 1;
        }
        public static int CountRotations3(int[] arr)
        {
            int start = 0, end = arr.Length - 1;
            while (start < end)
            {
                int mid = start + (end - start) / 2;

                if (mid < end && arr[mid] > arr[mid + 1]) // if mid is greater than the next element
                    return mid + 1;
                if (mid > start && arr[mid - 1] > arr[mid]) // if mid is smaller than the previous element
                    return mid;

                if (arr[start] < arr[mid])
                { // left side is sorted, so the pivot is on right side
                    start = mid + 1;
                }
                else
                { // right side is sorted, so the pivot is on the left side     
                    end = mid - 1;
                }
            }

            return 0; // the array has not been rotated
        }


        public static int CountRotationsWithDuplicate(int[] arr)
        {
         
            int start = 0, end = arr.Length - 1;
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (mid < end && arr[mid] > arr[mid + 1]) // if element at mid is greater than the next element
                    return mid + 1;
                if (mid > start && arr[mid - 1] > arr[mid]) // if element at mid is smaller than the previous element
                    return mid;

                // this is the only difference from the previous solution
                // if numbers at indices start, mid, and end are same, we can't choose a side
                // the best we can do is to skip one number from both ends if they are not the smallest number
                if (arr[start] == arr[mid] && arr[end] == arr[mid])
                {
                    if (arr[start] > arr[start + 1]) // if element at start+1 is not the smallest
                        return start + 1;
                    ++start;
                    if (arr[end - 1] > arr[end]) // if the element at end is not the smallest
                        return end;
                    --end;
                    // left side is sorted, so the pivot is on right side
                }
                else if (arr[start] < arr[mid] || (arr[start] == arr[mid] && arr[mid] > arr[end]))
                {
                    start = mid + 1;
                }
                else
                { // right side is sorted, so the pivot is on the left side     
                    end = mid - 1;
                }
            }

            return 0; // the array has not been rotated
        }
    }
}