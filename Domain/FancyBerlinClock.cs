using BerlinClock.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Domain
{
    public class FancyBerlinClock : IFancyClock
    {
        public string GetFormattedTime(string time)
        {
            if (string.IsNullOrWhiteSpace(time))
                throw new ArgumentNullException("Time cannot be empty");

            var layout = CreateClockLayout(time);
            var fancyTime = ConvertLayoutToTime(layout);

            return fancyTime;
        }

        private IEnumerable<ClockRow> CreateClockLayout(string time)
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
                yield return ClockRowFactory.CreateClockRow(layoutLayer);
            }     
        }

        private string ConvertLayoutToTime(IEnumerable<ClockRow> rows)
        {
            var sb = new StringBuilder();
            foreach (var row in rows)
            {
                sb.AppendLine(row.GetRowContent());
            }

            return sb.ToString();
        }
    }
}
