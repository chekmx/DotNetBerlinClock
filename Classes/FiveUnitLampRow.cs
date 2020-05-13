namespace BerlinClock
{
    public class FiveUnitLampRow : LampRow
    {
        public FiveUnitLampRow(TimeUnit timeUnit, int bulbCount, BulbColour colour)
            : base(timeUnit, bulbCount, colour)
        { }

        public FiveUnitLampRow(TimeUnit timeUnit, int bulbCount, BulbColour colour, int? seperationCount, BulbColour seperationColour)
           : base(timeUnit, bulbCount, colour, seperationCount, seperationColour)
        { }

        protected override bool IsLampOn(int time, int lampNumber)
        {
            return time / 5 >= lampNumber;
        }
    }
}
