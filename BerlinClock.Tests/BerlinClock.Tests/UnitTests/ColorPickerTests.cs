using BerlinClock.ClockDomain.DomainFacade;
using BerlinClock.Consts;
using BerlinClock.Enums;
using NUnit.Framework;

namespace BerlinClock.Tests.UnitTests
{
    [TestFixture]
    public class ColorPickerTests
    {
        [Test]
        public void PickLightColorPicksYellowForTopLight()
        {
            // Arrange
            var testee = new ColorPicker();

            // Act
            var color = testee.PickLightColor(1, RowType.TopLightLow);

            // Assert
            Assert.AreEqual(LightColor.Yellow, color);
        }

        [Test]
        public void PickLightColorPicksRedForTopMinuteRowOnThirdLight()
        {
            // Arrange
            var testee = new ColorPicker();

            // Act
            var color = testee.PickLightColor(3, RowType.TopMinuteRow);

            // Assert
            Assert.AreEqual(LightColor.Red, color);
        }
    }
}