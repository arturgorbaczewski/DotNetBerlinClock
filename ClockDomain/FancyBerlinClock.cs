using System;
using System.Collections.Generic;
using System.Text;
using BerlinClock.ClockDomain.DomainFacade.Interfaces;
using BerlinClock.Enums;
using BerlinClock.TimeDomain.DomainFacade.Interfaces;
using BerlinClock.TimeDomain.Models;

namespace BerlinClock.ClockDomain
{
    public class FancyBerlinClock : IFancyClock
    {
        private readonly ITimeFacade _timeFacade;

        public FancyBerlinClock(ITimeFacade timeFacade)
        {
            _timeFacade = timeFacade;
        }

        public string GetFormattedTime(string strTime)
        {
            var time = _timeFacade.GetTime(strTime);
            if(time.IsInvalid)
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
