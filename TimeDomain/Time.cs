using System.Text.RegularExpressions;

namespace BerlinClock.TimeDomain
{
    public class Time
    {
        private readonly string _time;

        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
        //public bool IsValid { get; private set; }

        public Time(string time)
        {
            _time = time;
            InitializeProperties();
        }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(_time)) return false;

            return true;
        }

        private void InitializeProperties()
        {
            if (!IsValid()) return;

            var timeRegex = new Regex(@"^((?:[012]\d|2[0-3])):([0-5]\d):([0-5]\d)$");
            var match = timeRegex.Match(_time);

            Hours = int.Parse(match.Groups[1].Value);
            Minutes = int.Parse(match.Groups[2].Value);
            Seconds = int.Parse(match.Groups[3].Value);
        }
    }
}
