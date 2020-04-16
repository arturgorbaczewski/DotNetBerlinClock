using System.Text.RegularExpressions;
using BerlinClock.TimeDomain.DomainFacade.Interfaces;
using BerlinClock.TimeDomain.Models;

namespace BerlinClock.DomainFacade.TimeDomain
{
    public class TimeFacade : ITimeFacade
    {
        public Time GetTime(string strTime)
        {
            var timeRegex = new Regex(@"^((?:[012]\d|2[0-3])):([0-5]\d):([0-5]\d)$");
            var isMatch = timeRegex.IsMatch(strTime);

            if (string.IsNullOrWhiteSpace(strTime) || !isMatch)
                return new Time { IsInvalid = true };

            var match = timeRegex.Match(strTime);

            return new Time
            {
                Hours = int.Parse(match.Groups[1].Value),
                Minutes = int.Parse(match.Groups[2].Value),
                Seconds = int.Parse(match.Groups[3].Value)
            };
        }
    }
}
