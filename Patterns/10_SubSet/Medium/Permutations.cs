using System;
using System.Collections.Generic;


namespace Patterns._10_SubSet
{
    /// <summary>
    /// Given a set of distinct numbers, find all of its permutations.

    //Permutation is defined as the re-arranging of the elements of the set.For example, {1, 2, 3}
    //has the following six permutations:
    //    Example 1:

    //Input:[1,3,5]
    //Output:[1,3,5], [1,5,3], [3,1,5], [3,5,1], [5,1,3], [5,3,1]
    /// </summary>
    public class Permutations
    {
        public static List<List<int>> Find(int[] nums)
        {
            var list = new List<List<int>>();

            Queue<List<int>> permutations = new();
            permutations.Enqueue(new());


            foreach (int currentNumber in nums)
            {
                // we will take all existing permutations and add the current number to create new permutations
                int n = permutations.Count;
                for (int i = 0; i < n; i++)
                {
                    List<int> oldPermutation = permutations.Dequeue();
                    // create a new permutation by adding the current number at every position
                    for (int j = 0; j <= oldPermutation.Count; j++)
                    {
                        List<int> newPermutation = new(oldPermutation);
                        newPermutation.Insert(j, currentNumber);
                        if (newPermutation.Count == nums.Length)
                            list.Add(newPermutation);
                        else
                            permutations.Enqueue(newPermutation);
                    }
                }
            }


            return list;
        }

        public static List<List<int>> Find2(int[] nums)
        {
            var list = new List<List<int>>();

            list.Add(new());

            foreach(var num in nums)
            {
                int n = list.Count;

                var temp = new List<List<int>>();
                
                for(int i = 0; i<n; i++)
                {
                    var va = list[i];

                    var vn =  va.Count;

                    for(int j = 0; j <= vn; j++)
                    {
                        var trial = new List<int>(va); 

                        trial.Insert(j, num);

                        temp.Add(trial);
                    }
                   
                }

                list = new List<List<int>>(temp); 
            }

            return list; 
        }

        public static List<List<int>> FindRecursive(int[] nums)
        {
            List<List<int>> result = new();
            GeneratePermutationsRecursive(nums, 0, new(), result);
            return result;
        }

        private static void GeneratePermutationsRecursive(int[] nums, int index, List<int> currentPermutation, List<List<int>> result)
        {
            if (index == nums.Length)
            {
                result.Add(currentPermutation);
            }
            else
            {
                // create a new permutation by adding the current number at every position
                for (int i = 0; i <= currentPermutation.Count; i++)
                {
                    List<int> newPermutation = new(currentPermutation);
                    newPermutation.Insert(i, nums[index]);
                    GeneratePermutationsRecursive(nums, index + 1, newPermutation, result);
                }
            }
        }
    }
}
