using System.Collections.Generic;
using System.Linq;
using BerlinClock.ClockDomain.Interfaces;
using BerlinClock.Consts;
using BerlinClock.Enums;

namespace BerlinClock.ClockDomain
{
    public class ClockRow : IClockRow
    {
        private IEnumerable<ClockLight> ClockLights;

        public ClockRow(RowType rowType, int numberOfClockLights, int numberOfClockLightsToTurnOn)
        {
            InitializeClockLights(rowType, numberOfClockLights, numberOfClockLightsToTurnOn);
        }

        public string GetRowContent()
        {
            return string.Join(string.Empty, ClockLights.Select(x => x.LightColor.ToString()));
        }

        private void InitializeClockLights(RowType rowType, int numberOfClockLights, int numberOfClockLightsToTurnOn)
        {
            var clockLights = new List<ClockLight>();
            for (int i = 1; i < numberOfClockLights + 1; i++)
            {
                if (i < numberOfClockLightsToTurnOn + 1)
                    clockLights.Add(new ClockLight { LightColor = PickLightColor(i, rowType) });
                else
                    clockLights.Add(new ClockLight { LightColor = LightColor.None });
            }

            ClockLights = clockLights;
        }

        private string PickLightColor(int clockLightNumber, RowType rowType)
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
