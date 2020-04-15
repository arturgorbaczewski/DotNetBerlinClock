using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Domain
{
    public class ClockRow
    {
        private IEnumerable<ClockLight> ClockLights { get; set; }
        
        public string GetRowContent()
        {
            return "YYYYYYY";
        }
    }
}
