namespace BerlinClock
{
    public class SingleUnitLampRow : LampRow
    {
        public SingleUnitLampRow(TimeUnit timeUnit, int bulbCount, BulbColour colour)
            : base(timeUnit, bulbCount, colour)
        { }

        protected override bool IsLampOn(int time, int lampNumber)
        {
            return time % 5 >= lampNumber;
        }
    }
}
