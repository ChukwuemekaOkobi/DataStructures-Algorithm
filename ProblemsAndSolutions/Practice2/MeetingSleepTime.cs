using System;
using System.Collections.Generic;

namespace ProblemsAndSolutions.Microsoft
{
    public class MeetingSleepTime
    {
        public static int MaxSleepPeriod(string str)
        {
            int MinutesInWeek = 7 * 24 * 60;

            if (string.IsNullOrWhiteSpace(str))
            {
                return MinutesInWeek; 
            }

            var periods = ConvertTime(str);

            int maxTime = 0;

            periods.Sort();

            for(int i = 1; i< periods.Count; i++)
            {
                maxTime = Math.Max(maxTime, periods[i].Start - periods[i - 1].End);
            }

            maxTime = Math.Max(maxTime, periods[0].Start - 0);
            maxTime = Math.Max(maxTime, MinutesInWeek - periods[^1].End);


            return maxTime; 
        }


        private static List<TimeInterval> ConvertTime(string str)
        {
            var convert = new List<TimeInterval>();

            var dictionary = new Dictionary<string, int>()
            {
                {"Mon", 0 },
                {"Tue",1 },
                {"Wed", 2},
                {"Thu",3 },
                {"Fri",4 },
                {"Sat",5 },
                {"Sun",6 }
            };

            var periods = str.Split('\n'); 

            foreach(var period in periods)
            {
                var timeDay = period.Split(' ');

                var day = dictionary[timeDay[0]];

                var time = timeDay[1].Split('-');

                var start = ConverttoMinutes(day, time[0]);
                var end = ConverttoMinutes(day, time[1]);

                convert.Add(new TimeInterval(start, end));
            }

            return convert; 
        }


        private static int ConverttoMinutes(int day, string interval)
        {
            var hourmin = interval.Split(':');

            var hour = int.Parse(hourmin[0]);
            var min = int.Parse(hourmin[1]);

            return day * 24 * 60 + hour * 60 + min; 
        }


        protected class TimeInterval : IComparable<TimeInterval>
        {
            public int Start { get; set; }
            public int End { get; set; }

            public TimeInterval(int start, int end)
            {
                Start = start;
                End = end; 
            }

            public int CompareTo(TimeInterval other)
            {
                return Start - other.Start;
            }
        }
    }
}
