using System;
using System.Linq;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            //split string into hours and minutes
            try
            {
                var clock = new Clock();
                //convert to string
                return clock.ConvertTime(aTime);
            }
            catch (FormatException)
            {
                return string.Format("Cannot translate '{0}' into a time", aTime);
            }
            catch (ArgumentOutOfRangeException)
            {
                return string.Format("Cannot translate '{0}' into a time as it has out of range values", aTime);
            }
            catch (Exception)
            {
                return string.Format("Cannot translate '{0}' into a time as it encountered an expected excpetion", aTime);
            }
        }
    }
}
