namespace BerlinClock
{
    public class SecondsLampRow: LampRow
    {
        public SecondsLampRow(TimeUnit timeUnit, int bulbCount, BulbColour colour)
            : base(timeUnit, bulbCount, colour)
        { }

        protected override bool IsLampOn(int time, int lampNumber)
        {
            return time % 2 == 0;
        }
    }
}
