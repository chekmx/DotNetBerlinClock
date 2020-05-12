﻿using System;
using System.Linq;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            //split string into hours and minutes

            var clock = new Clock(aTime);
            //convert to string
            return clock.Time;
        }
    }
}
