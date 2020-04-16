using BerlinClock.ClockDomain.DomainFacade;
using BerlinClock.ClockDomain.DomainFacade.Interfaces;
using BerlinClock.ClockDomain.Models;
using BerlinClock.Consts;
using BerlinClock.Enums;
using BerlinClock.TimeDomain.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock.Tests.UnitTests
{
    [TestFixture]
    public class ClockRowFacadeTests
    {
        private Mock<IColorPicker> _colorPickerMock;
        private IClockRowFacade _testee;
        
        [SetUp]
        public void Setup()
        {
            _colorPickerMock = new Mock<IColorPicker>();
            _testee = new ClockRowFacade(_colorPickerMock.Object);
        }

        [Test]
        public void GetNumberOfClockLightsToTurnOnCalculatesCorretlyForTopHourRow()
        {
            // Arrange
            var time = new Time { Hours = 22 };

            // Act
            var lights = _testee.GetNumberOfClockLightsToTurnOn(RowType.TopHourRow, time);

            // Assert
            Assert.AreEqual(4, lights);
        }

        [Test]
        public void GetRowContentPrintsCorrectRowLights()
        {
            // Arrange
            var row = new ClockRow
            {
                ClockLights = new List<ClockLight>
                {
                    new ClockLight { LightColor = LightColor.Red },
                    new ClockLight { LightColor = LightColor.Red },
                    new ClockLight { LightColor = LightColor.Red },
                    new ClockLight { LightColor = LightColor.None },
                }
            };

            // Act
            var rowLights = _testee.GetRowContent(row);

            // Assert
            Assert.AreEqual("RRRO", rowLights);
        }

        [Test]
        public void CreateClockRowInitializesProperlyTopHourRow()
        {
            // Arrange
            var expectedRow = new ClockRow
            {
                ClockLights = new List<ClockLight>
                {
                    new ClockLight { LightColor = LightColor.Red },
                    new ClockLight { LightColor = LightColor.Red },
                    new ClockLight { LightColor = LightColor.None },
                    new ClockLight { LightColor = LightColor.None },
                }
            };

            _colorPickerMock
                .Setup(x => x.PickLightColor(It.IsAny<int>(), It.IsAny<RowType>()))
                .Returns<int, RowType>((s, t) => LightColor.Red);

            // Act
            var row = _testee.CreateClockRow(RowType.TopHourRow, 4, 2);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedRow.ClockLights.Count(), row.ClockLights.Count());
                Assert.AreEqual(expectedRow.ClockLights.Select(x => x.LightColor), row.ClockLights.Select(x => x.LightColor));
            });
        }
    }
}
