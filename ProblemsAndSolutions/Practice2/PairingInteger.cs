using System.Collections.Generic;

namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// Given an array N, return true if it is possible we can pair all the numbers in the array with equal values. 
    /// E.g N = [1, 2, 2, 1] -> true as we can pair (N[0], N[3]) and (N[1], N[2]). N = [7, 7, 7] would return false.
    /// </summary>
    public class PairingInteger
    {
        public static bool IsPairPossible(int[] nums)
        {
            if(nums.Length % 2 != 0)
            {
                return false;
            }

            Dictionary<int, int> dict = new Dictionary<int, int>(); 

            foreach(var n in nums)
            {
                if (!dict.TryAdd(n, 1))
                {
                    dict[n]++; 
                }
            }

            foreach(var item in dict)
            {
                if(item.Value % 2 != 0)
                {
                    return false;
                }
            }
            return true; 
        }

        public static bool IsPairPossibleSet(int[] nums)
        {
            if (nums.Length % 2 != 0)
            {
                return false;
            }

            HashSet<int> set = new HashSet<int>();

            foreach (var n in nums)
            {
                if (!set.Contains(n))
                {
                    set.Add(n);
                }
                else
                {
                    set.Remove(n);
              
                }
      
            }

            return set.Count == 0; 
        }
    }

}


