namespace Algorithms.Sorting
{
    /// <summary>
    /// Divide and conquer, first divide the array in into 2 
    /// sort the left and right then merge left and right 
    /// repeat recursively 
    /// </summary>
    public class MergeSort
    {
        public static void Sort(int[] items)
        {
            if(items.Length == 1)
            {
                return;
            }
            //divide
            int middle = items.Length / 2;

            int[] left = new int[middle];

            int[] right = new int[items.Length - middle];


            for(var i = 0; i< middle; i++)
            {
                left[i] = items[i];
            }

            for(var i = middle; i< items.Length; i++)
            {
                right[i - middle] = items[i];
            }

            Sort(left);
            Sort(right);

            Merge(left, right, items);
        }

        private static void Merge(int[] left, int[] right, int[] original)
        {
            int i = 0, j = 0, k = 0; 

            while(i < left.Length && j < right.Length)
            {
                if(left[i] <= right[j])
                {
                    original[k++] = left[i++];
                }
                else
                {
                    original[k++] = right[j++];
                }
            }

            while (i < left.Length)
            {
                original[k++] = left[i++];
            }
            while (j < right.Length)
            {
                original[k++] = right[j++];
            }

        }
        
    }
}
