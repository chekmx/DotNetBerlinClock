using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.Tests
{
    [TestClass()]
    public class FiveUnitLampRowTests
    {
        [DataRow(4, "R", 0, "OOOO")]
        [DataRow(4, "R", 4, "OOOO")]
        [DataRow(4, "R", 5, "ROOO")]
        [DataRow(4, "R", 9, "ROOO")]
        [DataRow(4, "R", 10, "RROO")]
        [DataRow(4, "R", 14, "RROO")]
        [DataRow(4, "R", 15, "RRRO")]
        [DataRow(4, "R", 20, "RRRR")]
        [DataTestMethod()]
        public void ToStringTest(int bulbcount, string bulbColour, int time, string expected)
        {
            var colour = (BulbColour)Enum.Parse(typeof(BulbColour), bulbColour);

            ILampRow lampRow = new FiveUnitLampRow(TimeUnit.Minute, bulbcount, colour);
            lampRow.SwitchOnLamps(new Time(0, time, 0));
            lampRow.ToString().Should().Be(expected);
        }
    }
}