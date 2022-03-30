using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns._10_SubSet
{
    /// <summary>
    /// List all Subsets in an array
    /// </summary>
    public class ListSubSet
    {
        public static List<List<int>> List(int [] array)
        {
            var list = new List<List<int>>();

            list.Add(new());


            for(int i = 0; i < array.Length; i++)
            {
                var n = list.Count;   
                for(int j = 0; j < n; j++)
                {
                    var temp = new List<int>(list[j]);
                    temp.Add(array[i]);
                    list.Add(temp);
                }
            }

            return list;
        }
    }
}
