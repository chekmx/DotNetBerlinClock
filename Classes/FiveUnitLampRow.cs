namespace BerlinClock
{
    public class FiveUnitLampRow : LampRow
    {
        public FiveUnitLampRow(int bulbCount, BulbColour colour)
            : base(bulbCount, colour)
        { }

        public FiveUnitLampRow(int bulbCount, BulbColour colour, int? seperationCount, BulbColour seperationColour)
           : base(bulbCount, colour, seperationCount, seperationColour)
        { }

        protected override bool IsLampOn(int time, int lampNumber)
        {
            return time / 5 >= lampNumber;
        }
    }
}
