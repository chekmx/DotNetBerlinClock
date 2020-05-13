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
                 new SecondsLampRow(TimeUnit.Second, 1, BulbColour.Y),
                 new FiveUnitLampRow(TimeUnit.Hour, 4, BulbColour.R),
                 new SingleUnitLampRow(TimeUnit.Hour,4, BulbColour.R),
                 new FiveUnitLampRow(TimeUnit.Minute, 11, BulbColour.Y, 3, BulbColour.R),
                 new SingleUnitLampRow(TimeUnit.Minute, 4, BulbColour.Y)
            };
        }

        public string ConvertTime(string aTime)
        {
            var time = aTime.ToTimeSpan();
            this.lampRows.ForEach(l => l.SwitchOnLamps(time));
            return string.Join(Environment.NewLine, this.lampRows.Select(l => l.ToString()));
        }
    }
}
