namespace ProblemsAndSolutions.Microsoft
{
    /// <summary>
    /// Max Inserts to Obtain String Without 3 Consecutive 'a'
    /// </summary>

    public class MaxInsertions
    {
        public static int Number(string str)
        {
            int num = 0;

            int count = 0; 

            for (int i = 0; i< str.Length; i++)
            {
                if(str[i] == 'a')
                {
                    count++;
                }
                else
                {
                    if(count < 2)
                    {
                        str = str.Insert(i, "a");
                        count++;
                        num++;
                    }
                    else
                    {
                        count = 0;
                    }
                }
               
            }

            while(count < 2)
            {
                num++;
                count++;
            }
            return num;
        }
    }
}

