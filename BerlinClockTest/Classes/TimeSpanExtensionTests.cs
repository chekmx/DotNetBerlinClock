using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace BerlinClock.Tests
{
    [TestClass()]
    public class TimeSpanExtensionTests
    {
        [DataRow("00:00:00", "0", "0", "0")]
        [DataRow("24:00:00", "24", "0", "0")]
        [DataTestMethod()]
        public void ToTimeSpanTest(string aTime, string expectedHours, string expectedMinutes, string expectedSeconds)
        {
            var actualTimeSpan = aTime.ToTimeSpan();
            actualTimeSpan.Hours.Should().Be(int.Parse(expectedHours));
            actualTimeSpan.Minutes.Should().Be(int.Parse(expectedMinutes));
            actualTimeSpan.Seconds.Should().Be(int.Parse(expectedSeconds));
        }
    }
}