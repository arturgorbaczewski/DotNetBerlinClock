using System;
using System.Collections.Generic;
using System.Text;
using BerlinClock.Enums;

namespace BerlinClock.Domain
{
    public class FancyBerlinClock : IFancyClock
    {
        public string GetFormattedTime(string time)
        {
            if (string.IsNullOrWhiteSpace(time))
                throw new ArgumentNullException("Time cannot be empty");

            if(!TimeSpan.TryParse(time, out var timespan))
                throw new ArgumentNullException("Time format is invalid");

            var layout = CreateClockLayout(timespan);
            var fancyTime = ConvertLayoutToTime(layout);

            return fancyTime;
        }

        private IEnumerable<ClockRow> CreateClockLayout(TimeSpan time)
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
