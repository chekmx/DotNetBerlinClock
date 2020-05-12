using System;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock
{
    public class LampRow : ILampRow
    {
        private Func<int, int, bool> isOn;

        public LampRow(int bulbCount, BulbColour colour, Func<int, int, bool> isOnFunction)
        {
            InitializeRow(bulbCount, colour, isOnFunction);
        }

        public LampRow(
            int bulbCount, 
            BulbColour colour, 
            Func<int, int, bool> isOnFunction, 
            int? seperationCount, 
            BulbColour sepeartionColour)
        {
            InitializeRow(bulbCount, colour, isOnFunction, seperationCount, sepeartionColour);
        }

        private void InitializeRow(
            int bulbCount, 
            BulbColour colour, 
            Func<int, int, bool> isOnFunction, 
            int? seperationCount = null, 
            BulbColour seperationColour = BulbColour.R)
        {
            this.isOn = isOnFunction;
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
                lamp.IsOn = this.isOn(time, i);
                i++;
            }
        }

        public IEnumerable<Lamp> Lamps { get; private set; }

        public override string ToString()
        {
            return string.Concat(this.Lamps.Select(l => l.CurrentColour));
        }
    }
}
