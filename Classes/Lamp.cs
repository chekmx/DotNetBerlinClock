namespace BerlinClock
{
    public class Lamp
    {
        public Lamp(BulbColour colour)
        {
            this.Colour = colour;
        }

        public BulbColour Colour { get; }
        public bool IsOn { get; set; }
        public string CurrentColour { get { return IsOn ? Colour.ToString() : "O"; } }
    }
}
