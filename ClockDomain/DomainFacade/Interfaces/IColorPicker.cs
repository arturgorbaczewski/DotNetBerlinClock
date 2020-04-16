using BerlinClock.Enums;

namespace BerlinClock.ClockDomain.DomainFacade.Interfaces
{
    public interface IColorPicker
    {
        string PickLightColor(int clockLightNumber, RowType rowType);
    }
}
