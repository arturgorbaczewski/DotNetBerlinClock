using Autofac;
using BerlinClock.ClockDomain;
using BerlinClock.ClockDomain.DomainFacade.Interfaces;
using BerlinClock.DomainFacade.TimeDomain;
using BerlinClock.TimeConverters;
using BerlinClock.TimeDomain.DomainFacade.Interfaces;

namespace BerlinClock.IoC
{
    public static class IoCContainer
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TimeFacade>().As<ITimeFacade>();
            builder.RegisterType<ClockRow>().As<IClockRow>();
            builder.RegisterType<FancyBerlinClock>().As<IFancyClock>();
            builder.RegisterType<TimeConverter>().As<ITimeConverter>();
            return builder.Build();
        }
    }
}
