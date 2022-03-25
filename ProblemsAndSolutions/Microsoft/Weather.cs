using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsAndSolutions.Microsoft
{
    public class Weather
    {
        public static string MaxAmplitude(int[] array)
        {
            string[] season = { "SPRING" , "SUMMER", "WINTER", "AUTUMN"};

            int maxAmplitude = int.MinValue;


            int period = array.Length / 4;
            int seasonIndex = 0; 


            for(int i = 0; i< 4; i++)
            {
                int min = int.MaxValue;
                int max = int.MinValue;

                int count = 0; 

                while(count < period)
                {
                    int index = i * period + count;
                    min = Math.Min(min, array[index]);
                    max = Math.Max(max, array[index]);
                    count++; 
                }

                if(maxAmplitude < max - min)
                {
                    maxAmplitude = max - min;

                    seasonIndex = i;
                }
            }

            return season[seasonIndex];
        }
    }
}
