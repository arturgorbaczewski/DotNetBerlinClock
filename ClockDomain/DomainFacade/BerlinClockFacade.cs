using System;
using System.Collections.Generic;
using System.Text;
using BerlinClock.ClockDomain.DomainFacade.Interfaces;
using BerlinClock.ClockDomain.Models;
using BerlinClock.Enums;
using BerlinClock.TimeDomain.DomainFacade.Interfaces;
using BerlinClock.TimeDomain.Models;

namespace BerlinClock.ClockDomain.DomainFacade
{
    public class BerlinClockFacade : IClockFacade
    {
        private readonly ITimeFacade _timeFacade;
        private readonly IClockRowFacade _clockRowFacade;

        public BerlinClockFacade(ITimeFacade timeFacade,
            IClockRowFacade clockRowFacade)
        {
            _timeFacade = timeFacade;
            _clockRowFacade = clockRowFacade;
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
            var orderedLayout = new Dictionary<RowType, int>
            {
                { RowType.TopLightLow, 1 },
                { RowType.TopHourRow, 4 },
                { RowType.BottomHourRow, 4 },
                { RowType.TopMinuteRow, 11 },
                { RowType.BottomMinuteRow, 4 }
            };

            foreach (var layoutLayer in orderedLayout)
            {
                var lightsOn = _clockRowFacade.GetNumberOfClockLightsToTurnOn(layoutLayer.Key, time);
                yield return _clockRowFacade.CreateClockRow(layoutLayer.Key, layoutLayer.Value, lightsOn);
            }
        }

        private string ConvertLayoutToTime(IEnumerable<ClockRow> rows)
        {
            var sb = new StringBuilder();
            foreach (var row in rows)
            {
                sb.AppendLine(_clockRowFacade.GetRowContent(row));
            }

            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }
    }
}
