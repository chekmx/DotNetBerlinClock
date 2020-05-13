namespace BerlinClock
{
    public class SingleUnitLampRow : LampRow
    {
        public SingleUnitLampRow(int bulbCount, BulbColour colour)
            : base(bulbCount, colour)
        { }

        protected override bool IsLampOn(int time, int lampNumber)
        {
            return time % 5 >= lampNumber;
        }
    }
}
