using System.Collections.Generic;

namespace Patterns._2_TwoPointers
{
    /// <summary>
    /// QUESTION: Subarrays with Product Less than a Target
    /// Given an array with positive numbers and a positive target number,
    /// find all of its contiguous subarrays whose product is less than the target number.
    /// 
    /// Example 1:
    /// Input: [2, 5, 3, 10], target=30 
    /// Output: [2], [5], [2, 5], [3], [5, 3], [10]
    /// Explanation: There are six contiguous subarrays whose product is less than the target.
    /// 
    /// Example 2:
    /// Input: [8, 2, 6, 5], target= 50
    /// Output: [8], [2], [8, 2], [6], [2, 6], [5], [6, 5]
    /// Explanation: There are seven contiguous subarrays whose product is less than the target.
    /// </summary>
    public class SubarrayswithProductLessthanTarget
    {
        public static List<List<int>> FindSubarrays(int[] arr, int target)
        {
            List<List<int>> subarrays = new ();

            double hold = 1;
            int left = 0; 

            for(int right=0; right< arr.Length; right++)
            {
                hold *= arr[right]; 

                while(hold >=target && left < arr.Length){
                    hold /= arr[left++];
                    // since the product of all numbers from left to right is less than the target therefore,
                    // all subarrays from left to right will have a product less than the target too; to avoid
                    // duplicates, we will start with a subarray containing only arr[right] and then extend it
                }

                var list = new List<int>();
                for (int i = right; i >= left; i--)
                {
                    list.Insert(0,arr[i]);
                    subarrays.Add( new List<int>(list));
                }

            }

            
            return subarrays;
        }
    }
}
