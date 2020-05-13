using System;
using System.Collections.Generic;
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
                 new SecondsLampRow(1, BulbColour.Y),
                 new FiveUnitLampRow(4, BulbColour.R),
                 new SingleUnitLampRow(4, BulbColour.R),
                 new FiveUnitLampRow(11, BulbColour.Y, 3, BulbColour.R),
                 new SingleUnitLampRow(4, BulbColour.Y)
            };
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
