using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace BerlinClock.Tests
{
    [TestClass()]
    public class LampTests
    {
        [DataRow("true", "R" , "R")]
        [DataRow("true", "Y", "Y")]
        [DataRow("false", "Y", "O")]
        [DataRow("false", "R", "O")]
        [DataTestMethod()]
        public void LampTest(string isOn, string colour, string expectColour)
        {
            Lamp lamp = new Lamp((BulbColour)Enum.Parse(typeof(BulbColour), colour));
            lamp.IsOn = Boolean.Parse(isOn);

            lamp.CurrentColour.Should().Be(expectColour);
        }
    }
}