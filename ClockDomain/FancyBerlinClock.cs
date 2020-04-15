using System;
using System.Collections.Generic;
using System.Text;
using BerlinClock.Enums;
using BerlinClock.TimeDomain;

namespace BerlinClock.ClockDomain
{
    public class FancyBerlinClock : IFancyClock
    {
        public string GetFormattedTime(string aTime)
        {
            var time = new Time(aTime);
            if(!time.IsValid())
                throw new ArgumentNullException("Time format is invalid");

            var layout = CreateClockLayout(time);
            var fancyTime = ConvertLayoutToTime(layout);

            return fancyTime;
        }

        private IEnumerable<ClockRow> CreateClockLayout(Time time)
        {
            RowType[] orderedLayout = 
            {
                RowType.TopLightLow,
                RowType.TopHourRow,
                RowType.BottomHourRow,
                RowType.TopMinuteRow,
                RowType.BottomMinuteRow
            };

            foreach (var layoutLayer in orderedLayout)
            {
                yield return ClockRowFactory.CreateClockRow(layoutLayer, time);
            }     
        }

        private string ConvertLayoutToTime(IEnumerable<ClockRow> rows)
        {
            var sb = new StringBuilder();
            foreach (var row in rows)
            {
                sb.AppendLine(row.GetRowContent());
            }

            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }
    }
}
