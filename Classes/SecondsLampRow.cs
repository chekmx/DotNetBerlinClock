namespace BerlinClock
{
    public class SecondsLampRow: LampRow
    {
        public SecondsLampRow(int bulbCount, BulbColour colour)
            : base(bulbCount, colour)
        { }

        protected override bool IsLampOn(int time, int lampNumber)
        {
            return time % 2 == 0;
        }
    }
}
