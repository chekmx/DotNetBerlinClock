using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.Tests
{
    [TestClass()]
    public class SecondsLampRowTests
    {
        [DataRow(1, "Y", 0, "Y")]
        [DataRow(1, "Y", 1, "O")]
        [DataRow(1, "Y", 2, "Y")]
        [DataRow(1, "Y", 3, "O")]
        [DataRow(1, "Y", 4, "Y")]
        [DataTestMethod()]
        public void ToStringTest(int bulbcount, string bulbColour, int time, string expected)
        {
            var colour = (BulbColour)Enum.Parse(typeof(BulbColour), bulbColour);

            ILampRow lampRow = new SecondsLampRow(bulbcount, colour);
            lampRow.SwitchOnLamps(time);
            lampRow.ToString().Should().Be(expected);
        }
    }
}