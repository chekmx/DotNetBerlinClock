using System;

namespace BerlinClock
{
    public static class TimeSpanExtension
    {
        public static Time ToTimeSpan(this string aTime)
        {
            string[] timeParts = aTime.Split(':');

            string hoursString = timeParts[0];
            string minutesString = timeParts[1];
            string secondsString = timeParts[2];

            return new Time(int.Parse(hoursString), int.Parse(minutesString), int.Parse(secondsString));
        }
    }
}
