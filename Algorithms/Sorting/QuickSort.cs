namespace Algorithms.Sorting
{
    /// <summary>
    /// create a pivot usually the last or first element in the array 
    /// then partition the array by loop through an adding values smaller than the 
    /// pivot to  the left partition and moving the pivot to the right place recursively
    /// </summary>
    public class QuickSort
    {
        //partition array 
        //sort left
        //sort right
        public static void Sort(int[] items)
        {
            Sort(items, 0, items.Length - 1);
        }
        private static void Sort(int[] items, int start, int end)
        {
            if(start>=end)
            {
                return;
            }
            var boundary = Partition(items, start, end);

            //sort left
            Sort(items, start, boundary - 1);

            //sort right
            Sort(items, boundary + 1, end);
        }

        private static int Partition (int[] items, int start, int end)
        {
            var pivot = items[end];
            var boundary = start-1; 

            for(int i = start; i<=end ; i++)
            {
                if(items[i]<= pivot)
                {
                    Swap(ref items[++boundary], ref items[i]); 
                }
            }
            return boundary;
        }
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;

        }
    }
}
