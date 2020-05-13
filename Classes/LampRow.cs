using System;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock
{
    public abstract class LampRow : ILampRow
    {
        public LampRow(int bulbCount, BulbColour colour)
        {
            InitializeRow(bulbCount, colour);
        }

        public LampRow(
            int bulbCount, 
            BulbColour colour, 
            int? seperationCount, 
            BulbColour sepeartionColour)
        {
            InitializeRow(bulbCount, colour, seperationCount, sepeartionColour);
        }

        private void InitializeRow(
            int bulbCount, 
            BulbColour colour, 
            int? seperationCount = null, 
            BulbColour seperationColour = BulbColour.R)
        {
            var lamps = new List<Lamp>();
            for (int i = 1; i <= bulbCount; i++)
            {
                if (seperationCount.HasValue && i % seperationCount.Value == 0)
                {
                    lamps.Add(new Lamp(seperationColour));
                }
                else
                {
                    lamps.Add(new Lamp(colour));
                }
            }
            this.Lamps = lamps;
        }

        public void SwitchOnLamps(int time)
        {
            int i = 1;
            foreach (Lamp lamp in this.Lamps)
            {
                lamp.IsOn = this.IsLampOn(time, i);
                i++;
            }
        }

        protected abstract bool IsLampOn(int time, int lampNumber);

        public IEnumerable<Lamp> Lamps { get; private set; }

        public override string ToString()
        {
            return string.Concat(this.Lamps.Select(l => l.CurrentColour));
        }
    }
}
