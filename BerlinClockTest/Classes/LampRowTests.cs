using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.Tests
{
    [TestClass()]
    public class LampRowTests
    {
        [DataRow(4, "R", "", 0, "OOOO")]
        [DataTestMethod()]
        public void ToStringTest(int bulbcount, string bulbColour, string functionName, int time, string expected)
        {
            var colour = (BulbColour)Enum.Parse(typeof(BulbColour), bulbColour);

            LampRow lampRow = new LampRow(bulbcount, colour, null);
            lampRow.SwitchOnLamps(time);
            lampRow.ToString().Should().Be(expected);
        }
    }
}