namespace Algorithms.Sorting
{
    /// <summary>
    /// This starts from the begining of the array 
    /// and compare the values if its smaller then shifting the other items to the
    ///  right and inserts the smaller value to the left. 
    /// </summary>
    public class InsertionSort
    {
        public static void Sort(int[] items)
        {


            for (int i = 1; i < items.Length; i++)
            {
                var current = items[i];

                var j = i - 1;
                while (j >= 0 && items[j]> current)
                {
                    items[j + 1] = items[j];
                    j--;
                }
                items[j + 1] = current;
                
            }
        }

       
    }
}
