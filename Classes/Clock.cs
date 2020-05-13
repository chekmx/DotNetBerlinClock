using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BerlinClock
{
    public class Clock
    {
        private List<ILampRow> lampRows;
        public Clock()
        {
            this.lampRows = new List<ILampRow>()
            {
                 new LampRow(1, BulbColour.Y, SecondsOn),
                 new LampRow(4, BulbColour.R, FiveHourBlocksOn),
                 new LampRow(4, BulbColour.R, SingleHourBlocksOn),
                 new LampRow(11, BulbColour.Y, FiveHourBlocksOn, 3, BulbColour.R),
                 new LampRow(4, BulbColour.Y, SingleHourBlocksOn)
            };
        }

        private static bool SecondsOn(int seconds, int lampNumber)
        {
            return seconds % 2 == 0;
        }

        private static bool FiveHourBlocksOn(int hours, int lampNumber)
        {
            return hours / 5  >= lampNumber;
        }

        private static bool SingleHourBlocksOn(int hours, int lampNumber)
        {
            return hours % 5 >= lampNumber;
        }

        public string ConvertTime(string aTime)
        {
            var timeSpan = aTime.ToTimeSpan();
            this.lampRows[0].SwitchOnLamps(timeSpan.Seconds);
            this.lampRows[1].SwitchOnLamps(timeSpan.Hours);
            this.lampRows[2].SwitchOnLamps(timeSpan.Hours);
            this.lampRows[3].SwitchOnLamps(timeSpan.Minutes);
            this.lampRows[4].SwitchOnLamps(timeSpan.Minutes);

            return string.Join(Environment.NewLine, this.lampRows.Select(l => l.ToString()));
        }
    }
}
