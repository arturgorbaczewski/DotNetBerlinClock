using BerlinClock.ClockDomain.DomainFacade.Interfaces;
using BerlinClock.Consts;
using BerlinClock.Enums;

namespace BerlinClock.ClockDomain.DomainFacade
{
    public class ColorPicker : IColorPicker
    {
        public string PickLightColor(int clockLightNumber, RowType rowType)
        {
            switch (rowType)
            {
                case RowType.TopLightLow:
                    return LightColor.Yellow;
                case RowType.TopHourRow:
                    return LightColor.Red;
                case RowType.BottomHourRow:
                    return LightColor.Red;
                case RowType.TopMinuteRow:
                    {
                        return (clockLightNumber != 0 && clockLightNumber % 3 == 0)
                            ? LightColor.Red
                            : LightColor.Yellow;
                    }
                case RowType.BottomMinuteRow:
                    return LightColor.Yellow;
                default:
                    return LightColor.None;
            }
        }
    }
}
