using System.Text.RegularExpressions;

namespace BerlinClock.TimeDomain
{
    public class Time
    {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
        public bool IsInvalid { get; private set; }

        public Time(string time)
        {
            InitializeProperties(time);
        }

        private void InitializeProperties(string time)
        {
            var timeRegex = new Regex(@"^((?:[012]\d|2[0-3])):([0-5]\d):([0-5]\d)$");
            var isMatch = timeRegex.IsMatch(time);

            if (string.IsNullOrWhiteSpace(time) || !isMatch)
            {
                IsInvalid = true;
                return;
            }

            var match = timeRegex.Match(time);
            Hours = int.Parse(match.Groups[1].Value);
            Minutes = int.Parse(match.Groups[2].Value);
            Seconds = int.Parse(match.Groups[3].Value);
        }
    }
}
