using BerlinClock.DomainFacade.TimeDomain;
using NUnit.Framework;

namespace BerlinClock.Tests.UnitTests
{
    [TestFixture]
    public class TimeFacadeTests
    {
        [Test]
        public void GetTimeProperlyFetchesMinutesFromMidnightIn24Format()
        {
            // Arrange
            var testee = new TimeFacade();

            // Act
            var time = testee.GetTime("24:00:00");

            // Assert
            Assert.AreEqual(24, time.Hours);
        }

        [Test]
        public void GetTimeProperlyFetchesMinutesFromMidnightIn00Format()
        {
            // Arrange
            var testee = new TimeFacade();

            // Act
            var time = testee.GetTime("00:00:00");

            // Assert
            Assert.AreEqual(0, time.Hours);
        }
    }
}
