using System;
using BerlinClock.Enums;

namespace BerlinClock.Domain
{
    public static class ClockRowFactory
    {
        public static ClockRow CreateClockRow(RowType rowType)
        {
            switch (rowType)
            {
                case RowType.TopLightLow:
                    {
                        return new ClockRow();
                    }
                case RowType.TopHourRow:
                    {
                        return new ClockRow();
                    }
                case RowType.BottomHourRow:
                    {
                        return new ClockRow();
                    }
                case RowType.TopMinuteRow:
                    {
                        return new ClockRow();
                    }
                case RowType.BottomMinuteRow:
                    {
                        return new ClockRow();
                    }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
