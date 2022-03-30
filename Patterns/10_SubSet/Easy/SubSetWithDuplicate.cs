using System;
using System.Collections.Generic;

namespace Patterns._10_SubSet
{
    /// <summary>
    /// Given a set of numbers that might contain duplicates, find all of its distinct subsets.

    //    Example 1:

    //Input: [1, 3, 3]
    //    Output: [], [1], [3], [1,3], [3,3], [1,3,3]
    //    Example 2:

    //Input: [1, 5, 3, 3]
    //    Output: [], [1], [5], [3], [1,5], [1,3], [5,3], [1,5,3], [3,3], [1,3,3], [3,3,5], [1,5,3,3]
    /// </summary>
    public class SubSetWithDuplicate
    {
        public static List<List<int>> Find(int [] nums)
        {
            Array.Sort(nums);

            var subsets = new List<List<int>>();

            subsets.Add(new());
            int endIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int startIndex = 0;
                // if current and the previous elements are same, create new subsets only from the subsets 
                // added in the previous step
                if (i > 0 && nums[i] == nums[i - 1])
                    startIndex = endIndex + 1;
                endIndex = subsets.Count -1;
                for (int j = startIndex; j <= endIndex; j++)
                {
                    // create a new subset from the existing subset and add the current element to it
                    List<int> set = new (subsets[j]);
                    set.Add(nums[i]);
                    subsets.Add(set);
                }
            }

            return subsets;


        }
    }
}
