using System;
using System.Globalization;

namespace BerlinClock
{
    public static class TimeSpanExtension
    {
        public static Time ToTimeSpan(this string aTime)
        {
            string[] timeParts = aTime.Split(':');

            if (timeParts.GetUpperBound(0) != 2)
            {
                throw new FormatException();
            }

            int hour = getUnit(timeParts[0], 0, 24);
            int minutes = getUnit(timeParts[1], 0, 59);
            int seconds = getUnit(timeParts[2], 0, 59);
            
            if(hour == 24 && (minutes > 0 || seconds > 0 ))
            {
                throw new ArgumentOutOfRangeException();
            }

            return new Time(hour, minutes, seconds);
        }

        private static int getUnit(string timeString, int min, int  max)
        {
            int time;

            if(!int.TryParse(timeString, out time))
            {
                throw new FormatException();
            }

            if(time < min || time > max)
            {
                throw new ArgumentOutOfRangeException();
            }

            return time;
        }
    }
}
