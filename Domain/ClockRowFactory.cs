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
                        return new ClockRow(1);
                    }
                case RowType.TopHourRow:
                    {
                        return new ClockRow(4);
                    }
                case RowType.BottomHourRow:
                    {
                        return new ClockRow(4);
                    }
                case RowType.TopMinuteRow:
                    {
                        return new ClockRow(11);
                    }
                case RowType.BottomMinuteRow:
                    {
                        return new ClockRow(4);
                    }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
