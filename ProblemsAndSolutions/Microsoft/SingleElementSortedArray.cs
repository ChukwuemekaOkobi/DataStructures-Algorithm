namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// given an array of duplicate elements find the single 
    /// element in the array 
    /// in log(N) and O(1) space 
    /// input: [2,2,3,3,4,5,5,6,6]
    /// output: 4
    /// </summary>
    public class SingleElementSortedArray
    {

        /// <summary>
        /// Two pointers moving in steps of 2
        /// O(N)
        /// </summary>
  
        public static int ItemTwoPointer(int[] nums)
        {
            int left = 0;
            int right = 1;

            while (right < nums.Length)
            {
                if (nums[left] == nums[right])
                {
                    left += 2;
                    right += 2;
                }
                else
                {
                    return nums[left];
                }
            }

            return nums[left];
        }

        /// <summary>
        ///  Using Binary Search 
        ///  O(Log N)
        /// </summary>

        public static int ItemBinarySearch(int [] nums)
        {
            int left = 0, right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                bool isEven = (mid - left) % 2 == 0;

                if (nums[mid] == nums[mid - 1])
                {

                    if (isEven)
                    {
                        right = mid - 2;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else if (nums[mid] == nums[mid + 1])
                {

                    if (isEven)
                    {
                        left = mid + 2;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else
                    return nums[mid];
            }

            return nums[left];
        }
    }




}

