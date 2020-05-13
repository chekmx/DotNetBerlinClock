using System.Collections.Generic;
using System.Linq;

namespace BerlinClock
{
    public abstract class LampRow : ILampRow
    {
        private TimeUnit timeUnit;

        public LampRow(TimeUnit timeUnit, int bulbCount, BulbColour colour)
        {
            InitializeRow(timeUnit, bulbCount, colour);
        }

        public LampRow(
            TimeUnit timeUnit,
            int bulbCount, 
            BulbColour colour, 
            int? seperationCount, 
            BulbColour sepeartionColour)
        {
            InitializeRow(timeUnit, bulbCount, colour, seperationCount, sepeartionColour);
        }

        private void InitializeRow(
            TimeUnit timeUnit,
            int bulbCount, 
            BulbColour colour, 
            int? seperationCount = null, 
            BulbColour seperationColour = BulbColour.R)
        {
            this.timeUnit = timeUnit; 
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
        
        private int GetTimeUnit(Time time)
        {
            switch (this.timeUnit)
            {
                case TimeUnit.Hour:
                    {
                        return time.Hours;
                    }
                case TimeUnit.Minute:
                    {
                        return time.Minutes;
                    }
                case TimeUnit.Second:
                    {
                        return time.Seconds;
                    }
            }
            return 0;
        }

        public void SwitchOnLamps(Time time)
        {
            int i = 1;
            foreach (Lamp lamp in this.Lamps)
            {
                lamp.IsOn = this.IsLampOn(GetTimeUnit(time), i);
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
