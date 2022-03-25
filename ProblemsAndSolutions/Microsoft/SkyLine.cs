namespace ProblemsAndSolutions.Microsoft
{
    public class SkyLine
    {
        public static int FindBrushStroke(int [] array)
        {
            int brushstroke = 0;

            for(int i = 1; i< array.Length; i++)
            {
                var diff = array[i] - array[i - 1]; 

                if(diff > 0)
                {
                    brushstroke += diff; 
                }

                if(brushstroke > 1000000000)
                {
                    return -1; 
                }
            }

            return brushstroke; 
        }
    }
}
