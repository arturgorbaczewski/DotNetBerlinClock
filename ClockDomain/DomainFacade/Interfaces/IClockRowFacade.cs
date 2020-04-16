using BerlinClock.ClockDomain.Models;
using BerlinClock.Enums;
using BerlinClock.TimeDomain.Models;

namespace BerlinClock.ClockDomain.DomainFacade.Interfaces
{
    public interface IClockRowFacade
    {
        int GetNumberOfClockLightsToTurnOn(RowType rowType, Time time);
        ClockRow CreateClockRow(RowType rowType, int numberOfClockLights, int numberOfClockLightsToTurnOn);
        string GetRowContent(ClockRow row);
    }
}
