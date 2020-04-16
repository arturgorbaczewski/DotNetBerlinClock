using BerlinClock.ClockDomain.DomainFacade.Interfaces;
using BerlinClock.ClockDomain.Models;
using BerlinClock.Consts;
using BerlinClock.Enums;
using BerlinClock.TimeDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BerlinClock.ClockDomain.DomainFacade
{
    public class ClockRowFacade : IClockRowFacade
    {
        private readonly IColorPicker _colorPicker;

        public ClockRowFacade(IColorPicker colorPicker)
        {
            _colorPicker = colorPicker;
        }

        public ClockRow CreateClockRow(RowType rowType, int numberOfClockLights, int numberOfClockLightsToTurnOn)
        {
            var clockLights = new List<ClockLight>();
            for (int i = 1; i < numberOfClockLights + 1; i++)
            {
                if (i < numberOfClockLightsToTurnOn + 1)
                    clockLights.Add(new ClockLight { LightColor = _colorPicker.PickLightColor(i, rowType) });
                else
                    clockLights.Add(new ClockLight { LightColor = LightColor.None });
            }

            return new ClockRow { ClockLights = clockLights };
        }

        public string GetRowContent(ClockRow row)
        {
            return string.Join(string.Empty, row.ClockLights.Select(x => x.LightColor.ToString()));
        }

        public int GetNumberOfClockLightsToTurnOn(RowType rowType, Time time)
        {
            switch (rowType)
            {
                case RowType.TopLightLow:
                    return time.Seconds % 2 == 0 ? 1 : 0;
                case RowType.TopHourRow:
                    return time.Hours / 5;
                case RowType.BottomHourRow:
                    return time.Hours % 5;
                case RowType.TopMinuteRow:
                    return time.Minutes / 5;
                case RowType.BottomMinuteRow:
                    return time.Minutes % 5;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
