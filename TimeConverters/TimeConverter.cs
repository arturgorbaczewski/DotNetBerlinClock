using BerlinClock.ClockDomain.DomainFacade.Interfaces;

namespace BerlinClock.TimeConverters
{
    public class TimeConverter : ITimeConverter
    {
        private readonly IClockFacade _clock;

        public TimeConverter(IClockFacade clock)
        {
            _clock = clock;
        }

        public string ConvertTime(string strTime)
        {
            return _clock.GetFormattedTime(strTime);
        }
    }
}
