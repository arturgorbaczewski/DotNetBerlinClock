using BerlinClock.ClockDomain;
using BerlinClock.ClockDomain.DomainFacade.Interfaces;
using BerlinClock.DomainFacade.TimeDomain;

namespace BerlinClock.TimeConverters
{
    public class TimeConverter : ITimeConverter
    {
        private readonly IFancyClock _clock;

        public TimeConverter()
            : this(new FancyBerlinClock(new TimeFacade())) // TODO: rewrite to DI container with service locator
        { }

        internal TimeConverter(IFancyClock clock)
        {
            _clock = clock;
        }

        public string ConvertTime(string aTime)
        {
            return _clock.GetFormattedTime(aTime);
        }
    }
}
