using BerlinClock.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Domain
{
    public class ClockRow
    {
        private IEnumerable<ClockLight> ClockLights;

        public ClockRow(int numberOfClockLights)
        {
            InitializeClockLights(numberOfClockLights);
        }

        public void SetClockRowTime()
        {
            //TODO: calculate numberOfClockLightsTurnedOn
        }

        public string GetRowContent()
        {
            return string.Join(string.Empty, ClockLights.Select(x => x.LightColor.ToString()));
        }

        private void InitializeClockLights(int numberOfClockLights)
        {
            var clockLights = new List<ClockLight>();
            for (int i = 0; i < numberOfClockLights; i++)
            {
                clockLights.Add(new ClockLight { LightColor = LightColor.None });
            }

            ClockLights = clockLights;
        }
    }
}
