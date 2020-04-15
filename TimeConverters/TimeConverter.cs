using BerlinClock.Domain;

namespace BerlinClock.TimeConverters
{
    public class TimeConverter : ITimeConverter
    {
        private readonly IFancyClock _clock;

        public TimeConverter(IFancyClock clock)
        {
            _clock = clock;
        }

        public string ConvertTime(string aTime)
        {
            return _clock.GetFormattedTime(aTime);
        }
    }
}
