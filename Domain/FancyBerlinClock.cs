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
            var layout = CreateClockLayout(time);
            var fancyTime = ConvertLayoutToTime(layout);

            return fancyTime;
        }

        private IEnumerable<BerlinClockRow> CreateClockLayout(string time)
        {
            throw new NotImplementedException();
        }

        private string ConvertLayoutToTime(IEnumerable<BerlinClockRow> rows)
        {
            var sb = new StringBuilder();

            return sb.ToString();
        }
    }
}
