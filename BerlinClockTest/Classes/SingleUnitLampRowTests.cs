using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.Tests
{
    [TestClass()]
    public class SingleUnitLampRowTests
    {
        [DataRow(4, "Y", 0, "OOOO")]
        [DataRow(4, "Y", 1, "YOOO")]
        [DataRow(4, "Y", 4, "YYYY")]
        [DataRow(4, "Y", 5, "OOOO")]
        [DataRow(4, "Y", 6, "YOOO")]
        [DataTestMethod()]
        public void ToStringTest(int bulbcount, string bulbColour, int time, string expected)
        {
            var colour = (BulbColour)Enum.Parse(typeof(BulbColour), bulbColour);

            ILampRow lampRow = new SingleUnitLampRow(TimeUnit.Hour, bulbcount, colour);
            lampRow.SwitchOnLamps(new Time(time, 0, 0));
            lampRow.ToString().Should().Be(expected);
        }
    }
}