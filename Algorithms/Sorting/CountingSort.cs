using System.Linq;

namespace Algorithms.Sorting
{
    /// <summary>
    /// loop through the array and count the values 
    /// loop throught the counts array and populate the original 
    /// array with the recorded counts 
    /// </summary>

    public class CountingSort
    {
        
        public static void Sort(int[] items)
        {
            int[] counts = new int[items.Max()+1];

            foreach(var item in items)
            {
                counts[item]++;
            }

            var j = 0; 
            for(int i = 0; i< counts.Length; i++)
            {
                while (counts[i] > 0)
                {
                    items[j++] = i;
                    counts[i]--;
                }
            }
        }
    }
}
