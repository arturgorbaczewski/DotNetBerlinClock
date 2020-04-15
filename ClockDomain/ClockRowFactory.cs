using System;
using BerlinClock.Enums;
using BerlinClock.TimeDomain;

namespace BerlinClock.ClockDomain
{
    public static class ClockRowFactory
    {
        public static ClockRow CreateClockRow(RowType rowType, Time time)
        {
            switch (rowType)
            {
                case RowType.TopLightLow:
                    {
                        return new ClockRow(rowType, 1, time.Seconds % 2 == 0 ? 1 : 0);
                    }
                case RowType.TopHourRow:
                    {
                        return new ClockRow(rowType, 4, time.Hours / 5);
                    }
                case RowType.BottomHourRow:
                    {
                        return new ClockRow(rowType, 4, time.Hours % 5);
                    }
                case RowType.TopMinuteRow:
                    {
                        return new ClockRow(rowType, 11, time.Minutes / 5);
                    }
                case RowType.BottomMinuteRow:
                    {
                        return new ClockRow(rowType, 4, time.Minutes % 5);
                    }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
